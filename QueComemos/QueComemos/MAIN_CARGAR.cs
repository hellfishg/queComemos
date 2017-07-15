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
    public partial class MAIN_CARGAR : Form {

        MenuPrincipal ventPadre;

        public MAIN_CARGAR(MenuPrincipal ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
        }

        private void MAIN_CARGAR_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e) {
            CARGAR_RECETAS cargarR_form = new CARGAR_RECETAS(this);
            this.Hide();
            cargarR_form.Show();
        }

        private void button2_Click(object sender, EventArgs e) {
            CARGAR_INGREDIENTES cargarI_form = new CARGAR_INGREDIENTES(this);
            this.Hide();
            cargarI_form.Show();
        }

        private void button3_Click(object sender, EventArgs e) {
            CARGAR_COMERCIO cargarC_form = new CARGAR_COMERCIO(this);
            this.Hide();
            cargarC_form.Show();
        }
    }
}
