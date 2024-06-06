using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ClassLibrary;

namespace WinForm
{
    public partial class Menu : Form
    {
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ParcialAgus");
        string path;
        string logPath;
        Coleccion personajes;
        bool GuardarEnJSON = true;
        string perfilUsuario;
        string correoUsuario;
        System.Windows.Forms.Timer timer;

        public Menu(string logPath, string perfilUsuario, string correoUsuario)
        {
            InitializeComponent();

            // Verificar si la carpeta existe y crearla si no
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            personajes = new Coleccion();
            this.IsMdiContainer = true;
            this.path = Path.Combine(folderPath, "configuracion");
            this.logPath = logPath;
            this.perfilUsuario = perfilUsuario;// para el futuro
            lblCorreousuario.Text = "Correo: " + correoUsuario; ; //MUESTRO EN EL LABEL EL CORREO DE QUIEN INICIO

            //TIEMPO REAL
            timer = new System.Windows.Forms.Timer(); 
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
            timer.Start(); 
        }

        // Método que se ejecutará cada vez que el temporizador cambie de intervalo
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Actualizar la hora en el Label
            lblHora.Text = "Hora de registro: " + DateTime.Now.ToString("HH:mm:ss");
        }



        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            FrmEleccion agregar = new FrmEleccion();
            if (agregar.ShowDialog() == DialogResult.OK)
            {
                Personaje nuevoPersonaje = agregar.SelectedPersonaje;

                try
                {
                    personajes += nuevoPersonaje;
                    ActualizarLista();
                }
                catch (ArgumentException ex) // Atrapa excepcion lanzada desde operator + de Coleccion
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Personaje personajeseleccionado = listBox1.SelectedItem as Personaje;
                System.Windows.Forms.Form modificarForm;
                if (personajeseleccionado is Elfo elfoSeleccionado)
                {
                    modificarForm = new AgregarElfo(elfoSeleccionado);
                }
                else if (personajeseleccionado is Orco orcoSeleccionado)
                {
                    modificarForm = new AgregarOrco(orcoSeleccionado);
                }
                else if (personajeseleccionado is Humano humanoSeleccionado)
                {
                    modificarForm = new AgregarHumano(humanoSeleccionado);
                }
                else
                {
                    throw new Exception("Tipo de personaje no soportado.");
                }

                if (modificarForm != null && modificarForm.ShowDialog() == DialogResult.OK)
                {
                    personajes -= personajeseleccionado;
                    if (modificarForm is AgregarElfo)
                    {
                        personajes += (modificarForm as AgregarElfo).ObtenerElfo();
                    }
                    else if (modificarForm is AgregarOrco)
                    {
                        personajes += (modificarForm as AgregarOrco).ObtenerOrco();
                    }
                    else if (modificarForm is AgregarHumano)
                    {
                        personajes += (modificarForm as AgregarHumano).ObtenerHumano();
                    }

                    ActualizarLista();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un personaje para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Filtrar(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            if (listBox1 != null)
            {
                listBox1.Items.Clear();
                var filteredpersonajes = personajes.FiltrarPorTipos(cbHumano.Checked, cbOrco.Checked, cbElfo.Checked);
                foreach (var personaje in filteredpersonajes)
                {
                    listBox1.Items.Add(personaje);
                }
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            /*if (perfilUsuario.ToLower() != "administrador")
            {
                MessageBox.Show("Solo un administrador puede eliminar personajes.", "Permiso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/

            if (listBox1.SelectedIndex != -1)
            {
                Personaje personajeSeleccionado = listBox1.SelectedItem as Personaje;
                if (personajeSeleccionado != null)
                {
                    personajes -= personajeSeleccionado;
                    ActualizarLista();
                    MessageBox.Show("Personaje eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un personaje para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string content;
            if (GuardarEnJSON)
            {
                personajes.SerializarAJson(personajes.GetColeccion(), path);
            }
            else
            {
                personajes.SerializarAXml(this.path);
            }
        }

        

        private void xMLToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.GuardarEnJSON = false;
        }

        private void jSONToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.GuardarEnJSON = true;
        }

        private void masJovenPrimeroToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            personajes.OrdenarPorEdad(ascendente: true);
            ActualizarLista();
        }

        private void masAncianoPrimeroToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            personajes.OrdenarPorEdad(ascendente: false);
            ActualizarLista();
        }

        private void cbHumano_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbOrco_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbElfo_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void verLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLog logsForm = new FrmLog(this.logPath);
            logsForm.ShowDialog();
        }

        private void abrirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (GuardarEnJSON)
            {
                openFileDialog.Filter = "Json files(.json)|.json";
            }
            else
            {
                openFileDialog.Filter = "XML files(.xml)|.xml";
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string archivo = File.ReadAllText(filePath);

                Coleccion result;
                if (GuardarEnJSON)
                {
                    result = Coleccion.DeserializarDeJson(archivo);
                }
                else
                {
                    result = Coleccion.DeserializarDeXml(archivo);
                }
                personajes = result;
                ActualizarLista();
            }
        }

        private void ascendenteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            personajes.OrdenarPorNombre(true);
            ActualizarLista();
        }

        private void descendenteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            personajes.OrdenarPorNombre(false);
            ActualizarLista();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Preguntar al usuario si está seguro de que desea salir
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Cerrar aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario elige No, cancelar el cierre de la aplicación
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

            base.OnFormClosing(e);
        }
    }
}
