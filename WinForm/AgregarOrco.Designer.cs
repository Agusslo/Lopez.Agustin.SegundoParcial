﻿namespace WinForm
{
    partial class AgregarOrco
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
            groupBox1 = new GroupBox();
            txtNombre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cbEdad = new ComboBox();
            label3 = new Label();
            cbCaracteristica = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            cbEspecie = new ComboBox();
            checkBox1 = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbCaracteristica);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbEdad);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(371, 215);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(199, 35);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(144, 23);
            txtNombre.TabIndex = 0;
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
            // cbEdad
            // 
            cbEdad.FormattingEnabled = true;
            cbEdad.Location = new Point(199, 94);
            cbEdad.Name = "cbEdad";
            cbEdad.Size = new Size(144, 23);
            cbEdad.TabIndex = 3;
            cbEdad.Text = "No_Especificado";
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
            // cbCaracteristica
            // 
            cbCaracteristica.FormattingEnabled = true;
            cbCaracteristica.Location = new Point(199, 168);
            cbCaracteristica.Name = "cbCaracteristica";
            cbCaracteristica.Size = new Size(144, 23);
            cbCaracteristica.TabIndex = 5;
            cbCaracteristica.Text = "No_Especificado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(18, 273);
            label4.Name = "label4";
            label4.Size = new Size(95, 16);
            label4.TabIndex = 3;
            label4.Text = "Especie:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(18, 356);
            label5.Name = "label5";
            label5.Size = new Size(95, 16);
            label5.TabIndex = 4;
            label5.Text = "Canibal:";
            // 
            // cbEspecie
            // 
            cbEspecie.FormattingEnabled = true;
            cbEspecie.Location = new Point(211, 266);
            cbEspecie.Name = "cbEspecie";
            cbEspecie.Size = new Size(144, 23);
            cbEspecie.TabIndex = 6;
            cbEspecie.Text = "No_Especificado";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(211, 353);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(38, 19);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Si.";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 418);
            Controls.Add(checkBox1);
            Controls.Add(cbEspecie);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtNombre;
        private Label label2;
        private Label label1;
        private ComboBox cbEdad;
        private ComboBox cbCaracteristica;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cbEspecie;
        private CheckBox checkBox1;
    }
}