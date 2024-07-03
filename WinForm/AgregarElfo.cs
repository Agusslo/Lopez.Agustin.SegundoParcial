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

        /// <summary>
        /// Carga los datos del Elfo en los controles de la ventana.
        /// </summary>
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
                cbResucitado.Checked = elfo.ObtenerResucitado();
            }
        }

        /// <summary>
        /// Obtiene el objeto Elfo actualmente configurado en la ventana.
        /// </summary>
        /// <returns>Objeto Elfo configurado con los datos actuales de la ventana.</returns>
        public Elfo ObtenerElfo()
        {
            return new Elfo(elfo.ObtenerNombre(), elfo.ObtenerEdad(), elfo.ObtenerCaracteristica(), elfo.ObtenerResucitado(), elfo.GetEspecieElfo(), elfo.GetInmortalidad());
        }

        /// <summary>
        /// el checked de inmortal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            inmortal = checkBox1.Checked;
        }

        /// <summary>
        /// carga los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            this.elfo = new Elfo(txtNombre.Text, (EEdad)cbEdad.SelectedItem, (ECaracteristica)cbCaracteristica.SelectedItem, cbResucitado.Checked, (EEspecieElfo)cbEspecie.SelectedItem, this.inmortal);
            this.DialogResult = DialogResult.OK;
        }
    }
}
