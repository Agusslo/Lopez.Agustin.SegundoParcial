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
            label4 = new Label();
            label5 = new Label();
            cbEspecie = new ComboBox();
            checkBox1 = new CheckBox();
            btnAgregar = new Button();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(18, 248);
            label4.Name = "label4";
            label4.Size = new Size(95, 16);
            label4.TabIndex = 3;
            label4.Text = "Especie:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(18, 297);
            label5.Name = "label5";
            label5.Size = new Size(95, 16);
            label5.TabIndex = 4;
            label5.Text = "Canibal:";
            // 
            // cbEspecie
            // 
            cbEspecie.FormattingEnabled = true;
            cbEspecie.Location = new Point(211, 241);
            cbEspecie.Name = "cbEspecie";
            cbEspecie.Size = new Size(144, 23);
            cbEspecie.TabIndex = 6;
            cbEspecie.Text = "No_Especificado";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(211, 294);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(38, 19);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Si.";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.Location = new Point(65, 374);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(127, 64);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // AgregarOrco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(422, 457);
            Controls.Add(btnAgregar);
            Controls.Add(checkBox1);
            Controls.Add(cbEspecie);
            Controls.Add(label5);
            Controls.Add(label4);
            Name = "AgregarOrco";
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(cbEspecie, 0);
            Controls.SetChildIndex(checkBox1, 0);
            Controls.SetChildIndex(btnAgregar, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private Label label5;
        private ComboBox cbEspecie;
        private CheckBox checkBox1;
        private Button btnAgregar;
    }
}