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
            }
        }
        public Orco ObtenerOrco()
        {
            return new Orco(orco.ObtenerNombre(), orco.ObtenerCaracteristica(), orco.ObtenerEdad(), orco.GetEspecieOrco(), orco.GetCanibal());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                canibal = true;
            else canibal = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.orco = new Orco(txtNombre.Text, (ECaracteristica)cbCaracteristica.SelectedItem, (EEdad)cbEdad.SelectedItem, (EEspecieOrco)cbEspecie.SelectedItem, this.canibal);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Preguntar al usuario si está seguro de que desea salir
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Cerrar aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario elige No, cancelar el cierre de la aplicación
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

            base.OnFormClosing(e);
        }
    }
}

