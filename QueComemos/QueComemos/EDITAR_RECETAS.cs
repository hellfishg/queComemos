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
    public partial class EDITAR_RECETAS : Form {

        RECETA ventPadre;
        DataTable dt;
        DataTable dtIngXrec = new DataTable();
        BASE_DATOS SQL = new BASE_DATOS();
        string pathImagen;
        Validar validar = new Validar();
        int idReceta;

        public EDITAR_RECETAS(RECETA ventPadre, int index, DataTable receta, DataTable ingredientes){

            InitializeComponent();
            this.ventPadre = ventPadre;
            this.idReceta= index;


            cargarSeleccion(index, receta, ingredientes);
        }

        private void cargarSeleccion(int index, DataTable receta, DataTable ingredientes){

            //cargar datos seleccionados:
            index -= 1;
            textBox1.Text = receta.Rows[index][3].ToString();//nombre
            textBox6.Text = receta.Rows[index][8].ToString();//costo
            textBox2.Text = receta.Rows[index][6].ToString();//tiempo
            textBox3.Text = receta.Rows[index][7].ToString();//porcion
            richTextBox1.Text = receta.Rows[index][4].ToString();//descripcion

            //imagen:
            pathImagen = receta.Rows[index][5].ToString();
            Image file = Image.FromFile(pathImagen);
            pictureBox1.Image = file;

            //cargar Tipo de ingrediente:
            //Tipo1:
            int comboIndex1 = comboBox1.Items.Count;
            string tipoRec1 =  obtenerTipo2(receta.Rows[index][1].ToString());

            for(int i = 0; i < comboIndex1; i++) {
                string combo = comboBox1.Items[i].ToString();

                if(string.Compare(combo, tipoRec1) == 0) {
                    comboBox1.SelectedIndex = i;
                }
            }
            //tipo2:
            int comboIndex2 = comboBox2.Items.Count;
            string tipoRec2 = obtenerTipo2(receta.Rows[index][2].ToString());

            for(int i = 0; i < comboIndex2; i++) {
                string combo = comboBox2.Items[i].ToString();

                if(string.Compare(combo, tipoRec2) == 0) {
                    comboBox2.SelectedIndex = i;
                }
            }
            
            //cargar ingredientes en tabla:
                cargarListaDeIngredintes();

            //cargar ingredientes de la receta:
            this.dtIngXrec = ingredientes.Copy();
            dataGridView2.DataSource = dtIngXrec;
        }
        
        private string obtenerTipo2(string tipo) {
            string num = "0";

            switch(tipo) {
            case "1":
            num = "";
            break;
            case "2":
            num = "Celiaco";
            break;
            case "3":
            num = "Omnivoro";
            break;
            case "4":
            num = "Vegano";
            break;
            case "5":
            num = "Vegetariano";
            break;
            }
            return num;
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
        
        private void cargarListaDeIngredintes() {
            string consultaSql = "SELECT Nombre_Ing as Nombre FROM Ingredientes";

            dt = SQL.devolverTablaDataSet(consultaSql, "Ingredientes");
            dataGridView1.DataSource = dt;
        }
        
        private void EDITAR_RECETAS_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
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
            if(dataGridView2.RowCount == 1) {
                //Valida si tiene al menos un registro
                check = false;
            }
            if(check) {

                this.guardarReceta();
                MessageBox.Show("Receta guardada!");

                RECETA recetaRefresh = new RECETA();
                this.ventPadre = recetaRefresh;
                ventPadre.Show();
                this.Dispose();

            } else {
                MessageBox.Show("Carga de campos invalida!");
            }
        }
        
        private void guardarReceta() {
            //Guarda la receta en la base de datos.

            //Actualizar receta:
            String sql = "Update Recetas set ";
            sql += " IdTipo1_Rec=" + obtenerTipo(comboBox1.SelectedItem.ToString()) + ",";
            sql += " IdTipo2_Rec=" + obtenerTipo(comboBox2.SelectedItem.ToString()) + ",";
            sql += " Nombre_Rec= '" + textBox1.Text.ToString() + "',";
            sql += " Descripcion_Rec='" + richTextBox1.Text.ToString() + "',";
            sql += " URLImagen_Rec='" + pathImagen + "',";
            sql += " Tiempo_Aprox_Rec=" + textBox2.Text.ToString() + ",";
            sql += " Porciones_Rec=" + textBox3.Text.ToString() + ",";
            sql += " Costo_Rec=" + textBox6.Text.ToString() + ",";
            sql += " Estado_Rec=1";
            sql += " WHERE IdReceta_Rec=" + idReceta + "";

            SQL.agregarDatosSQL(sql);

            //Actualizar ingredientesXRecetas:

            //Borrar todos los ingredientes de una tabla:
            string borrarIng = "DELETE FROM RecetaXIngrediente WHERE IdReceta_RXI = " + idReceta;
            SQL.agregarDatosSQL(borrarIng);

            //Agregar ingredientes a la receta:

            string stringCargarIng = "INSERT INTO RecetaXIngrediente (IdReceta_RXI, IdIngrediente_RXI, Cantidad_RXI) SELECT ";

            //IDReceta:
            stringCargarIng += idReceta.ToString() ;
            stringCargarIng += ", ";

            string idIngS = obtenerIdIngrediente(dataGridView2.Rows[0].Cells[0].Value.ToString());

            stringCargarIng += idIngS;
            stringCargarIng += " ,";

            //Cantidad:
            string cant = dtIngXrec.Rows[0][1].ToString();
            stringCargarIng += cant.Replace(",", ".");

            //Repetir los otras cargas.

            int index = dataGridView2.Rows.Count - 1;
            for(int i = 1; i < index; i++) {

                stringCargarIng += " UNION SELECT ";

                //IDReceta:
                stringCargarIng += idReceta.ToString();
                stringCargarIng += ", ";

                idIngS = obtenerIdIngrediente(dataGridView2.Rows[i].Cells[0].Value.ToString());

                stringCargarIng += idIngS;
                stringCargarIng += " ,";

                //Cantidad:
                cant = dtIngXrec.Rows[i][1].ToString();
                stringCargarIng += cant.Replace(",", ".");
            }

            SQL.agregarDatosSQL(stringCargarIng);
        }

        private string obtenerIdIngrediente(string nombre) {
            string value;
            DataTable dti;
            string consultaIdIngred = "exec PROC_Ing '" + nombre + "'";
            dti = SQL.devolverTablaDataSet(consultaIdIngred, "Ingredientes");
            value = dti.Rows[0][0].ToString();

            return value;
        }
        
        private void button2_Click(object sender, EventArgs e) {
            //Agregar el ingrediente seleccionado a la lista receta.
            Validar validar = new Validar();
            string cantidad = textBox5.Text.ToString();

            if(this.validar.validarTexBoxVacio(textBox5, e, errorProvider1)) {
                //Valida nombre
                dtIngXrec.Rows.Add(dataGridView1.CurrentCell.Value.ToString(), cantidad, label8.Text.ToString());
                textBox5.Text = "";
            }
        }
        
        private void IngredienteAtipo() {
            //Busca el tipo de unidad de medida de un ingrediente seleccionado.
            string selec = dataGridView1.CurrentCell.Value.ToString();

            DataTable dt2 = SQL.devolverTablaDataSet("SELECT Unidad_De_Medida_Ing FROM Ingredientes WHERE Nombre_Ing LIKE '" + selec + "%'", "Ingredientes");
            DataRow fila = dt2.Rows[0];

            label8.Text = fila[0].ToString();
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

                if(!dataGridView2.SelectedRows[0].IsNewRow) {
                    dtIngXrec.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                }  
                    
                selectedCount--;
            }
        }
        
        private void button3_Click(object sender, EventArgs e) {
            //Buscar ingrediente.

            int selectedCount = dataGridView1.Rows.Count;

            for(int i = 1; i < selectedCount - 1; i++) {

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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
            validar.soloNumeros(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e) {
            validar.soloNumeros(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            validar.soloNumeros(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e) {
            validar.soloNumeros(e);
        }

        private void button6_Click(object sender, EventArgs e) {
            //Borrar receta de la base de datos:
            string confirmacion = MessageBox.Show("Eliminar Receta de la Base de datos?", "CUIDADO!", MessageBoxButtons.OKCancel).ToString();

            if(string.Compare(confirmacion, "Ok") == 1) {

                String sql = "Update Recetas set ";
                sql += " Estado_Rec=0";
                sql += " WHERE IdReceta_Rec=" + idReceta + "";
                SQL.agregarDatosSQL(sql);

                MessageBox.Show("Receta Eliminada!");
                RECETA recetaRefresh = new RECETA();
                this.ventPadre = recetaRefresh;
                ventPadre.Show();
                this.Dispose();
            }
        }
    }
}
