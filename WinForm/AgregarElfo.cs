using ClassLibrary;
using Entidades;
using System;
using System.Windows.Forms;

namespace WinForm
{
    public partial class AgregarElfo : AgregarPersonaje
    {
        public Elfo elfo;
        public bool inmortal;

        public AgregarElfo()
        {
            InitializeComponent();
            cbEspecie.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEspecie.DataSource = Enum.GetValues(typeof(EEspecieElfo));
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        public AgregarElfo(Elfo elfo) : this()
        {
            this.elfo = elfo;
            CargarDatosElfo();
        }

        private void CargarDatosElfo()
        {
            if (elfo != null)
            {
                txtNombre.Text = elfo.ObtenerNombre();
                cbEdad.SelectedItem = elfo.ObtenerEdad();
                cbCaracteristica.SelectedItem = elfo.ObtenerCaracteristica();
                cbEspecie.SelectedItem = elfo.GetEspecieElfo();
                inmortal = elfo.GetInmortalidad();
                checkBox1.Checked = inmortal; 
            }
        }

        public Elfo ObtenerElfo()
        {
            return new Elfo(elfo.ObtenerNombre(), elfo.ObtenerCaracteristica(), elfo.ObtenerEdad(), elfo.GetEspecieElfo(), elfo.GetInmortalidad());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            inmortal = checkBox1.Checked;
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            this.elfo = new Elfo(txtNombre.Text, (ECaracteristica)cbCaracteristica.SelectedItem, (EEdad)cbEdad.SelectedItem, (EEspecieElfo)cbEspecie.SelectedItem, this.inmortal);
            this.DialogResult = DialogResult.OK;
        }
    }
}
