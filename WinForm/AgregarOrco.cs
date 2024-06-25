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
            }
        }

        public Orco ObtenerOrco()
        {
            return new Orco(orco.ObtenerNombre(), orco.ObtenerCaracteristica(), orco.ObtenerEdad(), orco.GetEspecieOrco(), orco.GetCanibal());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            canibal = checkBox1.Checked;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.orco = new Orco(txtNombre.Text, (ECaracteristica)cbCaracteristica.SelectedItem, (EEdad)cbEdad.SelectedItem, (EEspecieOrco)cbEspecie.SelectedItem, this.canibal);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
        }
    }
}
