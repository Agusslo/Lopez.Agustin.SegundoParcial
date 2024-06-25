namespace WinForm
{
    partial class AgregarPersonaje
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
            label4 = new Label();
            cbResucitado = new CheckBox();
            label1 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            cbEdad = new ComboBox();
            label3 = new Label();
            cbCaracteristica = new ComboBox();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cbResucitado);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbEdad);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbCaracteristica);
            groupBox1.Location = new Point(31, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(378, 253);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Console", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(52, 217);
            label4.Name = "label4";
            label4.Size = new Size(128, 16);
            label4.TabIndex = 7;
            label4.Text = "resucitado:";
            // 
            // cbResucitado
            // 
            cbResucitado.AutoSize = true;
            cbResucitado.Location = new Point(200, 217);
            cbResucitado.Name = "cbResucitado";
            cbResucitado.RightToLeft = RightToLeft.Yes;
            cbResucitado.Size = new Size(34, 19);
            cbResucitado.TabIndex = 6;
            cbResucitado.Text = "si";
            cbResucitado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Console", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(52, 53);
            label1.Name = "label1";
            label1.Size = new Size(95, 16);
            label1.TabIndex = 0;
            label1.Text = "Nombre: ";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(200, 46);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 23);
            txtNombre.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Console", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(52, 112);
            label2.Name = "label2";
            label2.Size = new Size(73, 16);
            label2.TabIndex = 1;
            label2.Text = "Edad: ";
            // 
            // cbEdad
            // 
            cbEdad.FormattingEnabled = true;
            cbEdad.Items.AddRange(new object[] { "Ninio", "Joven", "Adulto", "Anciano" });
            cbEdad.Location = new Point(200, 105);
            cbEdad.Name = "cbEdad";
            cbEdad.Size = new Size(150, 23);
            cbEdad.TabIndex = 4;
            cbEdad.Text = "No especificado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Console", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 170);
            label3.Name = "label3";
            label3.Size = new Size(194, 16);
            label3.TabIndex = 2;
            label3.Text = "Caracteristicas: ";
            // 
            // cbCaracteristica
            // 
            cbCaracteristica.Items.AddRange(new object[] { "Corto", "Mediano", "Largo" });
            cbCaracteristica.Location = new Point(200, 168);
            cbCaracteristica.Name = "cbCaracteristica";
            cbCaracteristica.Size = new Size(150, 23);
            cbCaracteristica.TabIndex = 3;
            cbCaracteristica.Text = "No especificado";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(237, 376);
            button2.Name = "button2";
            button2.Size = new Size(150, 62);
            button2.TabIndex = 11;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // AgregarPersonaje
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(441, 450);
            Controls.Add(groupBox1);
            Controls.Add(button2);
            Name = "AgregarPersonaje";
            Text = "Agregar Personaje";
            Load += AgregarPersonaje_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        protected TextBox txtNombre;
        private Label label2;
        protected ComboBox cbEdad;
        private Label label3;
        protected ComboBox cbCaracteristica;
        private Button button2;
        private CheckBox cbResucitado;
        private Label label4;
    }
}