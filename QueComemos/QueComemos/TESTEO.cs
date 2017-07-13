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
    public partial class TESTEO : Form {
        public TESTEO() {
            InitializeComponent();
            

        }

        BASE_DATOS SQL = new BASE_DATOS();
        DataTable dt;

        private void cargarDataGrid(){

            dt = SQL.devolverTablaDataSet("Select Nombre,Proteinas,Carbohidratos,Grasas from Ingredientes", "Ingredientes");
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e) {

            cargarDataGrid();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

    }
}
