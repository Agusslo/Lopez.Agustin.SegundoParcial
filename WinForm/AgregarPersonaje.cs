using Entidades;
using System;
using System.Windows.Forms;

namespace WinForm
{
    public partial class AgregarPersonaje : Form
    {
        public AgregarPersonaje()
        {
            InitializeComponent();
            cbEdad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCaracteristica.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEdad.DataSource = Enum.GetValues(typeof(EEdad));
            cbCaracteristica.DataSource = Enum.GetValues(typeof(ECaracteristica));
        }

        /// <summary>
        /// Muestra un mensaje de confirmación antes de cerrar la ventana.
        /// </summary>
        private void MostrarMensajeSalida()
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Cerrar aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de salida.
        /// </summary>
        private void button2_Click_1(object sender, EventArgs e)
        {
            MostrarMensajeSalida();
        }

        private void AgregarPersonaje_Load_1(object sender, EventArgs e)
        {
            //
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //
        }
    }
}
