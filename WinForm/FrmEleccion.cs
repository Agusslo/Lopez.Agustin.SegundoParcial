﻿using ClassLibrary;
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
using WinForm;

namespace WinForm
{
    public partial class FrmEleccion : Form
    {
        public Personaje? SelectedPersonaje { get; private set; }

        public FrmEleccion()
        {
            InitializeComponent();
            SelectedPersonaje = null; // Inicializar SelectedPersonaje como nulo
        }

        private void ResetearOtrosRadioButton(RadioButton radioButton)
        {
            foreach (var control in Controls.OfType<RadioButton>())
            {
                if (control != radioButton)
                    control.Checked = false;
            }
        }

        private void rbtnHumano_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnHumano.Checked)
                ResetearOtrosRadioButton(rbtnHumano);
        }

        private void rbtnOrco_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnOrco.Checked)
                ResetearOtrosRadioButton(rbtnOrco);
        }

        private void rbtnElfo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnElfo.Checked)
            {
                ResetearOtrosRadioButton(rbtnElfo);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
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
            else if (rbtnOrco.Checked)
            {
                AgregarOrco agregarOrco = new AgregarOrco();
                if (agregarOrco.ShowDialog() == DialogResult.OK)
                {
                    SelectedPersonaje = agregarOrco.orco;
                    this.DialogResult = DialogResult.OK;
                }
            }
            else if (rbtnHumano.Checked)
            {
                AgregarHumano agregarHumano = new AgregarHumano();
                if (agregarHumano.ShowDialog() == DialogResult.OK)
                {
                    SelectedPersonaje = agregarHumano.humano;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)//para que solo se cierre este form
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Cerrar aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            base.OnFormClosing(e);
        }
    }
}
