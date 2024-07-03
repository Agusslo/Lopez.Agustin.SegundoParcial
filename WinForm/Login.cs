using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace WinForm
{
    public partial class Login : Form
    {

        List<Usuario> usuarios;
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ParcialAgus");
        string logPath;


        #region Constructor y Inicializacion

        public Login()
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            InitializeComponent();
            logPath = Path.Combine(folderPath, "logs.log");

            try
            {
                // FONDO LOGIN
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imagenLogin.jpg");
                if (File.Exists(imagePath))
                {
                    this.BackgroundImage = System.Drawing.Image.FromFile(imagePath);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    MessageBox.Show("La imagen 'imagenLogin.jpg' no se encontró en la carpeta de ejecución.", "Error de imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargarUsuarios();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Archivo no encontrado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"No tienes permiso para acceder al archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error de E/S: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// evento que se encarga de cargar los usuarios del MOCK_DATA, este archivo brinda toda la data para iniciar sesion
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                string jsonUsuarios = File.ReadAllText("MOCK_DATA.json");
                usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonUsuarios, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Archivo no encontrado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error de deserialización JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Controles

        /// <summary>
        /// Evento de clic del botón para autenticar al usuario.
        /// </summary>
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool usuarioEncontrado = false;

                foreach (Usuario usuario in usuarios)
                {
                    if (usuario.Correo == txtCorreo.Text && usuario.Clave == txtContrasenia.Text)
                    {
                        await MostrarPantallaCarga(() =>
                        {
                            // Lógica después de autenticar al usuario
                            Menu frmMenu = new Menu(logPath, usuario.Perfil, usuario.Correo);
                            frmMenu.Show();
                            this.Hide();
                            CargarLogs(usuario.Correo, usuario.Nombre, usuario.Apellido, usuario.Legajo, usuario.Perfil);
                        });

                        usuarioEncontrado = true;
                        break;
                    }
                }

                if (!usuarioEncontrado)
                {
                    MessageBox.Show("Correo electrónico o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al autenticar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método para mostrar una pantalla de carga mientras se realiza una operación asincrónica.
        /// </summary>
        private async Task MostrarPantallaCarga(Action action)
        {
            using (var cargaForm = new FormPantallaCarga())
            {
                cargaForm.Show();

                // Simulación de carga
                await Task.Delay(2000);

                action.Invoke();
            }
        }

        /// <summary>
        /// Evento de clic del botón rápido para autenticar con credenciales predefinidas.
        /// </summary>
        private void btnRapido_Click_1(object sender, EventArgs e)
        {
            string correoRapido = "aguss@rapido.com";
            string perfilRapido = "aguss";
            string nombreRapido = "agustin";
            string apellidoRapido = "lopez";
            int legajoRapido = 0;

            using (var formContraseña = new FormContraseñaRapida())
            {
                if (formContraseña.ShowDialog() == DialogResult.OK)
                {
                    Usuario usuarioRapido = usuarios.Find(u => u.Correo == correoRapido);
                    if (usuarioRapido != null)
                    {
                        nombreRapido = usuarioRapido.Nombre;
                        apellidoRapido = usuarioRapido.Apellido;
                        legajoRapido = usuarioRapido.Legajo;
                    }

                    Menu frmMenu = new Menu(logPath, perfilRapido, correoRapido);
                    frmMenu.Show();
                    this.Hide();
                    CargarLogs(correoRapido, nombreRapido, apellidoRapido, legajoRapido, perfilRapido);
                }
            }
        }

        /// <summary>
        /// Evento de cambio del estado del checkbox para mostrar/ocultar la contraseña.
        /// </summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtContrasenia.UseSystemPasswordChar = false;
            else
                txtContrasenia.UseSystemPasswordChar = true;
        }

        /// <summary>
        /// Evento de cambio del estado del checkbox para mostrar/ocultar la contraseña.
        /// </summary>
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtContrasenia.UseSystemPasswordChar = false;
            else
                txtContrasenia.UseSystemPasswordChar = true;
        }

        #endregion

        #region Carga LOGS

        /// <summary>
        /// Método para cargar registros de log en un archivo.
        /// </summary>
        private void CargarLogs(string email, string nombre, string apellido, int legajo, string perfil)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, true))
                {
                    sw.WriteLine($"{nombre} {apellido} - {legajo} - {email} - {perfil} - {DateTime.Now}");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"No tienes permiso para acceder al archivo de log: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error de E/S al escribir en el archivo de log: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al guardar el log: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Form Closing

        /// <summary>
        /// Evento que se ejecuta cuando se está cerrando el formulario para confirmar con el usuario.
        /// </summary>
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

        #endregion
    }
}
