using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QueComemos {
    public partial class COMERCIOS : Form {

        MenuPrincipal ventPadre;
        BASE_DATOS SQL = new BASE_DATOS();
        DataTable dt;
        int index = 1;
        int indexMax;
        string consulta = "SELECT Nombre_C, Dias_C, Telefono_C, Direccion_C,Horario_C FROM Comercios";

        public COMERCIOS(MenuPrincipal ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
            
            dt = SQL.devolverTablaDataSet(consulta, "Comercios");
            try {
                cargarDatos(index);
                obtenerIndiceMaximo();
            } catch {
                MessageBox.Show("No hay comercion en la base");
            }
      
        }

        private void cargarDatos(int i) {
            i -=1;
            DataRow fila = dt.Rows[i];

            textBox1.Text = fila["Nombre_C"].ToString();
            textBox2.Text = fila["Direccion_C"].ToString();
            textBox3.Text = fila["Telefono_C"].ToString();
            richTextBox1.Text = fila["Horario_C"].ToString();

            string dias = fila["Dias_C"].ToString();

            if(dias[0].ToString() != "0") { checkBox1.Checked = true; }else {checkBox1.Checked=false;}
            if(dias[1].ToString() != "0") { checkBox2.Checked = true; } else { checkBox2.Checked = false; }
            if(dias[2].ToString() != "0") { checkBox3.Checked = true; } else { checkBox3.Checked = false; }
            if(dias[3].ToString() != "0") { checkBox4.Checked = true; } else { checkBox4.Checked = false; }
            if(dias[4].ToString() != "0") { checkBox5.Checked = true; } else { checkBox5.Checked = false; }
            if(dias[5].ToString() != "0") { checkBox6.Checked = true; } else { checkBox6.Checked = false; }
            if(dias[6].ToString() != "0") { checkBox7.Checked = true; } else { checkBox7.Checked = false; }

            i++;

            string consultaIngredientes = "exec PROC_COM_1 '"+i+"'";
            DataTable dt2 = SQL.devolverTablaDataSet(consultaIngredientes, "Comercios");
            dataGridView1.DataSource = dt2;
        }

        private void obtenerIndiceMaximo() {
            DataTable DatAble = SQL.devolverTablaDataSet("SELECT max(IdComercio_C) FROM Comercios", "Comercios");
            DataRow fila = DatAble.Rows[0];
            indexMax = Convert.ToInt16(fila[0].ToString());
        }

        public void setConsulta(string nombreBusqueda) {
            DataTable dt2 = SQL.devolverTablaDataSet("exec PROC_COM_2 '"+nombreBusqueda+"'", "Comercios");
            DataRow fila = dt2.Rows[0];
            index = Convert.ToInt16(fila[0].ToString());
            cargarDatos(index);
        }

        private void button1_Click(object sender, EventArgs e) {
            BUSCAR_COMERCIO busquedaForm = new BUSCAR_COMERCIO(this);
            busquedaForm.Show();
            this.Hide();
        }

        private void btn_next_Click(object sender, EventArgs e) {
            index++;
            if(index > indexMax) { index = 1; }
            cargarDatos(index);
        }

        private void btn_back_Click(object sender, EventArgs e) {
            index-=1;
            if(index < 1) { index = indexMax; }
            cargarDatos(index);
        }

        private void COMERCIOS_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }
        
    }
}
