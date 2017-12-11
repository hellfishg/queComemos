using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QueComemos {
    public partial class PERFIL : Form {

        BASE_DATOS SQL = new BASE_DATOS();
        MenuPrincipal ventPadre;
        
        string login;
        string IDperfil;
        string URLImagen;
        string fecha;

        DataTable dtLunes;
        DataTable dtMartes;
        DataTable dtMiercoles;
        DataTable dtJueves;
        DataTable dtViernes;
        DataTable dtSabado;
        DataTable dtDomingo;

        DataTable dt;

        public PERFIL(MenuPrincipal ventPadre, string login, string URLImagen) {
            InitializeComponent();

            this.ventPadre = ventPadre;
            this.login = login;
            this.URLImagen = URLImagen;

            this.buscarIdPerfil();
            this.cargarPerfil();
        }

        private void cargarPerfil(){
            //Carga el contenido del perfil desde el login pasado por el main.
            label1.Text = login;
            Image avatar = Image.FromFile(URLImagen);
            pictureBox1.Image = avatar;

            fecha = DateTime.Today.ToShortDateString();

            //Actualizar el peso de la ultima fecha.
            DataTable dtPerfil = SQL.devolverTablaDataSet("EXEC PROC_PESO_FECHA " + IDperfil, "PesoHistorico");
            DataRow fila = dtPerfil.Rows[0];
            textBox1.Text = fila[1].ToString();
            string fechaPeso = fila[0].ToString();
            string[] fechaSinHora = fechaPeso.Split(' ');
            label2.Text = fechaSinHora[0];

            
            this.cargarSemanaComidas();
            this.cargarPeso();
            this.cargarGraFicoMacronutrientes();
            tabPage9.AutoScroll = true; //Permite al grafico de dias extenderse.
            this.cargarPesoAnual(IDperfil);
            this.cargarPesoDeseado(65);//cambiar cuando este la opcion de pesoD.
        }

        private void buscarIdPerfil() {
            //Buscar el Id del perfil:
            DataTable dtPerfil = SQL.devolverTablaDataSet("SELECT IdPerfil_P FROM Perfiles WHERE Nombre_P LIKE '" + login + "%'", "Lunes");
            DataRow fila = dtPerfil.Rows[0];
            IDperfil = fila[0].ToString();
        }

        private void cargarSemanaComidas() {
            //Carga la semana de comidas.

            //busca cual es el dia lunes de esta semana.
            int restarDias = 0;
            switch(DateTime.Today.DayOfWeek.ToString()) {
                
            case "Monday":
            restarDias = 0;
            break;

            case "Tuesday":
            restarDias = -1;
            break;

            case "Wednesday":
            restarDias = -2;
            break;

            case "Thursday":
            restarDias = -3;
            break;

            case "Friday":
            restarDias = -4;
            break;

            case "Saturday":
            restarDias = -5;
            break;

            case "Sunday":
            restarDias = -6;
            break;
            }

            DateTime dya = DateTime.Today.AddDays(restarDias);
            string dia = dya.ToShortDateString();
            ////////////////////////////
            //Limpiar tabs nombres por "BUSCAR FECHA":
            tabPage1.Text = "Lunes";
            tabPage2.Text = "Martes";
            tabPage3.Text = "Miercoles";
            tabPage4.Text = "Jueves";
            tabPage5.Text = "Viernes";
            tabPage6.Text = "Sabado";
            tabPage7.Text = "Domingo";

            //////////////////////////
             //LUNES:
            
            dtLunes = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC "+ IDperfil +",'"+ dia +"'", "Lunes");
            dataGridView1.DataSource = dtLunes;
            tabPage1.Text += " " + dia;
            
            //MARTES:
            dya = DateTime.Today.AddDays((restarDias) + 1);
            dia = dya.ToShortDateString();
            dtMartes = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia + "'", "Martes");
            dataGridView2.DataSource = dtMartes;
            tabPage2.Text += " " + dia;

            //MIERCOLES:
            dya = DateTime.Today.AddDays((restarDias) + 2);
            dia = dya.ToShortDateString();
            dtMiercoles = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia + "'", "Miercoles");
            dataGridView3.DataSource = dtMiercoles;
            tabPage3.Text += " " + dia;

            //JUEVES:
            dya = DateTime.Today.AddDays((restarDias) + 3);
            dia = dya.ToShortDateString();
            dtJueves = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia + "'", "Jueves");
            dataGridView4.DataSource = dtJueves;
            tabPage4.Text += " " + dia;

            //VIERNES:
            dya = DateTime.Today.AddDays((restarDias) + 4);
            dia = dya.ToShortDateString();
            dtViernes = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia + "'", "Viernes");
            dataGridView5.DataSource = dtViernes;
            tabPage5.Text += " " + dia;

            //SABADO:
            dya = DateTime.Today.AddDays((restarDias) + 5);
            dia = dya.ToShortDateString();
            dtSabado = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia + "'", "Sabado");
            dataGridView6.DataSource = dtSabado;
            tabPage6.Text += " " + dia;

            //DOMINGO:
            dya = DateTime.Today.AddDays((restarDias) + 6);
            dia = dya.ToShortDateString();
            dtDomingo = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia + "'", "Domingo");
            dataGridView7.DataSource = dtDomingo;
            tabPage7.Text += " " + dia;
        }

        private void cargarPeso() {
            //Actualiza el peso de la ultimo pesaje.

            DataTable dtPerfil = SQL.devolverTablaDataSet("EXEC PROC_PESO_FECHA " + IDperfil, "PesoHistorico");
            DataRow fila = dtPerfil.Rows[0];
            textBox1.Text = fila[1].ToString();
            string fechaPeso = fila[0].ToString();
            string[] fechaSinHora = fechaPeso.Split(' ');
            label2.Text = fechaSinHora[0];
            this.cargarPesoAnual(IDperfil);
            this.cargarPesoDeseado(65);
        }

        private void actualizarUltimoPeso() {
            //Carga el nuevo peso:
            string consultaSQL = "INSERT INTO PesosHistoricos (IdPerfil_PH, Fecha_PH , Peso_PH) SELECT "+IDperfil+", '"+fecha+ "', "+textBox1.Text.ToString();

            SQL.agregarDatosSQL(consultaSQL);

            this.cargarPeso();
        }

        private void cargarGraFicoMacronutrientes() {

            try {
                DataTable dt = new DataTable();

                switch(tabControl1.SelectedIndex) {

                case 0:
                dt = dtLunes;
                break;

                case 1:
                dt = dtMartes;
                break;

                case 2:
                dt = dtMiercoles;
                break;

                case 3:
                dt = dtJueves;
                break;

                case 4:
                dt = dtViernes;
                break;

                case 5:
                dt = dtSabado;
                break;

                case 6:
                dt = dtDomingo;
                break;
                }

                string[] leyenda = { "Proteinas", "Carbohidratos", "Grasas" };
                int[] puntos = { 0, 0, 0 };
                
                chart1.Series.Clear();
                
                int index = dt.Rows.Count;

                DataRow fila;

                for(int i = 0; i < index; i++) {

                    fila = dt.Rows[i];

                    puntos[0] += int.Parse(fila[2].ToString());
                    puntos[1] += int.Parse(fila[3].ToString());
                    puntos[2] += int.Parse(fila[4].ToString());
                }

                Series series = new Series();

                for(int i = 0; i < puntos.Length; i++) {

                    //Titulos:
                    series = chart1.Series.Add(leyenda[i]);

                    //Cantidades:
                    series.Label = puntos[i].ToString();
                    series.Points.Add(puntos[i]);
                }

                chart1.ChartAreas[0].RecalculateAxesScale();

            } catch {

            }
        }

        private void cargarPesoAnual(string id) {
            string consultaSQL = "EXEC PROC_PESO_ANUAL " + id;
            dt = SQL.devolverTablaDataSet(consultaSQL, "Peso Historico");

            chart2.DataSource = dt;
            chart2.Series["Peso Historico"].XValueMember = "Fecha";
            chart2.Series["Peso Historico"].YValueMembers = "Peso";
            chart2.DataBind();
        }

        private void cargarPesoDeseado(int pesoD) {
            int indexMax = dt.Rows.Count;

            DateTime inicio = Convert.ToDateTime(dt.Rows[0][0].ToString());
            DateTime final = Convert.ToDateTime(dt.Rows[indexMax - 1][0].ToString());

            chart2.Series["Peso Ideal"].Points.Clear();
            chart2.Series["Peso Ideal"].Points.AddXY(inicio, pesoD);
            chart2.Series["Peso Ideal"].Points.AddXY(final, pesoD);
            chart2.DataBind();

            textBox3.Text = pesoD.ToString();
        }

        private void button1_Click(object sender, EventArgs e) {
            //Actualizar el peso del texBox1.
            this.actualizarUltimoPeso();

        }

        private void PERFIL_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e) {
            this.cargarGraFicoMacronutrientes();

        }

        private void button2_Click(object sender, EventArgs e) {
            //Editar perfil.
        }

        private void button3_Click(object sender, EventArgs e) {
            //Buscar un fecha de semana especifica.

            try {
                string diaSelc = textBox2.Text.ToString();
                DateTime dia = DateTime.Parse(diaSelc);

                //Primer Dia:
                DataTable Dia1 = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia.ToString() + "'", "Dia1");
                dataGridView1.DataSource = Dia1;
                dtLunes = Dia1;
                tabPage1.Text =  dia.ToShortDateString();
                
                //Segundo Dia:
                dia= dia.AddDays(1);
                DataTable Dia2 = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia.ToString() + "'", "Dia2");
                dataGridView2.DataSource = Dia2;
                dtMartes = Dia2;
                tabPage2.Text = dia.ToShortDateString();

                //Tercer Dia:
                dia = dia.AddDays(1);
                DataTable Dia3 = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia.ToString() + "'", "Dia3");
                dataGridView3.DataSource = Dia3;
                dtMiercoles = Dia3;
                tabPage3.Text = dia.ToShortDateString();

                //Cuarto Dia:
                dia = dia.AddDays(1);
                DataTable Dia4 = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia.ToString() + "'", "Dia4");
                dataGridView4.DataSource = Dia4;
                dtJueves = Dia4;
                tabPage4.Text = dia.ToShortDateString();

                //Quinto Dia:
                dia = dia.AddDays(1);
                DataTable Dia5 = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia.ToString() + "'", "Dia5");
                dataGridView5.DataSource = Dia5;
                dtViernes = Dia5;
                tabPage5.Text = dia.ToShortDateString();

                //Sexto Dia:
                dia = dia.AddDays(1);
                DataTable Dia6 = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia.ToString() + "'", "Dia6");
                dataGridView6.DataSource = Dia6;
                dtSabado = Dia6;
                tabPage6.Text = dia.ToShortDateString();

                //Septimo Dia:
                dia = dia.AddDays(1);
                DataTable Dia7 = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia.ToString() + "'", "Dia7");
                dataGridView7.DataSource = Dia7;
                dtDomingo = Dia7;
                tabPage7.Text = dia.ToShortDateString();
                
                cargarGraFicoMacronutrientes();

            } catch {
                MessageBox.Show("Ingrese una Fecha Valida!");
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            cargarPerfil();
        }

        private void button5_Click(object sender, EventArgs e) {
            //Seleccionar el peso ideal.

            cargarPesoDeseado( Convert.ToInt32( textBox3.Text.ToString()));
        }

        private void button2_Click_1(object sender, EventArgs e) {
            //Ir editar_perfil:
            EDITAR_PERFIL editar = new EDITAR_PERFIL(ventPadre, IDperfil);
            editar.Show();
            this.Hide();
        }
        
    }
}
