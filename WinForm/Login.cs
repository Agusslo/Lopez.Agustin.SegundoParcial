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
        List<Usuario> usuarios = new List<Usuario>();
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ParcialAgus");
        string logPath;
        string perfilUsuario = string.Empty;
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
                usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonUsuarios, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Usuario>();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("El archivo MOCK_DATA.json no existe.");
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error al deserializar los usuarios: {ex.Message}");
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
            string correoUsuario = string.Empty;

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Correo == txtCorreo.Text && usuario.Clave == txtContrasenia.Text)
                {
                    correoUsuario = usuario.Correo;
                    perfilUsuario = usuario.Perfil;

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
    }
}