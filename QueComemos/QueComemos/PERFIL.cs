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
        string login;

        public PERFIL(MenuPrincipal ventPadre, string login) {
            InitializeComponent();

            this.ventPadre = ventPadre;
            this.login = login;
        }

        private void cargarPerfil(){
            //Carga el contenido del perfil desde el login pasado por el main.


        }

        private void button1_Click(object sender, EventArgs e) {
            //Actualizar el peso:
        }

        private void PERFIL_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();

        }
    }
}
