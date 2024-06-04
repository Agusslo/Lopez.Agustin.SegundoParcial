using Entidades;

namespace WindowsForm
{
    public partial class AgregarPersonaje : Form
    {
        public AgregarPersonaje()
        {
            InitializeComponent();
            cbEdad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCaracteristica.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEdad.DataSource = Enum.GetValues(typeof(EEdad));
            cbCaracteristica.DataSource = Enum.GetValues(typeof(ECaracteristica));
        }

        private void AgregarPersonaje_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
