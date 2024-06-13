using System;
using System.IO;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmLog : Form
    {
        string logPath;

        public FrmLog(string logPath)
        {
            InitializeComponent();
            this.logPath = logPath;
            CargarLogs();
        }

        private void CargarLogs()
        {
            try
            {
                if (File.Exists(logPath))
                {
                    string logs = File.ReadAllText(logPath);
                    RTextBox.Text = logs;
                }
                else
                {
                    MessageBox.Show("No se encontraron logs.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los logs: {ex.Message}");
            }
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
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
