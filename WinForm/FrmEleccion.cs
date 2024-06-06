using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForm
{
    public partial class FrmEleccion : Form
    {
        public Personaje SelectedPersonaje { get; private set; }

        public FrmEleccion()
        {
            InitializeComponent();
        }

        private void ResetearOtrosRadioButton(RadioButton radioButton)
        {
            foreach (var control in Controls.OfType<RadioButton>())
            {
                if (control != radioButton)
                    control.Checked = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnHumano_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbtnHumano.Checked)
                ResetearOtrosRadioButton(rbtnHumano);
        }

        private void rbtnOrco_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbtnOrco.Checked)
                ResetearOtrosRadioButton(rbtnOrco);
        }

        private void rbtnElfo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbtnElfo.Checked)
            {
                ResetearOtrosRadioButton(rbtnElfo);
            }
        }

        private void btnSiguiente_Click_1(object sender, EventArgs e)
        {
            if (rbtnElfo.Checked)
            {
                AgregarElfo agregarElfo = new AgregarElfo();
                if (agregarElfo.ShowDialog() == DialogResult.OK)
                {
                    SelectedPersonaje = agregarElfo.elfo;
                    this.DialogResult = DialogResult.OK;
                }
            }
            if (rbtnOrco.Checked)
            {
                AgregarOrco agregarOrco = new AgregarOrco();
                if (agregarOrco.ShowDialog() == DialogResult.OK)
                {
                    SelectedPersonaje = agregarOrco.orco;
                    this.DialogResult = DialogResult.OK;
                }
            }
            if (rbtnHumano.Checked)
            {
                AgregarHumano agregarHumano = new AgregarHumano();
                if (agregarHumano.ShowDialog() == DialogResult.OK)
                {
                    SelectedPersonaje = agregarHumano.humano;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
