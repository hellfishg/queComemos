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
    public partial class CARGAR_INGREDIENTES : Form {

        Form ventPadre;
        
        BASE_DATOS BDSQL = new BASE_DATOS();

        public CARGAR_INGREDIENTES(Form ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
        }

        private void gruardarIngrediente() {
            string consultaSQL = "INSERT INTO Ingredientes (Nombre_Ing, IdTipo1_Ing, IdTipo2_Ing, Calorias_Ing, Proteinas_Ing, Carbohidratos_Ing, Grasas_Ing, Unidad_De_Medida_Ing, Cantidad_Ing) SELECT ";

            consultaSQL += "'" + textBox1.Text.ToString() + "'";
            consultaSQL += " ,";

            consultaSQL += this.obtenerTipo(comboBox1.SelectedItem.ToString());
            consultaSQL += " ,";

            consultaSQL += this.obtenerTipo(comboBox2.SelectedItem.ToString());
            consultaSQL += " ,";

            consultaSQL += textBox2.Text.ToString();
            consultaSQL += " ,";
            consultaSQL += textBox3.Text.ToString();
            consultaSQL += " ,";
            consultaSQL += textBox4.Text.ToString();
            consultaSQL += " ,";
            consultaSQL += textBox5.Text.ToString();
            consultaSQL += " ,";

            consultaSQL += "'" + comboBox3.SelectedItem.ToString() + "'";
            consultaSQL += " ,";
                        
            consultaSQL += textBox6.Text.ToString();

            //llamar a la base datos:
            BDSQL.agregarDatosSQL(consultaSQL);

            this.limpiarFormulario();
        }

        private void limpiarFormulario() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
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

        private void CARGAR_INGREDIENTES_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.gruardarIngrediente();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
            //Limpiar label.
            try {
                label10.Text = comboBox3.SelectedItem.ToString();
            }catch{
                label10.Text = "";
            }
        }
    }
}
