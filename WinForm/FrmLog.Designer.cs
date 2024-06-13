namespace WinForm
{
    partial class FrmLog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox RTextBox;
        private System.Windows.Forms.Button btnAceptar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.RTextBox = new System.Windows.Forms.RichTextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RTextBox
            // 
            this.RTextBox.Location = new System.Drawing.Point(12, 12);
            this.RTextBox.Name = "RTextBox";
            this.RTextBox.ReadOnly = true;
            this.RTextBox.Size = new System.Drawing.Size(360, 400);
            this.RTextBox.TabIndex = 0;
            this.RTextBox.Text = "";
            this.RTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(150, 420);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click_1);
            // 
            // FrmLog
            // 
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.RTextBox);
            this.Name = "FrmLog";
            this.Text = "Log";
            this.ResumeLayout(false);
        }
    }
}
