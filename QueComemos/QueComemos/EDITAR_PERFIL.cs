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
    public partial class EDITAR_PERFIL : Form {

        string idPerfil;
        string nombre;
        string URL;
        MenuPrincipal ventPadre;
        BASE_DATOS SQL = new BASE_DATOS();


        public EDITAR_PERFIL(MenuPrincipal ventPadre, string idPerfil) {
            InitializeComponent();
            this.ventPadre = ventPadre;
            this.idPerfil = idPerfil;

            cargarFormulario();
        }

        private void cargarFormulario() {

            string consultaSQL = "SELECT Nombre_P, UrlAvatar_P FROM Perfiles WHERE IdPerfil_P ="+idPerfil;
            DataTable dt = SQL.devolverTablaDataSet(consultaSQL, "Perfil");

            textBox2.Text = dt.Rows[0][0].ToString();
            nombre = dt.Rows[0][0].ToString();
            Image avatar = Image.FromFile( dt.Rows[0][1].ToString() );
            URL = dt.Rows[0][1].ToString();
            pictureBox1.Image = avatar;

            //Cargar Recetas por perfil:
            consultaSQL = "EXEC PROC_FECHA_PERF2 " + idPerfil;
            dt = SQL.devolverTablaDataSet(consultaSQL, "Recetas");
            dataGridView1.DataSource = dt;
            
            //Cargar Pesos por fecha:
            consultaSQL = "EXEC PROC_PESO_ANUAL " + idPerfil;
            DataTable dtPeso = SQL.devolverTablaDataSet(consultaSQL, "Peso por Fecha");
            dataGridView2.DataSource = dtPeso;
        }

        private void button4_Click(object sender, EventArgs e) {
            //Actualizar Nickname:
            try {
                string sql = "Update Perfiles set ";
                sql += " Nombre_P= '" + textBox2.Text.ToString() + "'";
                sql += "WHERE IdPerfil_P = " + idPerfil;
                SQL.agregarDatosSQL(sql);
                nombre = textBox2.Text.ToString();
            } catch {
                MessageBox.Show("NickName erroneo!");
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            //Actualizar URLAvatar:

            Image file;
            

            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "2JPG(*.JPG)|*.JPG";

            if(f.ShowDialog() == DialogResult.OK) {
                file = Image.FromFile(f.FileName);
                pictureBox1.Image = file;
                URL = f.FileName;
            }
            try {
                string sql = "Update Perfiles set ";
                sql += " UrlAvatar_P= '" + URL + "'";
                sql += "WHERE IdPerfil_P = " + idPerfil;
                SQL.agregarDatosSQL(sql);
            } catch {
                MessageBox.Show("No se encuentra la Imagen!");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            //Borrar Receta seleccionada:
            
            int index = dataGridView1.SelectedCells[0].RowIndex;
            //Obtener el nombre de la receta:
            string recetaNom = dataGridView1.CurrentCell.Value.ToString();
            //Obtener la fecha de la receta:
            DateTime fechaD = Convert.ToDateTime(dataGridView1.Rows[index].Cells[1].Value.ToString());
            string fecha = fechaD.ToShortDateString();

            //Confirmacion:
            string confirmacion = MessageBox.Show("Eliminar Receta '"+recetaNom+"' "+ fecha +" de la Base de datos?", "CUIDADO!", MessageBoxButtons.OKCancel).ToString();

            if(string.Compare(confirmacion, "Ok") == 1) {

                //Obtener el Id de la receta seleccionada:
                string IdReceta = "EXEC PROC_REC_3 '" + recetaNom + "'";
                DataTable dtId = SQL.devolverTablaDataSet(IdReceta, "IdReceta");
                IdReceta = dtId.Rows[0][0].ToString();

                //Crear la consulta:
                string SQLBorrar = "DELETE FROM RecetaXFecha WHERE IdReceta_RXF = " + IdReceta + " AND ";
                SQLBorrar += "IdFecha_RXF = '" + fecha + "' AND ";
                SQLBorrar += "IdPerfil_RXF = " + idPerfil;

                SQL.agregarDatosSQL(SQLBorrar);

                MessageBox.Show("Receta Eliminada!");
                //cerrar el formulario:
                PERFIL perfil = new PERFIL(ventPadre, nombre, URL);
                perfil.Show();
                this.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            //Borrar Peso Historico Seleccionado.

            int index = dataGridView2.SelectedCells[0].RowIndex;
            //Obtener la fecha del peso:
            DateTime fechaD = Convert.ToDateTime(dataGridView2.Rows[index].Cells[0].Value.ToString());
            string fecha = fechaD.ToShortDateString();

            //Confirmacion:
            string confirmacion = MessageBox.Show("Eliminar los pesajes del "+fecha+" ?", "CUIDADO!", MessageBoxButtons.OKCancel).ToString();

            if(string.Compare(confirmacion, "Ok") == 1) {

                //Crear la consulta:
                string SQLBorrar = "DELETE FROM PesosHistoricos WHERE Fecha_PH = '" + fecha + "'";
                SQLBorrar += " AND IdPerfil_PH=" + idPerfil;

                SQL.agregarDatosSQL(SQLBorrar);

                MessageBox.Show("Pesaje Eliminado!");
                //cerrar el formulario:
                PERFIL perfil = new PERFIL(ventPadre, nombre, URL);
                perfil.Show();
                this.Dispose();
            }
        }
        private void EDITAR_PERFIL_FormClosing(object sender, FormClosingEventArgs e) {
            //cerrar el formulario:
            PERFIL perfil = new PERFIL(ventPadre, nombre, URL);
            perfil.Show();
            this.Dispose();
        }
    }
}
