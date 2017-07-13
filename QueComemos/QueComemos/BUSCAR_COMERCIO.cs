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
        public BUSCAR_COMERCIO() {
            InitializeComponent();
        }

        private string filtro() {

            string palabra = "no se";

            if(checkBox1.Checked) {

                palabra = textBox1.Text;
            }

            return palabra;
        }


        private void button1_Click(object sender, EventArgs e) {


        }
    }
}
