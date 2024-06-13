using ClassLibrary;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using WinForm;

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
            orco = new Orco(); //inicializo el campo orco

        }

        public AgregarOrco(Orco orco) : this()
        {
            this.orco = orco;
            CargarDatosOrco();
        }

        private void CargarDatosOrco()
        {
                txtNombre.Text = orco.ObtenerNombre();
                cbEdad.SelectedItem = orco.ObtenerEdad();
                cbCaracteristica.SelectedItem = orco.ObtenerCaracteristica();
                cbEspecie.SelectedItem = orco.GetEspecieOrco();
                canibal = orco.GetCanibal();
                cbResucitado.Checked = orco.ObtenerResucitado();
        }
        public Orco ObtenerOrco()
        {
            return new Orco(orco.ObtenerNombre(), orco.ObtenerEdad(), orco.ObtenerCaracteristica(), orco.GetEspecieOrco(), orco.GetCanibal(), orco.ObtenerResucitado());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                canibal = true;
            else canibal = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.orco = new Orco(txtNombre.Text, (EEdad)cbEdad.SelectedItem, (ECaracteristica)cbCaracteristica.SelectedItem, (EEspecieOrco)cbEspecie.SelectedItem, this.canibal, cbResucitado.Checked);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}