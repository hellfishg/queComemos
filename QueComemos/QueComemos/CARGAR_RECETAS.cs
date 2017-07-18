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

        public CARGAR_RECETAS(MAIN_CARGAR ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
            this.cargarListaDeIngredintes();
        }
        private void button5_Click(object sender, EventArgs e) {
            string consultaReceta= "INSERT INTO Recetas ( Nombre_Rec, Tiempo_Aprox_Rec, Porciones_Rec, Descripcion_Rec, IdTipo1_Rec, IdTipo2_Rec, URLImagen_Rec, SELECT )";

            string consultaIngXrec = "INSERT INTO RecetaXIngrediente (IdReceta_RXI, IdIngrediente_RXI, Cantidad_RXI SELECT )";

            consultaReceta += "'"+textBox1.Text.ToString()+"'";
            consultaReceta += ", ";

            consultaReceta += "'"+textBox2.Text.ToString()+"'";
            consultaReceta += ", ";

            consultaReceta += "'"+textBox3.Text.ToString()+"'";
            consultaReceta += ", ";

            consultaReceta += "'"+comboBox1.SelectedItem.ToString()+"'";
            consultaReceta += ", ";

            //codigo de ingreso de la imagen ver.



        }

        private void cargarListaDeIngredintes() {
            string consultaSql = "SELECT Nombre_Ing as Nombre FROM Ingredientes";
                        
            dt = SQL.devolverTablaDataSet(consultaSql, "Ingredientes");
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e) {

            dataGridView2.Rows.Add(dataGridView1.CurrentCell.Value.ToString(),textBox5.Text.ToString(), label8.Text.ToString());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            
            string selec = dataGridView1.CurrentCell.Value.ToString();

            DataTable dt2 = SQL.devolverTablaDataSet("SELECT Unidad_De_Medida_Ing FROM Ingredientes WHERE Nombre_Ing LIKE '" + selec + "%'", "Ingredientes");
            DataRow fila = dt2.Rows[0];
            
            label8.Text = fila[0].ToString();
        }

        private void CARGAR_RECETAS_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }

    
 
    }
}
