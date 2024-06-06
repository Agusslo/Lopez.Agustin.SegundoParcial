namespace WinForm
{
    partial class FrmLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAceptar = new Button();
            RTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(330, 410);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(124, 28);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click_1;
            // 
            // RTextBox
            // 
            RTextBox.Enabled = false;
            RTextBox.Location = new Point(25, 12);
            RTextBox.Name = "RTextBox";
            RTextBox.Size = new Size(449, 392);
            RTextBox.TabIndex = 3;
            RTextBox.Text = "";
            // 
            // FrmLog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(499, 450);
            Controls.Add(btnAceptar);
            Controls.Add(RTextBox);
            Name = "FrmLog";
            Text = "FRM LOG";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAceptar;
        private RichTextBox RTextBox;
    }
}