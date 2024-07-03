using System;
using System.IO;
using System.Threading.Tasks;
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

        #region boton

        /// <summary>
        /// Evento de clic en el botón Aceptar para verificar la contraseña ingresada.
        /// </summary>
        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            string contraseñaIngresada = txtContrasenia.Text.Trim();

            if (contraseñaIngresada == "2004")
            {
                await MostrarPantallaCarga(() =>
                {
                    DialogResult = DialogResult.OK;
                });
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta. Intente de nuevo. \n Recuerda que es la fecha de nacimiento de Agustin.", "Error de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region MostrarPantallaCarga, Checked  y logica para aceptar con ENTER
        /// <summary>
        /// Método asincrónico para mostrar una pantalla de carga durante una tarea.
        /// </summary>
        /// <param name="action">Acción a ejecutar después de completar la carga.</param>
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
        /// Evento que maneja el cambio en el estado del checkbox para mostrar/ocultar la contraseña.
        /// </summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtContrasenia.UseSystemPasswordChar = false;
            else
                txtContrasenia.UseSystemPasswordChar = true;
        }

        /// <summary>
        /// Maneja el evento de presionar tecla en el formulario para permitir el uso de Enter para aceptar.
        /// </summary>
        private void FormContraseñaRapida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // para presionar enter
            {
                btnAceptar.PerformClick();
            }
        }
        #endregion


        #region FormClosing
        /// <summary>
        /// Sobrecarga del evento de cierre del formulario para confirmar la salida si es cerrado por el usuario.
        /// </summary>
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
        #endregion
    }
}
