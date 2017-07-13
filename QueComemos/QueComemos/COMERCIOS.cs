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
    public partial class COMERCIOS : Form {

        string consulta;

        public COMERCIOS() {
            InitializeComponent();
        }

        public void setConsulta(string busq) {
            this.consulta = busq;
            textBox1.Text = consulta;
        }

        private void button1_Click(object sender, EventArgs e) {
            BUSCAR_COMERCIO busquedaForm = new BUSCAR_COMERCIO(this);
            busquedaForm.Show();
            this.Hide();
        }
    }
}
