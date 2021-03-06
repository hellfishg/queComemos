﻿using System;
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

            consultaSql = "SELECT Nombre_Rec as 'Receta',Tiempo_Aprox_Rec as 'Tiempo Prep.',Nombre_Tip as 'Tipo', Costo_Rec as 'Costo' FROM Recetas join Tipos on IdTipo_Tip = IdTipo1_Rec WHERE Estado_Rec = 1 ";

            if(checkBox1.Checked) {
                consultaSql += "AND Nombre_Rec LIKE '%" + textBox1.Text.ToString() + "%' ";
            }
            if(checkBox2.Checked) {
                consultaSql += "AND Nombre_Tip LIKE '%" + comboBox1.SelectedItem.ToString() + "%' ";
            }
            if(checkBox4.Checked) {
                consultaSql += "AND Tiempo_Aprox_Rec <= " + textBox2.Text.ToString();
            }
            if(checkBox3.Checked) {
                consultaSql += "AND Costo_Rec <= " + textBox4.Text.ToString();
            }

            //Busqueda de Calorias menos de:
            if(checkBox5.Checked) {
                consultaSql = "exec PROC_BUSC_CALORIAS "+textBox3.Text.ToString();
            }

            //Cargar en dataGrid:
            try {
                dt = SQL.devolverTablaDataSet(consultaSql, "Comercios");
                dataGridView1.DataSource = dt;
            } catch {
                MessageBox.Show("Active al menos un campo de busqueda");
            }
        }

        private void BUSQUEDA_RECETAS_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e) {

            try {
                string nombre = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                ventPadre.setConsulta(nombre);
                ventPadre.Show();
                this.Dispose();

           } catch {
                MessageBox.Show("Seleccione al menos una receta");
           }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e) {

            if(checkBox5.Checked) {
                groupBox1.Enabled = false;
              
            } else {
                groupBox1.Enabled = true;
            }
        }
    }
}
