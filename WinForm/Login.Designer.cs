namespace WinForm
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            checkBox1 = new CheckBox();
            button1 = new Button();
            txtContrasenia = new TextBox();
            txtCorreo = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnRapido = new Button();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(300, 140);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(42, 19);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Ver";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(60, 200);
            button1.Name = "button1";
            button1.Size = new Size(128, 32);
            button1.TabIndex = 10;
            button1.Text = "Iniciar sesión";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtContrasenia
            // 
            txtContrasenia.Location = new Point(160, 140);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(133, 23);
            txtContrasenia.TabIndex = 9;
            txtContrasenia.UseSystemPasswordChar = true;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(160, 100);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(133, 23);
            txtCorreo.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(60, 140);
            label2.Name = "label2";
            label2.Size = new Size(88, 19);
            label2.TabIndex = 7;
            label2.Text = "Contraseña:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(60, 100);
            label1.Name = "label1";
            label1.Size = new Size(60, 19);
            label1.TabIndex = 6;
            label1.Text = "Correo:";
            // 
            // btnRapido
            // 
            btnRapido.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnRapido.Location = new Point(220, 200);
            btnRapido.Name = "btnRapido";
            btnRapido.Size = new Size(128, 32);
            btnRapido.TabIndex = 12;
            btnRapido.Text = "Inicio Rápido";
            btnRapido.UseVisualStyleBackColor = true;
            btnRapido.Click += btnRapido_Click_1;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(400, 300);
            Controls.Add(btnRapido);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(txtContrasenia);
            Controls.Add(txtCorreo);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private Button button1;
        private TextBox txtContrasenia;
        private TextBox txtCorreo;
        private Label label2;
        private Label label1;
        private Button btnRapido;
    }
}
