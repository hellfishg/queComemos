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
    public partial class CARGAR_PERFIL : Form {

        MAIN_CARGAR ventPadre;
        BASE_DATOS SQL = new BASE_DATOS();
        string pathImagen;
        Validar validar = new Validar();

        public CARGAR_PERFIL(MAIN_CARGAR ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
        }

        private void button1_Click(object sender, EventArgs e) {
            //guarda el perfil en la base de datos:
            bool check = true;

            if(! this.validar.validarTexBoxVacio(textBox1, e, errorProvider1)) {
                //Valida si no esta vacio textbox1:
                check = false;
            }
            if(!this.validar.validarTexBoxVacio(textBox2, e, errorProvider1)) {
                //Valida si no esta vacio textbox2:
                check = false;
            }
            if(pictureBox1.Image == null) {
                //Valida si tiene una imagen cargada:
                check = false;
            }

            if(check) {
                this.guardarParfil();
                MessageBox.Show("Perfil guardado!");

            } else {
                MessageBox.Show("Carge todos los campos");
            }
        }

        private void guardarParfil(){
            //guarda el perfil en la base de datos:
            string consultaSQL = "INSERT INTO Perfiles (Nombre_P,UrlAvatar_P) SELECT ";

            consultaSQL += "'" + textBox1.Text.ToString() + "'";
            consultaSQL += ", ";

            consultaSQL += "'" + pathImagen + "'";

            SQL.agregarDatosSQL(consultaSQL);

            //Peso inicial:

            //Busca el ID del perfil recien ingresado.
            DataTable dt2 = SQL.devolverTablaDataSet("SELECT IdPerfil_P FROM Perfiles WHERE Nombre_P LIKE '" + textBox1.Text + "%'", "Perfiles");
            DataRow fila = dt2.Rows[0];
            string IdPerfil = fila[0].ToString();

            //------------------------------------------------------------

            //Establece la fecha actual
            string fecha = DateTime.Today.ToShortDateString();

            consultaSQL = "INSERT INTO PesosHistoricos (IdPerfil_PH, Fecha_PH, Peso_PH ) SELECT ";

            consultaSQL += IdPerfil;
            consultaSQL += ", ";

            consultaSQL += "'" + fecha + "'";
            consultaSQL += ", ";

            consultaSQL += textBox2.Text;

            SQL.agregarDatosSQL(consultaSQL);

            this.limpiarFormulario();
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

        private void limpiarFormulario() {

            textBox1.Text = "";
            textBox2.Text = "";
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            //Valida que solo se ingresen numeros.
            validar.soloNumeros(e);
        }

        private void CARGAR_PERFIL_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }

    }
}
