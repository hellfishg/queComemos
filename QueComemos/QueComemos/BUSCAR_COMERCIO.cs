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
    public partial class BUSCAR_COMERCIO : Form {

        COMERCIOS ventPadre;
        BASE_DATOS SQL = new BASE_DATOS();
        DataTable dt;
        string consultaSql;

        public BUSCAR_COMERCIO(COMERCIOS ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
        }

        private string filtro() {

            consultaSql = "SELECT Nombre, Dias, Telefono, Direccion FROM Comercios WHERE ";
            bool checkArgumentos = false;

            if(checkBox1.Checked) {
                consultaSql += "Nombre LIKE '%" + textBox1.Text + "%' ";
                checkArgumentos = true;
            }
            if(checkBox11.Checked ) {
                if(checkArgumentos) {consultaSql += "AND ";}
                consultaSql += "Dias LIKE '%l%' ";
                checkArgumentos = true;
            }
            if(checkBox2.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Dias LIKE '%m%' ";
                checkArgumentos = true;
            }
            if(checkBox3.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Dias LIKE '%i%' ";
                checkArgumentos = true;
            }
            if(checkBox4.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Dias LIKE '%j%' ";
                checkArgumentos = true;
            }
            if(checkBox5.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Dias LIKE '%v%' ";
                checkArgumentos = true;
            }
            if(checkBox6.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Dias LIKE '%s%' ";
                checkArgumentos = true;
            }
            if(checkBox7.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Dias LIKE '%d%' ";
                checkArgumentos = true;
            }

            return consultaSql;
        }

        private void cargarDataGrid() {

            dt = SQL.devolverTablaDataSet(consultaSql, "Comercios");
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e) {

            this.filtro();
            textBox2.Text = consultaSql;
            this.cargarDataGrid();
        }

        private void button3_Click(object sender, EventArgs e) {
            string busq = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            ventPadre.setConsulta(busq);
            ventPadre.Show();
            this.Dispose();
        }
    }
}
