using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmLog : System.Windows.Forms.Form
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

        protected override void OnFormClosing(FormClosingEventArgs e)//que no se buguee en el administrador de tarea
        {
            base.OnFormClosing(e);
            Application.Exit();
        }
    }
}
