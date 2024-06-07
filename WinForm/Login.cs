using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using ClassLibrary;

namespace WinForm
{
    public partial class Login : Form
    {
        List<Usuario> usuarios;
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ParcialAgus");
        string logPath;
        string perfilUsuario;
        string nombreUsuario = string.Empty;

        public Login()
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            InitializeComponent();
            CargarUsuarios();
            logPath = Path.Combine(folderPath, "logs.log");
        }

        private void CargarUsuarios()
        {
            try
            {
                string jsonUsuarios = File.ReadAllText("MOCK_DATA.json");
                usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonUsuarios, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("El archivo MOCK_DATA.json no existe.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}");
            }
        }

        private void CargarLogs(string email)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, true))
                {
                    sw.WriteLine($"{email} - {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el log: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool usuarioEncontrado = false;
            string correoUsuario = string.Empty; // Variable para almacenar el correo del usuario

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Correo == txtCorreo.Text && usuario.Clave == txtContrasenia.Text)
                {
                    correoUsuario = usuario.Correo; // Guardamos el correo electrónico del usuario
                    perfilUsuario = usuario.Perfil; // Guardamos el perfil del usuario

                    Menu frmMenu = new Menu(logPath, perfilUsuario, correoUsuario);
                    frmMenu.Show();
                    this.Hide();
                    CargarLogs(usuario.Correo);
                    usuarioEncontrado = true;
                    break;
                }
            }
            if (!usuarioEncontrado)
            {
                MessageBox.Show("Correo electrónico o contraseña incorrectos.");
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtContrasenia.UseSystemPasswordChar = false;
            else
                txtContrasenia.UseSystemPasswordChar = true;
        }

        private void btnRapido_Click_1(object sender, EventArgs e)
        {
            string correoRapido = "aguss@rapido.com";
            string perfilRapido = "aguss";

            Menu frmMenu = new Menu(logPath, perfilRapido, correoRapido);
            frmMenu.Show();
            this.Hide();
            CargarLogs(correoRapido);
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
