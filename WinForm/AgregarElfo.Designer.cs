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
            groupBox1 = new GroupBox();
            cbCaracteristica = new ComboBox();
            label3 = new Label();
            cbEdad = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            txtNombre = new TextBox();
            checkBox1 = new CheckBox();
            label5 = new Label();
            groupBox1.SuspendLayout();
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
            // groupBox1
            // 
            groupBox1.Controls.Add(cbCaracteristica);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbEdad);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Location = new Point(22, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(371, 215);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // cbCaracteristica
            // 
            cbCaracteristica.FormattingEnabled = true;
            cbCaracteristica.Location = new Point(199, 168);
            cbCaracteristica.Name = "cbCaracteristica";
            cbCaracteristica.Size = new Size(144, 23);
            cbCaracteristica.TabIndex = 5;
            cbCaracteristica.Text = "No_Especificado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(6, 170);
            label3.Name = "label3";
            label3.Size = new Size(172, 16);
            label3.TabIndex = 4;
            label3.Text = "Caracteristica:";
            // 
            // cbEdad
            // 
            cbEdad.FormattingEnabled = true;
            cbEdad.Location = new Point(199, 94);
            cbEdad.Name = "cbEdad";
            cbEdad.Size = new Size(144, 23);
            cbEdad.TabIndex = 3;
            cbEdad.Text = "No_Especificado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(23, 101);
            label2.Name = "label2";
            label2.Size = new Size(62, 16);
            label2.TabIndex = 2;
            label2.Text = "Edad:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(23, 37);
            label1.Name = "label1";
            label1.Size = new Size(84, 16);
            label1.TabIndex = 1;
            label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(199, 35);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(144, 23);
            txtNombre.TabIndex = 0;
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
            // AgregarElfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 450);
            Controls.Add(checkBox1);
            Controls.Add(label5);
            Controls.Add(cbEspecie);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Name = "AgregarElfo";
            Text = "Form2";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbEspecie;
        private Label label4;
        private GroupBox groupBox1;
        private ComboBox cbCaracteristica;
        private Label label3;
        private ComboBox cbEdad;
        private Label label2;
        private Label label1;
        private TextBox txtNombre;
        private CheckBox checkBox1;
        private Label label5;
    }
}