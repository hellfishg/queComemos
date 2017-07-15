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

        public BUSQUEDA_RECETAS(RECETA ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
        }

        private void BUSQUEDA_RECETAS_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }
    }
}
