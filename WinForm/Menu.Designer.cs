namespace WindowsForm
{
    partial class Menu
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
            listBox1 = new ListBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            guardarToolStripMenuItem = new ToolStripMenuItem();
            abrirToolStripMenuItem = new ToolStripMenuItem();
            configuracionToolStripMenuItem = new ToolStripMenuItem();
            verLogsToolStripMenuItem = new ToolStripMenuItem();
            elegirGuardadoToolStripMenuItem = new ToolStripMenuItem();
            xMLToolStripMenuItem = new ToolStripMenuItem();
            jSONToolStripMenuItem = new ToolStripMenuItem();
            ordenarPorToolStripMenuItem = new ToolStripMenuItem();
            edadToolStripMenuItem = new ToolStripMenuItem();
            masJovenPrimeroToolStripMenuItem = new ToolStripMenuItem();
            masAncianoPrimeroToolStripMenuItem = new ToolStripMenuItem();
            nombreToolStripMenuItem = new ToolStripMenuItem();
            ascendenteToolStripMenuItem = new ToolStripMenuItem();
            descendenteToolStripMenuItem = new ToolStripMenuItem();
            cbHumano = new CheckBox();
            cbOrco = new CheckBox();
            cbElfo = new CheckBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 27);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(607, 229);
            listBox1.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(31, 272);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(110, 40);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(271, 272);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(110, 40);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(490, 272);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(110, 40);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, configuracionToolStripMenuItem, ordenarPorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(745, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { guardarToolStripMenuItem, abrirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // guardarToolStripMenuItem
            // 
            guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            guardarToolStripMenuItem.Size = new Size(116, 22);
            guardarToolStripMenuItem.Text = "Guardar";
            guardarToolStripMenuItem.Click += guardarToolStripMenuItem_Click;
            // 
            // abrirToolStripMenuItem
            // 
            abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            abrirToolStripMenuItem.Size = new Size(116, 22);
            abrirToolStripMenuItem.Text = "Abrir";
            abrirToolStripMenuItem.Click += abrirToolStripMenuItem_Click;
            // 
            // configuracionToolStripMenuItem
            // 
            configuracionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verLogsToolStripMenuItem, elegirGuardadoToolStripMenuItem });
            configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            configuracionToolStripMenuItem.Size = new Size(95, 20);
            configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // verLogsToolStripMenuItem
            // 
            verLogsToolStripMenuItem.Name = "verLogsToolStripMenuItem";
            verLogsToolStripMenuItem.Size = new Size(157, 22);
            verLogsToolStripMenuItem.Text = "Ver logs";
            verLogsToolStripMenuItem.Click += verLogsToolStripMenuItem_Click;
            // 
            // elegirGuardadoToolStripMenuItem
            // 
            elegirGuardadoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { xMLToolStripMenuItem, jSONToolStripMenuItem });
            elegirGuardadoToolStripMenuItem.Name = "elegirGuardadoToolStripMenuItem";
            elegirGuardadoToolStripMenuItem.Size = new Size(157, 22);
            elegirGuardadoToolStripMenuItem.Text = "Elegir guardado";
            // 
            // xMLToolStripMenuItem
            // 
            xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            xMLToolStripMenuItem.Size = new Size(102, 22);
            xMLToolStripMenuItem.Text = "XML";
            xMLToolStripMenuItem.Click += xMLToolStripMenuItem_Click;
            // 
            // jSONToolStripMenuItem
            // 
            jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            jSONToolStripMenuItem.Size = new Size(102, 22);
            jSONToolStripMenuItem.Text = "JSON";
            jSONToolStripMenuItem.Click += jSONToolStripMenuItem_Click;
            // 
            // ordenarPorToolStripMenuItem
            // 
            ordenarPorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { edadToolStripMenuItem, nombreToolStripMenuItem });
            ordenarPorToolStripMenuItem.Name = "ordenarPorToolStripMenuItem";
            ordenarPorToolStripMenuItem.Size = new Size(83, 20);
            ordenarPorToolStripMenuItem.Text = "Ordenar por";
            // 
            // edadToolStripMenuItem
            // 
            edadToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { masJovenPrimeroToolStripMenuItem, masAncianoPrimeroToolStripMenuItem });
            edadToolStripMenuItem.Name = "edadToolStripMenuItem";
            edadToolStripMenuItem.Size = new Size(118, 22);
            edadToolStripMenuItem.Text = "Edad";
            // 
            // masJovenPrimeroToolStripMenuItem
            // 
            masJovenPrimeroToolStripMenuItem.Name = "masJovenPrimeroToolStripMenuItem";
            masJovenPrimeroToolStripMenuItem.Size = new Size(186, 22);
            masJovenPrimeroToolStripMenuItem.Text = "Mas joven primero";
            masJovenPrimeroToolStripMenuItem.Click += masJovenPrimeroToolStripMenuItem_Click;
            // 
            // masAncianoPrimeroToolStripMenuItem
            // 
            masAncianoPrimeroToolStripMenuItem.Name = "masAncianoPrimeroToolStripMenuItem";
            masAncianoPrimeroToolStripMenuItem.Size = new Size(186, 22);
            masAncianoPrimeroToolStripMenuItem.Text = "Mas anciano primero";
            masAncianoPrimeroToolStripMenuItem.Click += masAncianoPrimeroToolStripMenuItem_Click;
            // 
            // nombreToolStripMenuItem
            // 
            nombreToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ascendenteToolStripMenuItem, descendenteToolStripMenuItem });
            nombreToolStripMenuItem.Name = "nombreToolStripMenuItem";
            nombreToolStripMenuItem.Size = new Size(118, 22);
            nombreToolStripMenuItem.Text = "Nombre";
            // 
            // ascendenteToolStripMenuItem
            // 
            ascendenteToolStripMenuItem.Name = "ascendenteToolStripMenuItem";
            ascendenteToolStripMenuItem.Size = new Size(142, 22);
            ascendenteToolStripMenuItem.Text = "Ascendente";
            ascendenteToolStripMenuItem.Click += ascendenteToolStripMenuItem_Click;
            // 
            // descendenteToolStripMenuItem
            // 
            descendenteToolStripMenuItem.Name = "descendenteToolStripMenuItem";
            descendenteToolStripMenuItem.Size = new Size(142, 22);
            descendenteToolStripMenuItem.Text = "Descendente";
            descendenteToolStripMenuItem.Click += descendenteToolStripMenuItem_Click;
            // 
            // cbHumano
            // 
            cbHumano.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbHumano.AutoSize = true;
            cbHumano.Checked = true;
            cbHumano.CheckState = CheckState.Checked;
            cbHumano.Location = new Point(625, 64);
            cbHumano.Name = "cbHumano";
            cbHumano.Size = new Size(122, 19);
            cbHumano.TabIndex = 5;
            cbHumano.Text = "Mostrar Humanos";
            cbHumano.UseVisualStyleBackColor = true;
            // 
            // cbOrco
            // 
            cbOrco.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbOrco.AutoSize = true;
            cbOrco.Checked = true;
            cbOrco.CheckState = CheckState.Checked;
            cbOrco.Location = new Point(625, 89);
            cbOrco.Name = "cbOrco";
            cbOrco.Size = new Size(101, 19);
            cbOrco.TabIndex = 6;
            cbOrco.Text = "Mostrar Orcos";
            cbOrco.UseVisualStyleBackColor = true;
            // 
            // cbElfo
            // 
            cbElfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbElfo.AutoSize = true;
            cbElfo.Checked = true;
            cbElfo.CheckState = CheckState.Checked;
            cbElfo.Location = new Point(626, 114);
            cbElfo.Name = "cbElfo";
            cbElfo.Size = new Size(98, 19);
            cbElfo.TabIndex = 7;
            cbElfo.Text = "Mostrar Elfos ";
            cbElfo.UseVisualStyleBackColor = true;
            cbElfo.CheckedChanged += cbElfo_CheckedChanged;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(745, 324);
            Controls.Add(cbElfo);
            Controls.Add(cbOrco);
            Controls.Add(cbHumano);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(listBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MENU";
            Load += Menu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private CheckBox cbHumano;
        private CheckBox cbOrco;
        private CheckBox cbElfo;
        private ToolStripMenuItem configuracionToolStripMenuItem;
        private ToolStripMenuItem verLogsToolStripMenuItem;
        private ToolStripMenuItem elegirGuardadoToolStripMenuItem;
        private ToolStripMenuItem xMLToolStripMenuItem;
        private ToolStripMenuItem jSONToolStripMenuItem;
        private ToolStripMenuItem ordenarPorToolStripMenuItem;
        private ToolStripMenuItem edadToolStripMenuItem;
        private ToolStripMenuItem masJovenPrimeroToolStripMenuItem;
        private ToolStripMenuItem masAncianoPrimeroToolStripMenuItem;
        private ToolStripMenuItem nombreToolStripMenuItem;
        private ToolStripMenuItem ascendenteToolStripMenuItem;
        private ToolStripMenuItem descendenteToolStripMenuItem;
    }
}