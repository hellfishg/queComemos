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
    public partial class PERFIL : Form {

        MenuPrincipal ventPadre;

        public PERFIL(MenuPrincipal ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void PERFIL_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();

        }
    }
}
