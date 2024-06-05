using ClassLibrary;

namespace WinForm
{
    public partial class Menu : Form
    {
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ParcialAgus");
        string path;
        string logPath;
        Coleccion personajes;
        bool GuardarEnJSON = true;
        public Menu(string logPath)
        {
            InitializeComponent();

            personajes = new Coleccion();
            this.IsMdiContainer = true;
            this.path = Path.Combine(folderPath, "configuracion");
            this.logPath = logPath;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmEleccion agregar = new FrmEleccion();
            if (agregar.ShowDialog() == DialogResult.OK)
            {
                Personaje nuevoPersonaje = agregar.SelectedPersonaje;

                try
                {
                    personajes += nuevoPersonaje;
                    ActualizarLista();
                }
                catch (ArgumentException ex) // Atrapa excepcion lanzada desde operator + de Coleccion
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string content;
            if (GuardarEnJSON)
            {
                personajes.SerializarAJson(personajes.GetColeccion(), path);
            }
            else
            {
                personajes.SerializarAXml(this.path);
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (GuardarEnJSON)
            {
                openFileDialog.Filter = "Json files(.json)|.json";
            }
            else
            {
                openFileDialog.Filter = "XML files(.xml)|.xml";
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string archivo = File.ReadAllText(filePath);

                Coleccion result;
                if (GuardarEnJSON)
                {
                    result = Coleccion.DeserializarDeJson(archivo);
                }
                else
                {
                    result = Coleccion.DeserializarDeXml(archivo);
                }
                personajes = result;
                ActualizarLista();
            }
        }
        private void Filtrar(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            if (listBox1 != null)
            {
                listBox1.Items.Clear();
                var filteredpersonajes = personajes.FiltrarPorTipos(cbHumano.Checked, cbOrco.Checked, cbElfo.Checked);
                foreach (var personaje in filteredpersonajes)
                {
                    listBox1.Items.Add(personaje);
                }
            }
        }

        private void verLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLog logsForm = new FrmLog(this.logPath);
            logsForm.ShowDialog();
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.GuardarEnJSON = false;
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.GuardarEnJSON = true;
        }

        private void masJovenPrimeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personajes.OrdenarPorEdad(ascendente: true);
            ActualizarLista();
        }

        private void masAncianoPrimeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personajes.OrdenarPorEdad(ascendente: false);
            ActualizarLista();
        }

        private void ascendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personajes.OrdenarPorNombre(true);
            ActualizarLista();
        }

        private void descendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personajes.OrdenarPorNombre(false);
            ActualizarLista();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Personaje personajeseleccionado = listBox1.SelectedItem as Personaje;
                System.Windows.Forms.Form modificarForm;
                if (personajeseleccionado is Elfo elfoSeleccionado)
                {
                    modificarForm = new AgregarElfo(elfoSeleccionado); //TENGO ERRRORES EN TODOS ESTOS ASI QUE VOY A CREAR EL RESTO DE LOS FORM PRIMERO PROFESORES
                }
                else if (personajeseleccionado is Orco orcoSeleccionado)
                {
                    modificarForm = new AgregarOrco(orcoSeleccionado);
                }
                else if (personajeseleccionado is Humano humanoSeleccionado)
                {
                    modificarForm = new AgregarHumano(humanoSeleccionado);

                }
                else
                {
                    throw new Exception("Tipo de carnívoro no soportado."); // Si no, tira error con modificarForm
                }

                if (modificarForm != null && modificarForm.ShowDialog() == DialogResult.OK)
                {
                    personajes -= personajeseleccionado; // Se elimina el carnivoro seleccionado
                    if (modificarForm is AgregarElfo)
                    {
                        personajes += (modificarForm as AgregarElfo).ObtenerElfo(); // Agregar elfo
                    }
                    else if (modificarForm is AgregarOrco)
                    {
                        personajes += (modificarForm as AgregarOrco).ObtenerOrco(); // Agregar orco
                    }
                    else if (modificarForm is AgregarHumano)
                    {
                        personajes += (modificarForm as AgregarHumano).ObtenerHumano(); // o agregar humano
                    }

                    ActualizarLista(); // Actualizar
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un personaje para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void cbElfo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
