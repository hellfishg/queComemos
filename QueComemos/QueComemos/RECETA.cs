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
    public partial class RECETA : Form {

        MenuPrincipal ventPadre;
        BASE_DATOS SQL = new BASE_DATOS();
        DataTable dt;
        int index = 1;
        int indexMax;
        string consulta = "SELECT IdReceta_Rec , IdTipo1_Rec, IdTipo2_Rec, Nombre_Rec, Descripcion_Rec, URLImagen_Rec, Tiempo_Aprox_Rec, Porciones_Rec FROM Recetas";

        public RECETA (MenuPrincipal ventPadre) {
            InitializeComponent();
            this.ventPadre = ventPadre;

            dt = SQL.devolverTablaDataSet(consulta, "Recetas");
            obtenerIndiceMaximo();
            cargarDatos(index);
        }

        private void cargarDatos(int i) {
            i -= 1;
            DataRow fila = dt.Rows[i];

            textBox1.Text = fila["Nombre_Rec"].ToString();
            richTextBox1.Text = fila["Descripcion_Rec"].ToString();
            label1.Text = this.obtenerTipo(fila["IdTipo1_Rec"].ToString());
            label16.Text = this.obtenerTipo(fila["IdTipo2_Rec"].ToString());
            label5.Text = fila["Tiempo_Aprox_Rec"].ToString();
            label7.Text = fila["Porciones_Rec"].ToString();

            //Cargar ingredientes:

            i++;
            String consultaIngXrec = "exec PROC_REC_1 '" + i + "'";
            DataTable dt2 = SQL.devolverTablaDataSet(consultaIngXrec, "Ingredientes");
            dataGridView1.DataSource = dt2;

            //el costo se saca por los ingredientes. label6

            //MacroNutrientes:

            DataTable datAble;
            DataRow filaMacro;
            int macroSuma;
            int porcione_rec;

            /////////////////////////////////////////////////////////////////////////////////////
            datAble = SQL.devolverTablaDataSet("exec REC_CALORIAS '" + i + "'", "Calorias");
            filaMacro = datAble.Rows[0];
            macroSuma= Convert.ToInt16(filaMacro[0]);
            datAble = SQL.devolverTablaDataSet("exec PROC_REC_2 '" + i + "'", "Porcion");
            filaMacro = datAble.Rows[0];
            porcione_rec = Convert.ToInt16(filaMacro[0]);

            label_Calorias.Text = Convert.ToString( macroSuma/porcione_rec);
            /////////////////////////////////////////////////////////////////////////////////////
            datAble = SQL.devolverTablaDataSet("exec REC_PROTEINAS '" + i + "'", "Proteinas");
            filaMacro = datAble.Rows[0];
            macroSuma = Convert.ToInt16(filaMacro[0]);
            datAble = SQL.devolverTablaDataSet("exec PROC_REC_2 '" + i + "'", "Porcion");
            filaMacro = datAble.Rows[0];
            porcione_rec = Convert.ToInt16(filaMacro[0]);

            label_Proteinas.Text = Convert.ToString(macroSuma / porcione_rec);
            /////////////////////////////////////////////////////////////////////////////////////
            datAble = SQL.devolverTablaDataSet("exec REC_CARBOHIDRATOS '" + i + "'", "Carbohidratos");
            filaMacro = datAble.Rows[0];
            macroSuma = Convert.ToInt16(filaMacro[0]);
            datAble = SQL.devolverTablaDataSet("exec PROC_REC_2 '" + i + "'", "Porcion");
            filaMacro = datAble.Rows[0];
            porcione_rec = Convert.ToInt16(filaMacro[0]);

            label_Carbohidratos.Text = Convert.ToString(macroSuma / porcione_rec);
            /////////////////////////////////////////////////////////////////////////////////////
            datAble = SQL.devolverTablaDataSet("exec REC_GRASAS '" + i + "'", "Grasas");
            filaMacro = datAble.Rows[0];
            macroSuma = Convert.ToInt16(filaMacro[0]);
            datAble = SQL.devolverTablaDataSet("exec PROC_REC_2 '" + i + "'", "Porcion");
            filaMacro = datAble.Rows[0];
            porcione_rec = Convert.ToInt16(filaMacro[0]);

            label_Grasas.Text = Convert.ToString(macroSuma / porcione_rec);
            /////////////////////////////////////////////////////////////////////////////////////
        }

        private string obtenerTipo(string num) {
            string tipo = "";

            switch (num){
                case "1":
                    tipo = "";
                break;
                case "2":
                    tipo = "Celiaco";
                break;
                case "3":
                    tipo = "Omnivoro";
                break;
                case "4":
                    tipo = "Vegano";
                break;
                case "5":
                    tipo = "Vegetariano";
                break;
            }
            return tipo;
        }

        private void obtenerIndiceMaximo() {
            DataTable DatAble = SQL.devolverTablaDataSet("SELECT max(IdReceta_Rec) FROM Recetas", "Recetas");
            DataRow fila = DatAble.Rows[0];
            indexMax = Convert.ToInt16(fila[0].ToString());
        }

        private void label11_Click(object sender, EventArgs e) {

        }

        private void button3_Click(object sender, EventArgs e) {
            index++;
            if(index > indexMax) { index = 1; }
            cargarDatos(index);
        }

        private void button2_Click(object sender, EventArgs e) {
            index -= 1;
            if(index < 1) { index = indexMax; }
            cargarDatos(index);
        }

        private void RECETA_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }

   
    }
}
