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
    public partial class BUSQUEDA_RECETAS : Form {

        RECETA ventPadre;
        BASE_DATOS SQL = new BASE_DATOS();
        DataTable dt;
        string consultaSql;

        public BUSQUEDA_RECETAS(RECETA ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
        }

        private void button1_Click(object sender, EventArgs e) {
            //Busqueda:
                   
            consultaSql = "SELECT Nombre_Rec as 'Receta',Tiempo_Aprox_Rec as 'Tiempo Prep.',Nombre_Tip as 'Tipo' FROM Recetas join Tipos on IdTipo_Tip = IdTipo1_Rec WHERE ";
            bool checkArgumentos = false;

            if(checkBox1.Checked) {
                consultaSql += "Nombre_Rec LIKE '%" + textBox1.Text.ToString() + "%' ";
                checkArgumentos = true;
            }
            if(checkBox2.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Nombre_Tip LIKE '%" + comboBox1.SelectedItem.ToString() + "%' ";
                checkArgumentos = true;
            }
            if(checkBox4.Checked) {
                if(checkArgumentos) { consultaSql += "AND "; }
                consultaSql += "Tiempo_Aprox_Rec <= " + textBox2.Text.ToString();
                checkArgumentos = true;
            }

            //+Falta por Precio hasta.
            if(checkBox3.Checked) {
            }

            //Busqueda de Calorias menos de:
            if(checkBox5.Checked) {
                consultaSql = "exec PROC_BUSC_CALORIAS "+textBox3.Text.ToString();
            }

            //Cargar en dataGrid:
            dt = SQL.devolverTablaDataSet(consultaSql, "Comercios");
            dataGridView1.DataSource = dt;
        }

        private void BUSQUEDA_RECETAS_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e) {
            string nombre = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            ventPadre.setConsulta(nombre);
            ventPadre.Show();
            this.Dispose();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e) {

            if(checkBox5.Checked) {
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
            } else {
                groupBox1.Enabled = true;
                groupBox3.Enabled = true;
            }
        }
    }
}
