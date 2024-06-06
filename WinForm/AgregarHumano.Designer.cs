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
            btnAgregar = new Button();
            label5 = new Label();
            label4 = new Label();
            cbColorPelo = new ComboBox();
            cbColorPiel = new ComboBox();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.Location = new Point(51, 374);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(127, 64);
            btnAgregar.TabIndex = 13;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(61, 315);
            label5.Name = "label5";
            label5.Size = new Size(117, 16);
            label5.TabIndex = 15;
            label5.Text = "Color Piel";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Console", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(61, 266);
            label4.Name = "label4";
            label4.Size = new Size(117, 16);
            label4.TabIndex = 14;
            label4.Text = "Color Pelo";
            // 
            // cbColorPelo
            // 
            cbColorPelo.FormattingEnabled = true;
            cbColorPelo.Location = new Point(231, 264);
            cbColorPelo.Name = "cbColorPelo";
            cbColorPelo.Size = new Size(144, 23);
            cbColorPelo.TabIndex = 16;
            cbColorPelo.Text = "No_Especificado";
            // 
            // cbColorPiel
            // 
            cbColorPiel.FormattingEnabled = true;
            cbColorPiel.Location = new Point(231, 308);
            cbColorPiel.Name = "cbColorPiel";
            cbColorPiel.Size = new Size(144, 23);
            cbColorPiel.TabIndex = 17;
            cbColorPiel.Text = "No_Especificado";
            // 
            // AgregarHumano
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 463);
            Controls.Add(cbColorPiel);
            Controls.Add(cbColorPelo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnAgregar);
            Name = "AgregarHumano";
            Text = "Agregar Humano";
            Controls.SetChildIndex(btnAgregar, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(cbColorPelo, 0);
            Controls.SetChildIndex(cbColorPiel, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Label label5;
        private Label label4;
        private ComboBox cbColorPelo;
        private ComboBox cbColorPiel;
    }
}