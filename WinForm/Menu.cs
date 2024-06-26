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
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ParcialAgus"); // se ubica en documentos
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
            listBox1.Size = new System.Drawing.Size(914, 229); // Tamaño original del ListBox1
            listBox1.Location = new System.Drawing.Point(12, 40); // Posición original del ListBox1
            ActualizarLista();

            // Mostrar información del usuario
            lblCorreousuario.Text = "Correo: " + this.correoUsuario;
            lblHoraInicioSesion.Text = "Hora de registro: " + DateTime.Now.ToString("HH:mm:ss");

            // Configurar botones según el perfil de usuario
            if (perfilUsuario == "supervisor" || perfilUsuario == "vendedor")
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnAgregar.Enabled = false;
            }
        }

        // Método que se ejecutará cada vez que el temporizador cambie de intervalo
        private void Timer_Tick(object? sender, EventArgs e) // El ? para arreglar el warning
        {
            // Actualizar la hora en el Label
            lblHora.Text = "Horario Tiempo Real: " + DateTime.Now.ToString("HH:mm:ss");
        }

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
            // Establecer el ancho total del contenido del ListBox1 para la barra de desplazamiento horizontal
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
            MessageBox.Show("No tienes permiso para modificar personajes.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void btnAgregar_Click_1(object? sender, EventArgs e)
        {
            MessageBox.Show("No tienes permiso para agregar personajes.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnEliminar_Click_1(object? sender, EventArgs e)
        {
            MessageBox.Show("No tienes permiso para eliminar personajes.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void abrirToolStripMenuItem_Click(object? sender, EventArgs e)
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
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(listBoxItems);

                    MessageBox.Show("Archivo XML cargado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
    }
}
