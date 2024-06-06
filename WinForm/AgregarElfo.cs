using ClassLibrary;
using Entidades;

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
            }
        }

        public Elfo ObtenerElfo()
        {
            return new Elfo(elfo.ObtenerNombre(), elfo.ObtenerCaracteristica(), elfo.ObtenerEdad(), elfo.GetEspecieElfo(), elfo.GetInmortalidad());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                inmortal = true;
            else inmortal = false;
        }


        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            this.elfo = new Elfo(txtNombre.Text, (ECaracteristica)cbCaracteristica.SelectedItem, (EEdad)cbEdad.SelectedItem, (EEspecieElfo)cbEspecie.SelectedItem, this.inmortal);
            this.DialogResult = DialogResult.OK;
        }
    }
}
