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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.elfo = new Elfo(txtNombre.Text, (ECaracteristica)cbCaracteristica.SelectedItem, (EEdad)cbEdad.SelectedItem, (EEspecieElfo)cbEspecie.SelectedItem, this.inmortal);
            this.DialogResult = DialogResult.OK;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                inmortal = true;
            else inmortal = false;
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

