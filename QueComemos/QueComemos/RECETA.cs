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
        string consulta = "SELECT IdReceta_Rec , IdTipo1_Rec, IdTipo1_Rec, Nombre_Rec, Descripcion_Rec, URLImagen_Rec, Tiempo_Aprox_Rec FROM Recetas";

        public RECETA (MenuPrincipal ventPadre) {
            InitializeComponent();
            this.ventPadre = ventPadre;

            dt = SQL.devolverTablaDataSet(consulta, "Comercios");
            cargarDatos(index);
        }

        private void cargarDatos(int i) {
            i -= 1;
            DataRow fila = dt.Rows[i];

            textBox1.Text = fila["Nombre_Rec"].ToString();
            richTextBox1.Text = fila["Descripcion_Rec"].ToString();

            label1.Text = this.obtenerTipo(fila["IdTipo1_Rec"].ToString());
            label16.Text = this.obtenerTipo(fila["IdTipo2_Rec"].ToString());

            label5.Text = fila["Tiempo_Aprox_Re"].ToString();

            //el costo se saca por los ingredientes. label6

            //MacroNutrientes

            
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

   
    }
}
