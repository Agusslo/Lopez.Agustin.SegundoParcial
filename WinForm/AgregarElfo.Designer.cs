namespace WinForm
{
    partial class AgregarElfo
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
            cbEspecie = new ComboBox();
            label4 = new Label();
            checkBox1 = new CheckBox();
            label5 = new Label();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // cbEspecie
            // 
            cbEspecie.FormattingEnabled = true;
            cbEspecie.Location = new Point(221, 268);
            cbEspecie.Name = "cbEspecie";
            cbEspecie.Size = new Size(144, 23);
            cbEspecie.TabIndex = 9;
            cbEspecie.Text = "No_Especificado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(28, 275);
            label4.Name = "label4";
            label4.Size = new Size(95, 16);
            label4.TabIndex = 8;
            label4.Text = "Especie:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(227, 336);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(38, 19);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Si.";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(28, 339);
            label5.Name = "label5";
            label5.Size = new Size(106, 16);
            label5.TabIndex = 10;
            label5.Text = "Inmortal:";
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.Location = new Point(88, 374);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(127, 64);
            btnAceptar.TabIndex = 12;
            btnAceptar.Text = "AGREGAR";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAgregar_Click;
            // 
            // AgregarElfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(470, 450);
            Controls.Add(btnAceptar);
            Controls.Add(checkBox1);
            Controls.Add(label5);
            Controls.Add(cbEspecie);
            Controls.Add(label4);
            Name = "AgregarElfo";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbEspecie;
        private Label label4;
        private CheckBox checkBox1;
        private Label label5;
        private Button btnAceptar;
    }
}