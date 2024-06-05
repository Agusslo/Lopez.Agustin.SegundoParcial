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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForm
{
    public partial class AgregarHumano : Form

    {
        public Humano humano;
        public AgregarHumano()
        {
            InitializeComponent();
            cbColorPiel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColorPelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColorPiel.DataSource = Enum.GetValues(typeof(EColorHumano));
            cbColorPelo.DataSource = Enum.GetValues(typeof(EColorPelo));

        }

        public AgregarHumano(Humano humano) : this()
        {
            this.humano = humano;
            CargarDatosHumano();
        }

        private void CargarDatosHumano()
        {
            if (humano != null)
            {
                txtNombre.Text = humano.ObtenerNombre();
                cbEdad.SelectedItem = humano.ObtenerEdad();
                cbCaracteristica.SelectedItem = humano.ObtenerCaracteristica();
                cbColorPelo.SelectedItem = humano.GetColorPelo();
                cbColorPiel.SelectedItem = humano.GetColorHumano();
            }
        }
        public Humano ObtenerHumano()
        {

            return new Humano(humano.ObtenerNombre(), humano.ObtenerEdad(), humano.ObtenerCaracteristica(), humano.GetColorPelo(), humano.GetColorHumano());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.humano = new Humano(txtNombre.Text, (EEdad)cbEdad.SelectedItem, (ECaracteristica)cbCaracteristica.SelectedItem, (EColorPelo)cbColorPelo.SelectedItem, (EColorHumano)cbColorPiel.SelectedItem);
            this.DialogResult = DialogResult.OK;
        }
    }
}
