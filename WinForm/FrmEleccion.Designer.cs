namespace WinForm
{
    partial class FrmEleccion
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
            btnSiguiente = new Button();
            btnCancelar = new Button();
            rbtnElfo = new RadioButton();
            rbtnOrco = new RadioButton();
            rbtnHumano = new RadioButton();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(239, 104);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(98, 30);
            btnSiguiente.TabIndex = 11;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(135, 104);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 30);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // rbtnElfo
            // 
            rbtnElfo.AutoSize = true;
            rbtnElfo.Location = new Point(225, 61);
            rbtnElfo.Name = "rbtnElfo";
            rbtnElfo.Size = new Size(45, 19);
            rbtnElfo.TabIndex = 9;
            rbtnElfo.TabStop = true;
            rbtnElfo.Text = "Elfo";
            rbtnElfo.UseVisualStyleBackColor = true;
            rbtnElfo.CheckedChanged += rbtnElfo_CheckedChanged_1;
            // 
            // rbtnOrco
            // 
            rbtnOrco.AutoSize = true;
            rbtnOrco.Location = new Point(149, 61);
            rbtnOrco.Name = "rbtnOrco";
            rbtnOrco.Size = new Size(51, 19);
            rbtnOrco.TabIndex = 8;
            rbtnOrco.TabStop = true;
            rbtnOrco.Text = "Orco";
            rbtnOrco.UseVisualStyleBackColor = true;
            rbtnOrco.CheckedChanged += rbtnOrco_CheckedChanged_1;
            // 
            // rbtnHumano
            // 
            rbtnHumano.AutoSize = true;
            rbtnHumano.Location = new Point(63, 61);
            rbtnHumano.Name = "rbtnHumano";
            rbtnHumano.Size = new Size(72, 19);
            rbtnHumano.TabIndex = 7;
            rbtnHumano.TabStop = true;
            rbtnHumano.Text = "Humano";
            rbtnHumano.UseVisualStyleBackColor = true;
            rbtnHumano.CheckedChanged += rbtnHumano_CheckedChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 12);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 6;
            label1.Text = "Elegir Especie";
            // 
            // FrmEleccion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(366, 155);
            Controls.Add(btnSiguiente);
            Controls.Add(btnCancelar);
            Controls.Add(rbtnElfo);
            Controls.Add(rbtnOrco);
            Controls.Add(rbtnHumano);
            Controls.Add(label1);
            Name = "FrmEleccion";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSiguiente;
        private Button btnCancelar;
        private RadioButton rbtnElfo;
        private RadioButton rbtnOrco;
        private RadioButton rbtnHumano;
        private Label label1;
    }
}