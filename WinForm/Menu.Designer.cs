﻿namespace WinForm
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
            cbElfo = new CheckBox();
            cbOrco = new CheckBox();
            cbHumano = new CheckBox();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            listBox1 = new ListBox();
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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cbElfo
            // 
            cbElfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbElfo.AutoSize = true;
            cbElfo.Checked = true;
            cbElfo.CheckState = CheckState.Checked;
            cbElfo.Location = new Point(636, 117);
            cbElfo.Name = "cbElfo";
            cbElfo.Size = new Size(98, 19);
            cbElfo.TabIndex = 15;
            cbElfo.Text = "Mostrar Elfos ";
            cbElfo.UseVisualStyleBackColor = true;
            // 
            // cbOrco
            // 
            cbOrco.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbOrco.AutoSize = true;
            cbOrco.Checked = true;
            cbOrco.CheckState = CheckState.Checked;
            cbOrco.Location = new Point(635, 92);
            cbOrco.Name = "cbOrco";
            cbOrco.Size = new Size(101, 19);
            cbOrco.TabIndex = 14;
            cbOrco.Text = "Mostrar Orcos";
            cbOrco.UseVisualStyleBackColor = true;
            // 
            // cbHumano
            // 
            cbHumano.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbHumano.AutoSize = true;
            cbHumano.Checked = true;
            cbHumano.CheckState = CheckState.Checked;
            cbHumano.Location = new Point(635, 67);
            cbHumano.Name = "cbHumano";
            cbHumano.Size = new Size(122, 19);
            cbHumano.TabIndex = 13;
            cbHumano.Text = "Mostrar Humanos";
            cbHumano.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(490, 285);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(110, 40);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(271, 285);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(110, 40);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(31, 285);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(110, 40);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 40);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(607, 229);
            listBox1.TabIndex = 8;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, configuracionToolStripMenuItem, ordenarPorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(769, 24);
            menuStrip1.TabIndex = 12;
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
            guardarToolStripMenuItem.Size = new Size(180, 22);
            guardarToolStripMenuItem.Text = "Guardar";
            // 
            // abrirToolStripMenuItem
            // 
            abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            abrirToolStripMenuItem.Size = new Size(180, 22);
            abrirToolStripMenuItem.Text = "Abrir";
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
            // 
            // jSONToolStripMenuItem
            // 
            jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            jSONToolStripMenuItem.Size = new Size(102, 22);
            jSONToolStripMenuItem.Text = "JSON";
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
            // 
            // masAncianoPrimeroToolStripMenuItem
            // 
            masAncianoPrimeroToolStripMenuItem.Name = "masAncianoPrimeroToolStripMenuItem";
            masAncianoPrimeroToolStripMenuItem.Size = new Size(186, 22);
            masAncianoPrimeroToolStripMenuItem.Text = "Mas anciano primero";
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
            // 
            // descendenteToolStripMenuItem
            // 
            descendenteToolStripMenuItem.Name = "descendenteToolStripMenuItem";
            descendenteToolStripMenuItem.Size = new Size(142, 22);
            descendenteToolStripMenuItem.Text = "Descendente";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 363);
            Controls.Add(cbElfo);
            Controls.Add(cbOrco);
            Controls.Add(cbHumano);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(listBox1);
            Controls.Add(menuStrip1);
            Name = "Menu";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbElfo;
        private CheckBox cbOrco;
        private CheckBox cbHumano;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private ListBox listBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripMenuItem abrirToolStripMenuItem;
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