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
    public partial class CARGAR_COMIDAS : Form {

        BASE_DATOS SQL = new BASE_DATOS();
        RECETA ventPadre;
        Validar validar = new Validar();
        string login;
        string IdPerfil;
        string IdReceta;
        string fechaActual;
        string Receta;

        public CARGAR_COMIDAS(string perfil,string Receta,RECETA ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
            this.login = perfil;
            this.Receta = Receta;

            DateTime dya = DateTime.Today;
            fechaActual = dya.ToShortDateString();

            this.cargarComida();
        }

        private void cargarComida(){
            //busca el id del perfil:
            DataTable dt = SQL.devolverTablaDataSet("SELECT IdPerfil_P FROM Perfiles WHERE Nombre_P LIKE '" + login + "%'", "fecha");
            DataRow fila = dt.Rows[0];
            IdPerfil = fila[0].ToString();
            ///////////////////////////////

            //Busca el dia actual:
            DateTime dya = DateTime.Today;
            fechaActual = dya.ToShortDateString();
            ///////////////////////////////

            //Busca el Id de la receta:
            dt = SQL.devolverTablaDataSet("SELECT IdReceta_Rec FROM Recetas WHERE Nombre_Rec LIKE '" + Receta + "%'", "Receta");
            fila = dt.Rows[0];
            IdReceta = fila[0].ToString();

            ////////////////////////////////////7
            //Cargar formulario:
            label1.Text = login;
            label2.Text = Receta;
            textBox1.Text = fechaActual;

        }
        private void button1_Click(object sender, EventArgs e) {
            try {
                string consultaSQL = "INSERT INTO RecetaXFecha (IdPerfil_RXF,IdReceta_RXF,IdFecha_RXF) SELECT ";

                consultaSQL += IdPerfil;
                consultaSQL += ", ";

                consultaSQL += IdReceta;
                consultaSQL += ", ";

                consultaSQL += "'"+ textBox1.Text.ToString()+"'";
            
                SQL.agregarDatosSQL(consultaSQL);

                MessageBox.Show("Comida Guardada!");
                this.ventPadre.Show();
                this.Dispose();

            } catch {
                MessageBox.Show("Error en guardado. verifique la fecha");
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            //Que sea fecha:
            validar.soloDecimal(e);
        }

        private void CARGAR_COMIDAS_FormClosing(object sender, FormClosingEventArgs e) {
            this.ventPadre.Show();
            this.Dispose();
        }
    }
}
