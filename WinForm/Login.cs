using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.Runtime.InteropServices;
using ClassLibrary;
using System.Reflection.Metadata;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace WindowsForm
{
    public partial class Main : Form
    {
        List<Usuario> usuarios;
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "parcial");
        string logPath;

        public Main()
        {

            // Creacion de carpeta

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
                // PropertyNameCaseInsensitive ignora mayusculas y minusculas
                usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonUsuarios, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("El archivo usuarios.json no existe.");
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

        private void button1_Click_1(object sender, EventArgs e)
        {

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Correo == txtCorreo.Text && usuario.Clave == txtContra.Text)
                {
                    Menu frmMain = new Menu(logPath);
                    frmMain.Show();
                    this.Hide();
                    CargarLogs(usuario.Correo);
                }
                else
                {
                    MessageBox.Show("Correo electronico o contraseña incorrectos.");
                }
                break;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtContra.UseSystemPasswordChar = false;
            else 
            {
                txtContra.UseSystemPasswordChar = true;

            }
        }
    }
}
