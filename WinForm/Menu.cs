using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using ADO;
using ClassLibrary;

namespace WinForm
{
    public partial class Menu : Form
    {
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ParcialAgus");
        string path;
        string logPath;
        Coleccion personajes;
        string perfilUsuario;
        string correoUsuario;

        System.Windows.Forms.Timer timer;

        public Menu(string logPath, string perfilUsuario, string correoUsuario)
        {
            InitializeComponent();

            // FONDO MENU
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imagenMenu.jpg");
            if (File.Exists(imagePath))
            {
                this.BackgroundImage = Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                MessageBox.Show("La imagen 'imagenMenu.jpg' no se encontró en la carpeta de ejecución.", "Error de imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            listBox1.HorizontalScrollbar = true;
            listBox1.Size = new System.Drawing.Size(914, 229);
            listBox1.Location = new System.Drawing.Point(12, 40);
            ActualizarLista();

            // Mostrar información del usuario
            lblCorreousuario.Text = "Correo: " + this.correoUsuario;
            lblHoraInicioSesion.Text = "Hora de registro: " + DateTime.Now.ToString("HH:mm:ss");
            lblPerfil.Text = "SU PERFIL ES: " + this.perfilUsuario;

            // Configurar botones según el perfil de usuario
            if (perfilUsuario == "supervisor")
            {
                btnEliminar.Enabled = false;
            }
            else if (perfilUsuario == "vendedor")
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnAgregar.Enabled = false;
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            lblHora.Text = "Horario Tiempo Real: " + DateTime.Now.ToString("HH:mm:ss");
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
            if (perfilUsuario == "vendedor")
            {
                MessageBox.Show("No tienes permiso para modificar personajes.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un personaje para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Personaje personajeSeleccionado = listBox1.SelectedItem as Personaje;
            Coleccion copiaPersonajes = personajes; // "Copia de seguridad"
            Form modificarForm;

            if (personajeSeleccionado is Elfo ElfoSeleccionado)
            {
                modificarForm = new AgregarElfo(ElfoSeleccionado);
            }
            else if (personajeSeleccionado is Orco orcoSeleccionado)
            {
                modificarForm = new AgregarOrco(orcoSeleccionado);
            }
            else if (personajeSeleccionado is Humano HumanoSeleccionado)
            {
                modificarForm = new AgregarHumano(HumanoSeleccionado);
            }
            else
            {
                throw new InvalidOperationException("Tipo de personaje no soportado.");
            }

            if (modificarForm != null && modificarForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Personaje nuevoPersonaje = null;

                    if (modificarForm is AgregarElfo agregarElfoForm)
                    {
                        nuevoPersonaje = agregarElfoForm.ObtenerElfo();
                    }
                    else if (modificarForm is AgregarOrco agregarOrcoForm)
                    {
                        nuevoPersonaje = agregarOrcoForm.ObtenerOrco();
                    }
                    else if (modificarForm is AgregarHumano agregarHumanoForm)
                    {
                        nuevoPersonaje = agregarHumanoForm.ObtenerHumano();
                    }

                    if (nuevoPersonaje != null)
                    {
                        // Modificar el personaje en la base de datos
                        ConexionDB conexionDB = new ConexionDB();
                        conexionDB.ModificarPersonaje(personajeSeleccionado, nuevoPersonaje); //ARREGLAR

                        // Actualizar la colección en memoria y la lista visual
                        personajes -= personajeSeleccionado;
                        personajes += nuevoPersonaje;
                        ActualizarLista();
                    }
                }
                catch (ArgumentException ex)
                {
                    // Si ocurre una excepción, restaurar la colección original
                    personajes = copiaPersonajes;
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado al modificar el personaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void btnAgregar_Click_1(object? sender, EventArgs e)
        {
            if (perfilUsuario == "vendedor")
            {
                MessageBox.Show("No tienes permiso para agregar personajes.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FrmEleccion agregar = new FrmEleccion();
                if (agregar.ShowDialog() == DialogResult.OK)
                {
                    Personaje? nuevoPersonaje = agregar.SelectedPersonaje;

                    try
                    {
                        personajes += nuevoPersonaje!;
                        ActualizarLista();

                        // guardar en la base de datos
                        ConexionDB bd = new ConexionDB();
                        if (bd.PruebaConexion())
                        {
                            Console.WriteLine("Conexión exitosa a la base de datos.");
                            bd.GuardarColeccionSQL(personajes);
                            Console.WriteLine("Datos guardados correctamente.");
                            MessageBox.Show("Datos Guardados en BD.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Console.WriteLine("No se pudo conectar a la base de datos.");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inesperado al agregar el personaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (perfilUsuario == "vendedor" || perfilUsuario == "supervisor")
            {
                MessageBox.Show("No tienes permiso para eliminar personajes.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (listBox1.SelectedIndex != -1)
                {
                    if (listBox1.SelectedItem is Personaje personajeSeleccionado)
                    {
                        try
                        {
                            // Eliminar de la colección local
                            personajes -= personajeSeleccionado;
                            ActualizarLista();

                            // Eliminar del sistema (base de datos)
                            ConexionDB bd = new ConexionDB();
                            bool eliminacionExitosa = bd.EliminarSistema(personajeSeleccionado);

                            if (eliminacionExitosa)
                            {
                                MessageBox.Show("Personaje eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Console.WriteLine("Personaje eliminado correctamente.");
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el personaje.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar el personaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un personaje para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                GuardarColeccionEnXml(filePath, personajes);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("No tienes permiso para guardar el archivo en esta ubicación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error de E/S al guardar el archivo XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al guardar el archivo XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GuardarColeccionEnXml(string filePath, Coleccion coleccion)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Coleccion), new Type[] { typeof(Humano), typeof(Orco), typeof(Elfo) });
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, coleccion);
                }
                MessageBox.Show("Archivo XML guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error al serializar el objeto: " + ex.Message, "Error de serialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error de E/S al guardar el archivo XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al guardar el archivo XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    XmlSerializer serializer = new XmlSerializer(typeof(Coleccion));
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        personajes = (Coleccion)serializer.Deserialize(reader);
                    }

                    ActualizarLista();
                    MessageBox.Show("Archivo XML cargado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("El archivo XML no se encontró: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("No tienes permiso para abrir el archivo XML.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error de E/S al abrir el archivo XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Error al deserializar el archivo XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado al abrir el archivo XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void verLogsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                FrmLog logsForm = new FrmLog(logPath);
                logsForm.ShowDialog();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Archivo de logs no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("No tienes permiso para acceder al archivo de logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error de E/S al acceder al archivo de logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al abrir los logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void masJovenPrimeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                personajes.OrdenarPorEdad(ascendente: true);
                ActualizarLista();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error al ordenar por edad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al ordenar por edad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void masAncianoPrimeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                personajes.OrdenarPorEdad(ascendente: false);
                ActualizarLista();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error al ordenar por edad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al ordenar por edad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ascendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                personajes.OrdenarPorNombre(true);
                ActualizarLista();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error al ordenar por nombre: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al ordenar por nombre: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void descendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                personajes.OrdenarPorNombre(false);
                ActualizarLista();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error al ordenar por nombre: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al ordenar por nombre: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void masAltoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                personajes.OrdenarPorTamaño(false);
                ActualizarLista();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error al ordenar por tamaño: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al ordenar por tamaño: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menosAltoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                personajes.OrdenarPorTamaño(true);
                ActualizarLista();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error al ordenar por tamaño: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al ordenar por tamaño: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
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

        private void cbOrco_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void cbElfo_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void cbHumano_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void cbHumano_CheckedChanged_1(object sender, EventArgs e)
        {
            ActualizarLista();
        }
    }
}
