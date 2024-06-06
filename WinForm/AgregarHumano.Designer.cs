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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cbColorPiel = new ComboBox();
            label5 = new Label();
            btnAgregar = new Button();
            SuspendLayout();
            // 
            // cbColorPelo
            // 
            cbColorPelo.FormattingEnabled = true;
            cbColorPelo.Location = new Point(219, 267);
            cbColorPelo.Name = "cbColorPelo";
            cbColorPelo.Size = new Size(144, 23);
            cbColorPelo.TabIndex = 12;
            cbColorPelo.Text = "No_Especificado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(26, 274);
            label4.Name = "label4";
            label4.Size = new Size(161, 16);
            label4.TabIndex = 11;
            label4.Text = "Color de pelo:";
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
            // cbColorPiel
            // 
            cbColorPiel.FormattingEnabled = true;
            cbColorPiel.Location = new Point(219, 333);
            cbColorPiel.Name = "cbColorPiel";
            cbColorPiel.Size = new Size(144, 23);
            cbColorPiel.TabIndex = 14;
            cbColorPiel.Text = "No_Especificado";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(26, 340);
            label5.Name = "label5";
            label5.Size = new Size(161, 16);
            label5.TabIndex = 13;
            label5.Text = "Color de Piel:";
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.Location = new Point(60, 374);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(127, 64);
            btnAgregar.TabIndex = 15;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // AgregarHumano
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(467, 450);
            Controls.Add(btnAgregar);
            Controls.Add(cbColorPiel);
            Controls.Add(label5);
            Controls.Add(cbColorPelo);
            Controls.Add(label4);
            Name = "AgregarHumano";
            Text = "Agregar Humano";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbColorPelo;
        private Label label4;
        private ComboBox cbCaracteristica;
        private Label label3;
        private ComboBox cbEdad;
        private Label label2;
        private Label label1;
        private TextBox txtNombre;
        private ComboBox cbColorPiel;
        private Label label5;
        private Button btnAgregar;
    }
}