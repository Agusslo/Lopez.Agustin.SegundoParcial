namespace WinForm
{
    partial class AgregarHumano
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
            cbColorPelo = new ComboBox();
            label4 = new Label();
            groupBox1 = new GroupBox();
            cbCaracteristica = new ComboBox();
            label3 = new Label();
            cbEdad = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            txtNombre = new TextBox();
            cbColorPiel = new ComboBox();
            label5 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cbColorPelo
            // 
            cbColorPelo.FormattingEnabled = true;
            cbColorPelo.Location = new Point(219, 287);
            cbColorPelo.Name = "cbColorPelo";
            cbColorPelo.Size = new Size(144, 23);
            cbColorPelo.TabIndex = 12;
            cbColorPelo.Text = "No_Especificado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(26, 294);
            label4.Name = "label4";
            label4.Size = new Size(161, 16);
            label4.TabIndex = 11;
            label4.Text = "Color de pelo:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbCaracteristica);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbEdad);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Location = new Point(20, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(371, 215);
            groupBox1.TabIndex = 10;
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
            // cbColorPiel
            // 
            cbColorPiel.FormattingEnabled = true;
            cbColorPiel.Location = new Point(219, 353);
            cbColorPiel.Name = "cbColorPiel";
            cbColorPiel.Size = new Size(144, 23);
            cbColorPiel.TabIndex = 14;
            cbColorPiel.Text = "No_Especificado";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(26, 360);
            label5.Name = "label5";
            label5.Size = new Size(161, 16);
            label5.TabIndex = 13;
            label5.Text = "Color de Piel:";
            // 
            // AgregarHumano
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 450);
            Controls.Add(cbColorPiel);
            Controls.Add(label5);
            Controls.Add(cbColorPelo);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Name = "AgregarHumano";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbColorPelo;
        private Label label4;
        private GroupBox groupBox1;
        private ComboBox cbCaracteristica;
        private Label label3;
        private ComboBox cbEdad;
        private Label label2;
        private Label label1;
        private TextBox txtNombre;
        private ComboBox cbColorPiel;
        private Label label5;
    }
}