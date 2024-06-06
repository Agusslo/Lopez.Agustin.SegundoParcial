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
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Correo == txtCorreo.Text && usuario.Clave == txtContrasenia.Text)
                {
                    Menu frmMenu = new Menu(logPath);
                    frmMenu.Show();
                    this.Hide();
                    CargarLogs(usuario.Correo);
                    break;
                }
                else
                {
                    MessageBox.Show("Correo electronico o contraseña incorrectos.");
                }
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtContrasenia.UseSystemPasswordChar = false;
            else
                txtContrasenia.UseSystemPasswordChar = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)//que no se buguee en el administrador de tarea
        {
            base.OnFormClosing(e);
            Application.Exit();
        }
    }
}
