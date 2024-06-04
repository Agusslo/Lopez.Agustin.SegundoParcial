namespace WindowsForm
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
            label1 = new Label();
            rbtnHumano = new RadioButton();
            rbtnOrco = new RadioButton();
            rbtnElfo = new RadioButton();
            btnCancelar = new Button();
            btnSiguiente = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 0;
            label1.Text = "Elegir Especie";
            // 
            // rbtnHumano
            // 
            rbtnHumano.AutoSize = true;
            rbtnHumano.Location = new Point(57, 58);
            rbtnHumano.Name = "rbtnHumano";
            rbtnHumano.Size = new Size(72, 19);
            rbtnHumano.TabIndex = 1;
            rbtnHumano.TabStop = true;
            rbtnHumano.Text = "Humano";
            rbtnHumano.UseVisualStyleBackColor = true;
            rbtnHumano.CheckedChanged += rbtnHumano_CheckedChanged;
            // 
            // rbtnOrco
            // 
            rbtnOrco.AutoSize = true;
            rbtnOrco.Location = new Point(143, 58);
            rbtnOrco.Name = "rbtnOrco";
            rbtnOrco.Size = new Size(51, 19);
            rbtnOrco.TabIndex = 2;
            rbtnOrco.TabStop = true;
            rbtnOrco.Text = "Orco";
            rbtnOrco.UseVisualStyleBackColor = true;
            rbtnOrco.CheckedChanged += rbtnOrco_CheckedChanged;
            // 
            // rbtnElfo
            // 
            rbtnElfo.AutoSize = true;
            rbtnElfo.Location = new Point(219, 58);
            rbtnElfo.Name = "rbtnElfo";
            rbtnElfo.Size = new Size(45, 19);
            rbtnElfo.TabIndex = 3;
            rbtnElfo.TabStop = true;
            rbtnElfo.Text = "Elfo";
            rbtnElfo.UseVisualStyleBackColor = true;
            rbtnElfo.CheckedChanged += rbtnElfo_CheckedChanged;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(129, 101);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 30);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(233, 101);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(98, 30);
            btnSiguiente.TabIndex = 5;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // FrmEleccion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(341, 143);
            Controls.Add(btnSiguiente);
            Controls.Add(btnCancelar);
            Controls.Add(rbtnElfo);
            Controls.Add(rbtnOrco);
            Controls.Add(rbtnHumano);
            Controls.Add(label1);
            Name = "FrmEleccion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frm Eleccion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton rbtnHumano;
        private RadioButton rbtnOrco;
        private RadioButton rbtnElfo;
        private Button btnCancelar;
        private Button btnSiguiente;
    }
}