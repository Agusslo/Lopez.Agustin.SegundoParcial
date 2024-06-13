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
            elfo = new Elfo(); // Inicializo el campo elfo
        }

        public AgregarElfo(Elfo elfo) : this()
        {
            this.elfo = elfo;
            CargarDatosElfo();
        }

        private void CargarDatosElfo()
        {
            txtNombre.Text = elfo.ObtenerNombre();
            cbEdad.SelectedItem = elfo.ObtenerEdad();
            cbCaracteristica.SelectedItem = elfo.ObtenerCaracteristica();
            cbEspecie.SelectedItem = elfo.GetEspecieElfo();
            inmortal = elfo.GetInmortal();
            cbResucitado.Checked = elfo.ObtenerResucitado();
        }

        public Elfo ObtenerElfo()
        {
            return new Elfo(elfo.ObtenerNombre(), elfo.ObtenerEdad(), elfo.ObtenerCaracteristica(), elfo.GetEspecieElfo(), elfo.GetInmortal(), elfo.ObtenerResucitado());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                inmortal = true;
            else
                inmortal = false;
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            this.elfo = new Elfo(txtNombre.Text, (EEdad)cbEdad.SelectedItem, (ECaracteristica)cbCaracteristica.SelectedItem, (EEspecieElfo)cbEspecie.SelectedItem, this.inmortal, cbResucitado.Checked);
            this.DialogResult = DialogResult.OK;
        }
    }
}
