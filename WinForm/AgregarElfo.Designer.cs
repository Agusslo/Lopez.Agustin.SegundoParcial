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
            btnAgregar = new Button();
            label5 = new Label();
            cbEspecie = new ComboBox();
            label4 = new Label();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.Location = new Point(51, 374);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(127, 64);
            btnAgregar.TabIndex = 20;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(61, 327);
            label5.Name = "label5";
            label5.Size = new Size(106, 16);
            label5.TabIndex = 19;
            label5.Text = "Inmortal:";
            // 
            // cbEspecie
            // 
            cbEspecie.FormattingEnabled = true;
            cbEspecie.Location = new Point(231, 282);
            cbEspecie.Name = "cbEspecie";
            cbEspecie.Size = new Size(144, 23);
            cbEspecie.TabIndex = 18;
            cbEspecie.Text = "No_Especificado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(62, 289);
            label4.Name = "label4";
            label4.Size = new Size(95, 16);
            label4.TabIndex = 17;
            label4.Text = "Especie:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(237, 324);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(38, 19);
            checkBox1.TabIndex = 21;
            checkBox1.Text = "Si.";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // AgregarElfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 458);
            Controls.Add(checkBox1);
            Controls.Add(btnAgregar);
            Controls.Add(label5);
            Controls.Add(cbEspecie);
            Controls.Add(label4);
            Name = "AgregarElfo";
            Text = "Agregar Elfo";
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(cbEspecie, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(btnAgregar, 0);
            Controls.SetChildIndex(checkBox1, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Label label5;
        private ComboBox cbEspecie;
        private Label label4;
        private CheckBox checkBox1;
    }
}