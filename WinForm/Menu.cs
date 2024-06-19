using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using ClassLibrary;

namespace WinForm
{
    public partial class Menu : Form
    {
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ParcialAgus");
        string path;
        string logPath;
        Coleccion personajes;
        private Coleccion coleccion;
        string perfilUsuario;
        string correoUsuario;

        System.Windows.Forms.Timer timer;

        public Menu(string logPath, string perfilUsuario, string correoUsuario)
        {
            InitializeComponent();

            this.logPath = logPath;
            this.perfilUsuario = perfilUsuario;
            this.correoUsuario = correoUsuario;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            this.path = Path.Combine(folderPath, "configuracion");

            personajes = new Coleccion();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += Timer_Tick;
            timer.Start();

            // Configurar el ListBox1 con la ScrollBar horizontal
            listBox1.HorizontalScrollbar = true; // Habilitar la barra de desplazamiento horizontal
            ActualizarLista();

            // Mostrar información del usuario
            lblCorreousuario.Text = "Correo: " + this.correoUsuario;
            lblHoraInicioSesion.Text = "Hora de registro: " + DateTime.Now.ToString("HH:mm:ss");
        }

        // Método que se ejecutará cada vez que el temporizador cambie de intervalo
        private void Timer_Tick(object? sender, EventArgs e) // El ? para arreglar el warning
        {
            // Actualizar la hora en el Label
            lblHora.Text = "Horario Tiempo Real: " + DateTime.Now.ToString("HH:mm:ss");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////



        // EL SIGNO DE PREGUNTA(?) ES PARA QUE PUEDA PASARLE INFO NULL Y NO TIRE WARNING
        private void Filtrar(object? sender, EventArgs e)
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
            int totalWidth = 0;
            foreach (var item in listBox1.Items)
            {
                int itemWidth = TextRenderer.MeasureText(item.ToString(), listBox1.Font).Width;
                if (itemWidth > totalWidth)
                {
                    totalWidth = itemWidth;
                }
            }
            listBox1.HorizontalExtent = totalWidth;
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Personaje personajeSeleccionado = listBox1.SelectedItem as Personaje;
                Coleccion copiaPersonajes = personajes;
                Form modificarForm;
                if (personajeSeleccionado is Elfo ElfoSeleccionado)
                {
                    modificarForm = new AgregarElfo(ElfoSeleccionado);
                }
                else if (personajeSeleccionado is Orco OrcoSeleccionado)
                {
                    modificarForm = new AgregarOrco(OrcoSeleccionado);
                }
                else if (personajeSeleccionado is Humano HumanoSeleccionado)
                {
                    modificarForm = new AgregarHumano(HumanoSeleccionado);
                }
                else
                {
                    throw new Exception("Tipo de carnívoro no soportado.");
                }
                if (modificarForm != null && modificarForm.ShowDialog() == DialogResult.OK)
                {
                    try
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
                    catch (ArgumentException ex)
                    {
                        personajes = copiaPersonajes;
                        MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            else
            {
                MessageBox.Show("Por favor, seleccione un carnívoro para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnAgregar_Click_1(object? sender, EventArgs e)
        {
            FrmEleccion agregar = new FrmEleccion();
            if (agregar.ShowDialog() == DialogResult.OK)
            {
                Personaje? nuevoPersonaje = agregar.SelectedPersonaje;

                try
                {
                    personajes += nuevoPersonaje!;
                    ActualizarLista();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnEliminar_Click_1(object? sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                if (listBox1.SelectedItem is Personaje personajeSeleccionado)
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





        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string defaultFileName = "Configuracion.xml";
                string initialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ParcialAgus");
                if (!Directory.Exists(initialDirectory))
                {
                    Directory.CreateDirectory(initialDirectory);
                }
                string filePath = Path.Combine(initialDirectory, defaultFileName);
                GuardarListBoxEnXml(filePath, listBox1);
                MessageBox.Show("Archivo XML guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el archivo XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarListBoxEnXml(string filePath, ListBox listBox)
        {
            string[] listBoxItems = new string[listBox.Items.Count];
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBoxItems[i] = listBox.Items[i].ToString();
            }
            XmlSerializer serializer = new XmlSerializer(typeof(string[]));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, listBoxItems);
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string[] listBoxItems;
                    XmlSerializer serializer = new XmlSerializer(typeof(string[]));
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        listBoxItems = (string[])serializer.Deserialize(reader);
                    }

                    personajes.personajes.Clear();
                    listBox1.Items.Clear();

                    foreach (var item in listBoxItems)
                    {
                        Personaje personaje = CrearPersonajeDesdeString(item);
                        personajes.personajes.Add(personaje);
                        listBox1.Items.Add(personaje);
                    }

                    MessageBox.Show("Archivo XML cargado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Personaje CrearPersonajeDesdeString(string item)
        {
            if (item.Contains("Elfo"))
            {
                return new Elfo();
            }
            else if (item.Contains("Orco"))
            {
                return new Orco();
            }
            else if (item.Contains("Humano"))
            {
                return new Humano();
            }
            else
            {
                throw new Exception("Tipo de personaje no reconocido.");
            }
        }


        private void verLogsToolStripMenuItem_Click_1(object? sender, EventArgs e)
        {
            FrmLog logsForm = new FrmLog(logPath);
            logsForm.ShowDialog();
        }

        private void masJovenPrimeroToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            personajes.OrdenarPorEdad(ascendente: true);
            ActualizarLista();
        }

        private void masAncianoPrimeroToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            personajes.OrdenarPorEdad(ascendente: false);
            ActualizarLista();
        }

        private void ascendenteToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            personajes.OrdenarPorNombre(true);
            ActualizarLista();
        }

        private void descendenteToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            personajes.OrdenarPorNombre(false);
            ActualizarLista();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Preguntar al usuario si está seguro de que desea salir
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Cerrar aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                base.OnFormClosing(e);
            }
        }

        private void lblHoraInicioSesion_Click(object sender, EventArgs e)
        {

        }

        private void cbOrco_CheckedChanged(object? sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void cbElfo_CheckedChanged(object? sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void cbHumano_CheckedChanged_1(object? sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void Menu_Load_1(object? sender, EventArgs e)
        {

        }
    }
}