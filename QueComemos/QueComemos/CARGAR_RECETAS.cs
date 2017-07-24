using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueComemos {
    public partial class CARGAR_RECETAS : Form {

        MAIN_CARGAR ventPadre;
        BASE_DATOS SQL = new BASE_DATOS();
        DataTable dt;
        string pathImagen;
        Validar validar = new Validar();

        public CARGAR_RECETAS(MAIN_CARGAR ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
        }

        private void CARGAR_RECETAS_VisibleChanged(object sender, EventArgs e) {
            //Carga la lista de ingredientes y coloca el primer tipo visible.
            this.cargarListaDeIngredintes();
            this.IngredienteAtipo();
        }

        private void button5_Click(object sender, EventArgs e) {
            //Valida la carga SQL:
            bool check = true;

            if(!this.validar.validarTexBoxVacio(textBox1, e, errorProvider1)) {
                //Valida nombre
                check = false;
            }
            if(!this.validar.validarTexBoxVacio(textBox6, e, errorProvider1)) {
                //Valida costo
                check = false;
            }
            if(!this.validar.validarTexBoxVacio(textBox2, e, errorProvider1)) {
                //Valida timepo
                check = false;
            }
            if(!this.validar.validarTexBoxVacio(textBox3, e, errorProvider1)) {
                //Valida Porcion
                check = false;
            }
            if(pictureBox1.Image == null) {
                //Valida si tiene una imagen cargada:
                check = false;
            }
            if(!this.validar.validarComboBoxVacio(comboBox1, e, errorProvider1)) {
                //Valida Tipo1
                check = false;
            }
            if(!this.validar.validarComboBoxVacio(comboBox2, e, errorProvider1)) {
                //Valida tipo2
                check = false;
            }
            if(dataGridView2.RowCount == 1 ) {
                //Valida si tiene al menos un registro
                check = false;
            }
            if(check) {

                this.guardarReceta();
                MessageBox.Show("Receta guardada!");

            } else {
                MessageBox.Show("Carge todos los campos");
            }
        }

        private void guardarReceta() {
            //Guarda la receta en la base de datos.
            string consultaReceta = "INSERT INTO Recetas ( Nombre_Rec, Tiempo_Aprox_Rec, Porciones_Rec, Descripcion_Rec, IdTipo1_Rec, IdTipo2_Rec, URLImagen_Rec, Costo_Rec) SELECT ";

            consultaReceta += "'" + textBox1.Text.ToString() + "'";
            consultaReceta += ", ";

            consultaReceta += textBox2.Text.ToString();
            consultaReceta += ", ";

            consultaReceta += textBox3.Text.ToString();
            consultaReceta += ", ";

            consultaReceta += "'" + richTextBox1.Text.ToString() + "'";
            consultaReceta += ", ";

            consultaReceta += this.obtenerTipo(comboBox1.SelectedItem.ToString());
            consultaReceta += " ,";

            consultaReceta += this.obtenerTipo(comboBox2.SelectedItem.ToString());
            consultaReceta += " ,";

            //path de la imagen:
            consultaReceta += "'" + pathImagen + "'";
            consultaReceta += " ,";

            consultaReceta += textBox6.Text.ToString();

            SQL.agregarDatosSQL(consultaReceta);

            //-----------------------------
            //Cargar de ingredienteXreceta:

            DataTable dt2 = SQL.devolverTablaDataSet("SELECT IdReceta_Rec FROM Recetas WHERE Nombre_Rec LIKE '" + textBox1.Text + "%'", "Ingredientes");
            DataRow fila = dt2.Rows[0];
            string IdReceta = fila[0].ToString();

            //-------------
            string stringCargarIng = "INSERT INTO RecetaXIngrediente (IdReceta_RXI, IdIngrediente_RXI, Cantidad_RXI) SELECT ";

            //IDReceta:
            stringCargarIng += IdReceta;
            stringCargarIng += ", ";

            //IDIngrediente:
            int IdIng = int.Parse(dataGridView2.Rows[0].Cells[0].Value.ToString()) + 1;
            string idIngS = IdIng.ToString();

            stringCargarIng += idIngS;
            stringCargarIng += " ,";

            //Cantidad:
            stringCargarIng += dataGridView2.Rows[0].Cells[2].Value.ToString();

            //---------

            int index = dataGridView2.Rows.Count - 1;
            for(int i = 1; i < index; i++) {

                stringCargarIng += " UNION SELECT ";

                //IDReceta:
                stringCargarIng += IdReceta;
                stringCargarIng += ", ";

                //IDIngrediente:
                IdIng = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString()) + 1;
                idIngS = IdIng.ToString();

                stringCargarIng += idIngS;
                stringCargarIng += " ,";

                //Cantidad:
                stringCargarIng += dataGridView2.Rows[i].Cells[2].Value.ToString();
            }

            SQL.agregarDatosSQL(stringCargarIng);

            this.limpiarFormulario();
        }

        private void cargarListaDeIngredintes() {
            string consultaSql = "SELECT Nombre_Ing as Nombre FROM Ingredientes";
                        
            dt = SQL.devolverTablaDataSet(consultaSql, "Ingredientes");
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e) {
            //Agregar el ingrediente seleccionado a la lista receta.
            dataGridView2.Rows.Add(dataGridView1.CurrentCell.RowIndex.ToString(),dataGridView1.CurrentCell.Value.ToString(),textBox5.Text.ToString(), label8.Text.ToString());

            textBox5.Text = "";
        }

        private void IngredienteAtipo() {
            //Busca el tipo de unidad de medida de un ingrediente seleccionado.
            string selec = dataGridView1.CurrentCell.Value.ToString();

            DataTable dt2 = SQL.devolverTablaDataSet("SELECT Unidad_De_Medida_Ing FROM Ingredientes WHERE Nombre_Ing LIKE '" + selec + "%'", "Ingredientes");
            DataRow fila = dt2.Rows[0];

            label8.Text = fila[0].ToString();
        }

        private string obtenerTipo(string tipo) {
            string num = "0";

            switch(tipo) {
            case "":
            num = "1";
            break;
            case "Celiaco":
            num = "2";
            break;
            case "Omnivoro":
            num = "3";
            break;
            case "Vegano":
            num = "4";
            break;
            case "Vegetariano":
            num = "5";
            break;
            }
            return num;
        }

        private void limpiarFormulario() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            richTextBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

            int index = dataGridView2.Rows.Count -1;
            for(int i = 0; i < index;i++ ) {
                dataGridView2.Rows.RemoveAt(0);
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            //Coloca el tipo de unidad del ingrediente para ver.
            this.IngredienteAtipo();

        }

        private void btn_cargarImagen_Click(object sender, EventArgs e) {

            Image file;

            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "2JPG(*.JPG)|*.JPG";

            if(f.ShowDialog() == DialogResult.OK) {
                file = Image.FromFile(f.FileName);
                pictureBox1.Image = file;
                pathImagen = f.FileName;

            }
        }

        private void button4_Click(object sender, EventArgs e) {
            //Borra la fila de la lista seleccionada.
            int selectedCount = dataGridView2.SelectedRows.Count;

            while(selectedCount > 0) {

                if(!dataGridView2.SelectedRows[0].IsNewRow)
                    dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                selectedCount--;
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            //Buscar ingrediente.

            int selectedCount = dataGridView1.Rows.Count;
            
            for(int i = 1; i < selectedCount -1; i++) {
                
                if(textBox4.Text == dataGridView1.Rows[i].Cells[0].Value.ToString()) {

                    dataGridView1.Rows[i].Cells[0].Selected = true;
                    this.IngredienteAtipo();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            CARGAR_INGREDIENTES cargarI_form = new CARGAR_INGREDIENTES(this);
            this.Hide();
            cargarI_form.Show();
        }

        private void CARGAR_RECETAS_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e) {
            //valida el key costo aprox:
            validar.soloNumeros(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            //valida el key tiempo:
            validar.soloNumeros(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
            //Valida el Porcion:
            validar.soloNumeros(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e) {
            //Validar el tipo 
            validar.soloDecimal(e);
        }
    }
}
