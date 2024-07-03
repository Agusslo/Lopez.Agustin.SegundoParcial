using ClassLibrary;
using Entidades;
using System;
using System.Windows.Forms;

namespace WinForm
{
    public partial class AgregarOrco : AgregarPersonaje
    {
        public Orco orco;
        public bool canibal;

        public AgregarOrco()
        {
            InitializeComponent();
            cbEspecie.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEspecie.DataSource = Enum.GetValues(typeof(EEspecieOrco));
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        public AgregarOrco(Orco orco) : this()
        {
            this.orco = orco;
            CargarDatosOrco();
        }

        /// <summary>
        /// Carga los datos del Orco en los controles de la ventana.
        /// </summary>
        private void CargarDatosOrco()
        {
            if (orco != null)
            {
                txtNombre.Text = orco.ObtenerNombre();
                cbEdad.SelectedItem = orco.ObtenerEdad();
                cbCaracteristica.SelectedItem = orco.ObtenerCaracteristica();
                cbEspecie.SelectedItem = orco.GetEspecieOrco();
                canibal = orco.GetCanibal();
                checkBox1.Checked = canibal;
                cbResucitado.Checked = orco.ObtenerResucitado();
            }
        }

        /// <summary>
        /// Obtiene el objeto Orco actualmente configurado en la ventana.
        /// </summary>
        /// <returns>Objeto Orco configurado con los datos actuales de la ventana.</returns>
        public Orco ObtenerOrco()
        {
            return new Orco(orco.ObtenerNombre(), orco.ObtenerEdad(), orco.ObtenerCaracteristica(), orco.ObtenerResucitado(), orco.GetEspecieOrco(), orco.GetCanibal());
        }

        /// <summary>
        /// El cheked de canibal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            canibal = checkBox1.Checked;
        }

        /// <summary>
        /// Agrega los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.orco = new Orco(txtNombre.Text, (EEdad)cbEdad.SelectedItem, (ECaracteristica)cbCaracteristica.SelectedItem, cbResucitado.Checked, (EEspecieOrco)cbEspecie.SelectedItem, this.canibal);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ///
        }
    }
}
