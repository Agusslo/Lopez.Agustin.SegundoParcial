using ClassLibrary;
using Entidades;
using System;
using System.Windows.Forms;

namespace WinForm
{
    public partial class AgregarHumano : AgregarPersonaje
    {
        public Humano humano;

        public AgregarHumano()
        {
            InitializeComponent();
            cbColorPiel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColorPelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColorPiel.DataSource = Enum.GetValues(typeof(EColorHumano));
            cbColorPelo.DataSource = Enum.GetValues(typeof(EColorPelo));
        }

        public AgregarHumano(Humano humano) : this()
        {
            this.humano = humano;
            CargarDatosHumano();
        }

        /// <summary>
        /// Carga los datos del Humano en los controles de la ventana.
        /// </summary>
        private void CargarDatosHumano()
        {
            if (humano != null)
            {
                txtNombre.Text = humano.ObtenerNombre();
                cbEdad.SelectedItem = humano.ObtenerEdad();
                cbCaracteristica.SelectedItem = humano.ObtenerCaracteristica();
                cbColorPelo.SelectedItem = humano.GetColorPelo();
                cbColorPiel.SelectedItem = humano.GetColorHumano();
                cbResucitado.Checked = humano.ObtenerResucitado();
            }
        }

        /// <summary>
        /// Obtiene el objeto Humano actualmente configurado en la ventana.
        /// </summary>
        /// <returns>Objeto Humano configurado con los datos actuales de la ventana.</returns>
        public Humano ObtenerHumano()
        {
            return new Humano(humano.ObtenerNombre(), humano.ObtenerEdad(), humano.ObtenerCaracteristica(), humano.ObtenerResucitado(), humano.GetColorPelo(), humano.GetColorHumano());
        }

        /// <summary>
        /// carga los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.humano = new Humano(txtNombre.Text, (EEdad)cbEdad.SelectedItem, (ECaracteristica)cbCaracteristica.SelectedItem, cbResucitado.Checked, (EColorPelo)cbColorPelo.SelectedItem, (EColorHumano)cbColorPiel.SelectedItem);
            this.DialogResult = DialogResult.OK;
        }
    }
}
