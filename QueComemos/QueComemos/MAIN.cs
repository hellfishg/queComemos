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
    public partial class MenuPrincipal : Form {
        public MenuPrincipal() {
            InitializeComponent();
        }

        private void btn_Recetas_Click(object sender, EventArgs e) {
            //RECETA receta_form = new RECETA(this);
            this.Hide();
            //receta_form.Show();
        }

        private void btn_Comercios_Click(object sender, EventArgs e) {
            COMERCIOS comercio_form = new COMERCIOS(this);
            this.Hide();
            comercio_form.Show();
        }

        private void btn_Perfil_Click(object sender, EventArgs e) {
            //PERFIL perfil_form = new PERFIL(this);
            this.Hide();
            //perfil_form.Show();
        }

        private void btn_Datos_Click(object sender, EventArgs e) {
            //MAIN_CARGAR cargar_form = new MAIN_CARGAR(this);
            this.Hide();
            //cargar_form.Show();
        }



    }
}
