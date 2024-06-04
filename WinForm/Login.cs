using ClassLibrary;
using System.Text.Json;


namespace WindowsForm
{
    public partial class Login : Form
    {
        List<Usuario> usuarios;
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "parcial");
        string logPath;

        public Login()
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
                if (usuario.Correo == txtCorreo.Text && usuario.Clave == txtContrasenia.Text)
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
                txtContrasenia.UseSystemPasswordChar = false;
            else
            {
                txtContrasenia.UseSystemPasswordChar = true;

            }
        }
    }
}
