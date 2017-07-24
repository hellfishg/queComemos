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
        Validar validar = new Validar();

        public BUSCAR_COMERCIO(COMERCIOS ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
        }

        private string filtro() {

            consultaSql = "SELECT Nombre_C, Dias_C, Telefono_C, Direccion_C FROM Comercios WHERE ";
            bool checkArgumentos = false;

            if(checkBox1.Checked) {
                consultaSql += "Nombre_C LIKE '%" + textBox1.Text + "%' ";
                checkArgumentos = true;
            }
            if(checkBox11.Checked ) {
                if(checkArgumentos) {consultaSql += "AND ";}
                consultaSql += "Dias_C LIKE '%l%' ";
                checkArgumentos = true;
            }
            if(checkBox2.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Dias_C LIKE '%m%' ";
                checkArgumentos = true;
            }
            if(checkBox3.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Dias_C LIKE '%i%' ";
                checkArgumentos = true;
            }
            if(checkBox4.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Dias_C LIKE '%j%' ";
                checkArgumentos = true;
            }
            if(checkBox5.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Dias_C LIKE '%v%' ";
                checkArgumentos = true;
            }
            if(checkBox6.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Dias_C LIKE '%s%' ";
                checkArgumentos = true;
            }
            if(checkBox7.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Dias_C LIKE '%d%' ";
                checkArgumentos = true;
            }

            return consultaSql;
        }

        private void cargarDataGrid() {

            try {
                dt = SQL.devolverTablaDataSet(consultaSql, "Comercios");
                dataGridView1.DataSource = dt;

            } catch {
                 
                MessageBox.Show("Seleccione al menos una busqueda");
            }
        }

        private void button1_Click(object sender, EventArgs e) {

            this.filtro();
            this.cargarDataGrid();
        }

        private void button3_Click(object sender, EventArgs e) {
            string nombre = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        
            ventPadre.setConsulta(nombre);
            ventPadre.Show();
            this.Dispose();
        }

        private void BUSCAR_COMERCIO_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }
    }
}
