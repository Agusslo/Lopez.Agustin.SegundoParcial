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
            this.perfilUsuario = perfilUsuario; // para el futuro
            lblCorreousuario.Text = "Correo: " + correoUsuario; // Muestra el correo en el label
            this.correoUsuario = correoUsuario ?? "Correo no especificado";
            lblCorreousuario.Text = "Correo: " + this.correoUsuario;
            lblHoraInicioSesion.Text = "Hora de registro: " + DateTime.Now.ToString("HH:mm:ss"); // Muestra la hora de inicio de sesión

            // Configurar el temporizador
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        // Método que se ejecutará cada vez que el temporizador cambie de intervalo
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Actualizar la hora en el Label
            lblHora.Text = "Horario Tiempo Real: " + DateTime.Now.ToString("HH:mm:ss");
        }


        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////

        private void Filtrar(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            listBox1.Items.Clear();
            var filteredPersonajes = personajes.FiltrarPorTipos(cbHumano.Checked, cbOrco.Checked, cbElfo.Checked);
            foreach (var personaje in filteredPersonajes)
            {
                listBox1.Items.Add(personaje);
            }
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



        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Personaje personajeSeleccionado = listBox1.SelectedItem as Personaje;
                Form modificarForm;
                if (personajeSeleccionado is Elfo elfoSeleccionado)
                {
                    modificarForm = new AgregarElfo(elfoSeleccionado);
                }
                else if (personajeSeleccionado is Orco orcoSeleccionado)
                {
                    modificarForm = new AgregarOrco(orcoSeleccionado);
                }
                else if (personajeSeleccionado is Humano humanoSeleccionado)
                {
                    modificarForm = new AgregarHumano(humanoSeleccionado);
                }
                else
                {
                    throw new Exception("Tipo de personaje no soportado.");
                }

                if (modificarForm != null && modificarForm.ShowDialog() == DialogResult.OK)
                {
                    personajes -= personajeSeleccionado;
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
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
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

        private void cbOrco_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void cbElfo_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void cbHumano_CheckedChanged_1(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void Menu_Load_1(object sender, EventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (GuardarEnJSON)
                {
                    personajes.SerializarAJson(personajes.GetColeccion(), path);
                }
                else
                {
                    personajes.SerializarAXml(path);
                }
                // Mostrar un mensaje indicando que el archivo se ha guardado correctamente
                MessageBox.Show("Archivo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                // El usuario ha cancelado la operación de guardado, no hay necesidad de mostrar un mensaje de advertencia
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (GuardarEnJSON)
            {
                openFileDialog.Filter = "Json files (*.json)|*.json";
            }
            else
            {
                openFileDialog.Filter = "XML files (*.xml)|*.xml";
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string archivo = File.ReadAllText(filePath);
                Coleccion result;
                try
                {
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarEnJSON = false;
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarEnJSON = true;
        }

        private void verLogsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmLog logsForm = new FrmLog(logPath);
            logsForm.ShowDialog();
        }

        private void masJovenPrimeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personajes.OrdenarPorEdad(ascendente: true);
            ActualizarLista();
        }

        private void masAncianoPrimeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personajes.OrdenarPorEdad(ascendente: false);
            ActualizarLista();
        }

        private void ascendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personajes.OrdenarPorNombre(true);
            ActualizarLista();
        }

        private void descendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personajes.OrdenarPorNombre(false);
            ActualizarLista();
        }



        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
