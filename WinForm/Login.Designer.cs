namespace WindowsForm
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtCorreo = new TextBox();
            txtContrasenia = new TextBox();
            button1 = new Button();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 37);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 0;
            label1.Text = "Correo electronico:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 79);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "Contraseña:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(141, 34);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(133, 23);
            txtCorreo.TabIndex = 2;
            // 
            // txtContrasenia
            // 
            txtContrasenia.Location = new Point(141, 71);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(133, 23);
            txtContrasenia.TabIndex = 3;
            txtContrasenia.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.Location = new Point(85, 119);
            button1.Name = "button1";
            button1.Size = new Size(116, 23);
            button1.TabIndex = 4;
            button1.Text = "Iniciar sesión";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(280, 73);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(42, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Ver";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(331, 154);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(txtContrasenia);
            Controls.Add(txtCorreo);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGIN";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtCorreo;
        private TextBox txtContrasenia;
        private Button button1;
        private CheckBox checkBox1;
    }
}
