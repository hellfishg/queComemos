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
    public partial class LISTA_DE_COMPRAS : Form {

        RECETA ventPadre;

        public LISTA_DE_COMPRAS(RECETA ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;

        }

        private void LISTA_DE_COMPRAS_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }
    }
}
