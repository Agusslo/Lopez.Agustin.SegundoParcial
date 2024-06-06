namespace WinForm
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
            btnAceptar = new Button();
            label5 = new Label();
            cbEspecie = new ComboBox();
            label4 = new Label();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.Location = new Point(62, 374);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(127, 64);
            btnAceptar.TabIndex = 16;
            btnAceptar.Text = "AGREGAR";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += this.btnAgregar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(62, 326);
            label5.Name = "label5";
            label5.Size = new Size(95, 16);
            label5.TabIndex = 15;
            label5.Text = "Canibal:";
            // 
            // cbEspecie
            // 
            cbEspecie.FormattingEnabled = true;
            cbEspecie.Location = new Point(216, 262);
            cbEspecie.Name = "cbEspecie";
            cbEspecie.Size = new Size(144, 23);
            cbEspecie.TabIndex = 14;
            cbEspecie.Text = "No_Especificado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(73, 269);
            label4.Name = "label4";
            label4.Size = new Size(95, 16);
            label4.TabIndex = 13;
            label4.Text = "Especie:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(237, 323);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(38, 19);
            checkBox1.TabIndex = 17;
            checkBox1.Text = "Si.";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // AgregarOrco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(426, 444);
            Controls.Add(checkBox1);
            Controls.Add(btnAceptar);
            Controls.Add(label5);
            Controls.Add(cbEspecie);
            Controls.Add(label4);
            Name = "AgregarOrco";
            Text = "Agregar Orco";
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(cbEspecie, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(checkBox1, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Label label5;
        private ComboBox cbEspecie;
        private Label label4;
        private CheckBox checkBox1;
    }
}