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
    public partial class CARGAR_COMERCIO : Form {

        MAIN_CARGAR ventPadre;
        BASE_DATOS SQL = new BASE_DATOS();
        DataTable dt;
        Validar validar = new Validar();

        public CARGAR_COMERCIO(MAIN_CARGAR ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
            this.cargarListaDeIngredintes();
        }

        private void cargarListaDeIngredintes() {
            string consultaSql = "SELECT Nombre_Ing as Nombre FROM Ingredientes";

            dt = SQL.devolverTablaDataSet(consultaSql, "Ingredientes");
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e) {
            //Validar los campos vacios:
            bool check = true;

            if(!this.validar.validarTexBoxVacio(textBox1, e, errorProvider1)) {
                //Valida nombre
                check = false;
            }
            if(!this.validar.validarTexBoxVacio(textBox2, e, errorProvider1)) {
                //Valida direccion
                check = false;
            }
            if(!this.validar.validarTexBoxVacio(textBox3, e, errorProvider1)) {
                //Valida telefono
                check = false;
            }
            if(dataGridView2.RowCount == 1) {
                //Valida si tiene al menos un registro
                check = false;
            }
            if(check) {

                this.guardarComercio();
                MessageBox.Show("Comercio guardado!");

            } else {
                MessageBox.Show("Carge todos los campos");
            }

        }

        private void guardarComercio() {
            //Guarda en al base de datos:

            string consultaComercio = "INSERT INTO Comercios (Nombre_C, Direccion_C, Horario_C, Telefono_C, Dias_C) SELECT ";

            consultaComercio += "'" + textBox1.Text.ToString() + "'";
            consultaComercio += ", ";

            consultaComercio += "'" + textBox2.Text.ToString() + "'";
            consultaComercio += ", ";

            consultaComercio += "'" + richTextBox1.Text.ToString() + "'";
            consultaComercio += ", ";

            consultaComercio += "'" + textBox3.Text.ToString() + "'";
            consultaComercio += ", ";

            //Dias Abiertos
            consultaComercio += "'" + convertirDiasHabiles() + "'";

            SQL.agregarDatosSQL(consultaComercio);

            //----------------------------------------------------------
            //Cargar ingredientes especiales al comercio:

            DataTable dt2 = SQL.devolverTablaDataSet("SELECT IdComercio_C FROM Comercios WHERE Nombre_C LIKE '" + textBox1.Text + "%'", "Comercios");
            DataRow fila = dt2.Rows[0];
            string IdComercio = fila[0].ToString();
            //-----------------------------------------
            string ingXcomercio = "INSERT INTO IngredientexComercio (IdComercio_IXC, IdIngrediente_IXC, Costo_IXC) SELECT ";

            //IDComercio:
            ingXcomercio += IdComercio;
            ingXcomercio += ", ";

            //IDIngrediente:
            int IdIng = int.Parse(dataGridView2.Rows[0].Cells[0].Value.ToString()) + 1;
            string idIngS = IdIng.ToString();

            ingXcomercio += idIngS;
            ingXcomercio += " ,";

            //Costo:
            ingXcomercio += dataGridView2.Rows[0].Cells[2].Value.ToString();

            int index = dataGridView2.Rows.Count - 1;
            for(int i = 1; i < index; i++) {

                ingXcomercio += " UNION SELECT ";

                //IDComercio:
                ingXcomercio += IdComercio;
                ingXcomercio += ", ";

                //IDIngrediente:
                IdIng = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString()) + 1;
                idIngS = IdIng.ToString();

                ingXcomercio += idIngS;
                ingXcomercio += " ,";

                //Costo:
                ingXcomercio += dataGridView2.Rows[i].Cells[2].Value.ToString();
            }

            SQL.agregarDatosSQL(ingXcomercio);

        }

        private string convertirDiasHabiles() {
            //Convierte un string de referencia de los dias habiles del local.
            string cadena="";

            if(checkBox1.Checked) { cadena += "l"; } else { cadena += "0"; }
            if(checkBox2.Checked) { cadena += "m"; } else { cadena += "0"; }
            if(checkBox3.Checked) { cadena += "i"; } else { cadena += "0"; }
            if(checkBox4.Checked) { cadena += "j"; } else { cadena += "0"; }
            if(checkBox5.Checked) { cadena += "v"; } else { cadena += "0"; }
            if(checkBox6.Checked) { cadena += "s"; } else { cadena += "0"; }
            if(checkBox7.Checked) { cadena += "d"; } else { cadena += "0"; }

            return cadena;
        }

        private void button2_Click(object sender, EventArgs e) {
            //Agregar el ingrediente seleccionado a la lista receta.
            dataGridView2.Rows.Add(dataGridView1.CurrentCell.RowIndex.ToString(), dataGridView1.CurrentCell.Value.ToString(), textBox5.Text.ToString());

            textBox5.Text = "";

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

            for(int i = 1; i < selectedCount - 1; i++) {

                if(textBox4.Text == dataGridView1.Rows[i].Cells[0].Value.ToString()) {

                    dataGridView1.Rows[i].Cells[0].Selected = true;

                }
            }
        }

        private void CARGAR_COMERCIO_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e) {
            //valida el costo.

            validar.soloNumeros(e);
        }
    }

}
