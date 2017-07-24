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
        DataTable dt2;
        int index = 1;
        int indexMax;
        string consulta = "SELECT IdReceta_Rec , IdTipo1_Rec, IdTipo2_Rec, Nombre_Rec, Descripcion_Rec, URLImagen_Rec, Tiempo_Aprox_Rec, Porciones_Rec , Costo_Rec FROM Recetas";
        string perfil;

        public RECETA (MenuPrincipal ventPadre) {
            InitializeComponent();
            this.ventPadre = ventPadre;
            this.button1.Enabled = false;

            dt = SQL.devolverTablaDataSet(consulta, "Recetas");
            obtenerIndiceMaximo();
            cargarDatos(index);
        }

        public RECETA(MenuPrincipal ventPadre, string perfil) {
            InitializeComponent();
            this.ventPadre = ventPadre;
            this.perfil = perfil;

            dt = SQL.devolverTablaDataSet(consulta, "Recetas");
            obtenerIndiceMaximo();
            cargarDatos(index);
        }

        private void cargarDatos(int i) {
            i--;
            DataRow fila = dt.Rows[i];

            textBox1.Text = fila["Nombre_Rec"].ToString();
            richTextBox1.Text = fila["Descripcion_Rec"].ToString();
            label1.Text = this.obtenerTipo(fila["IdTipo1_Rec"].ToString());
            label16.Text = this.obtenerTipo(fila["IdTipo2_Rec"].ToString());
            label5.Text = fila["Tiempo_Aprox_Rec"].ToString();
            label6.Text = fila["Costo_Rec"].ToString();
            label7.Text = fila["Porciones_Rec"].ToString();
            Image file = Image.FromFile(fila["URLImagen_Rec"].ToString());
            pictureBox1.Image = file;
            

            //Cargar ingredientes:

            i++;
            String consultaIngXrec = "exec PROC_REC_1 '" + i + "'";
            dt2 = SQL.devolverTablaDataSet(consultaIngXrec, "Ingredientes");
            dataGridView1.DataSource = dt2;

            //el costo se saca por los ingredientes. label6

            //MacroNutrientes:
            DataTable dt3 = SQL.devolverTablaDataSet("exec PROC_MACRO", "Recetas");
            DataRow fila2;
            string [] matrizMacros = new string[5];
            
            fila2=dt3.Rows[index-1];

            for(int dato = 0; dato < 5; dato++) {
                matrizMacros [dato]= fila2[dato].ToString() ;
            }
            label_Calorias.Text= matrizMacros[1];
            label_Carbohidratos.Text = matrizMacros[2];
            label_Proteinas.Text = matrizMacros[3];
            label_Grasas.Text = matrizMacros[4];
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

        public void setConsulta(string recetaNombre) {
            //aca carga la consulta de busqueda_Receta:
            DataTable dt2 = SQL.devolverTablaDataSet("exec PROC_REC_3 '" + recetaNombre + "'", "Receta");
            DataRow fila = dt2.Rows[0];
            index = Convert.ToInt16(fila[0].ToString());
            cargarDatos(index);
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


        private void button5_Click(object sender, EventArgs e) {
            LISTA_DE_COMPRAS lista_form = new LISTA_DE_COMPRAS(this,dt2);
            this.Hide();
            lista_form.Show();
        }

        private void button4_Click(object sender, EventArgs e) {
            BUSQUEDA_RECETAS busquedaR_form = new BUSQUEDA_RECETAS(this);
            this.Hide();
            busquedaR_form.Show();
        }

        private void RECETA_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e) {
            //Lanza la carga de recetas al perfil.
            CARGAR_COMIDAS busquedaR_form = new CARGAR_COMIDAS(perfil,textBox1.Text);
            busquedaR_form.Show();
        }

   
    }
}
