using System;
using System.IO;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FormContraseñaRapida : Form
    {
        public FormContraseñaRapida()
        {
            InitializeComponent();

            try
            {
                // FONDO DEL INICIO RAPIDO
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imagenInicioRapido.jpg");

                if (File.Exists(imagePath))
                {
                    this.BackgroundImage = System.Drawing.Image.FromFile(imagePath);
                    this.BackgroundImageLayout = ImageLayout.Stretch; // ajusta la imagen al tamaño del formulario
                }
                else
                {
                    MessageBox.Show("La imagen 'imagenInicioRapido.jpg' no se encontró en la carpeta de ejecución.", "Error de imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Configurar el botón Aceptar como botón predeterminado (Enter)
                this.AcceptButton = btnAceptar;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Archivo de imagen no encontrado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("No tienes permiso para acceder al archivo de imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error de E/S al acceder al archivo de imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al cargar el formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string contraseñaIngresada = txtContrasenia.Text.Trim();

            if (contraseñaIngresada == "2004")
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta. Intente de nuevo. \n Acordate que es la fecha de nacimiento de Agustin", "Error de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtContrasenia.UseSystemPasswordChar = false;
            else
                txtContrasenia.UseSystemPasswordChar = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Preguntar al usuario si está seguro de que desea salir
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Cerrar aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }

            base.OnFormClosing(e);
        }

        private void FormContraseñaRapida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // para presionar enter
            {
                btnAceptar.PerformClick();
            }
        }
    }
}
