namespace WinForm
{
    partial class FormContraseñaRapida
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
            checkBox1 = new CheckBox();
            txtContrasenia = new TextBox();
            label2 = new Label();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(256, 75);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(42, 19);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Ver";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // txtContrasenia
            // 
            txtContrasenia.Location = new Point(107, 73);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(133, 23);
            txtContrasenia.TabIndex = 13;
            txtContrasenia.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(120, 37);
            label2.Name = "label2";
            label2.Size = new Size(88, 19);
            label2.TabIndex = 12;
            label2.Text = "Contraseña:";
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.Location = new Point(107, 117);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(128, 32);
            btnAceptar.TabIndex = 15;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FormContraseñaRapida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 196);
            Controls.Add(btnAceptar);
            Controls.Add(checkBox1);
            Controls.Add(txtContrasenia);
            Controls.Add(label2);
            Name = "FormContraseñaRapida";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private TextBox txtContrasenia;
        private Label label2;
        private Button btnAceptar;
    }
}