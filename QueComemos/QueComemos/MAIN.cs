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

        BASE_DATOS SQL = new BASE_DATOS();
        DataTable dt;
        int rows = 0;
        string login = "Nadie";
        string URImagen;

        public MenuPrincipal() {
            InitializeComponent();

        }

        private void agregarPerfiles() {

            pERFILLOGINToolStripMenuItem.DropDownItems.Clear();
                        
            DataRow fila;
            dt = SQL.devolverTablaDataSet("SELECT Nombre_P, UrlAvatar_P FROM Perfiles", "Perfiles");

            rows = int.Parse(dt.Rows.Count.ToString());

            for(int i = 0; i < rows; i++) {

                ToolStripItem item = new ToolStripMenuItem();
                fila = dt.Rows[i];
                item.Text = fila[0].ToString();

                pERFILLOGINToolStripMenuItem.DropDownItems.Insert(i, item);
            }
        }


        private void pERFILLOGINToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            //Establece el perfil cuando se hace click en el.

            DataRow fila;
            string nombre;

            for(int i = 0; i < rows; i++) {

                fila = dt.Rows[i];
                nombre = fila[0].ToString();

                if(nombre == e.ClickedItem.Text) {

                    URImagen = fila[1].ToString();
                    Image avatar = Image.FromFile(fila[1].ToString());
                    pictureBox1.Image = avatar;
                }
            }

            label1.Text = e.ClickedItem.Text;
            label2.Text = "CONECTADO";

            login = e.ClickedItem.Text;
        }

        private void lOGINOUTToolStripMenuItem_Click(object sender, EventArgs e) {
            //Cuando se desconecta el perfil
            login = "Nadie";
            label1.Text = "ANONIMO";
            label2.Text = "NO CONECTADO";
            pictureBox1.Image = null;

        }

        private void MenuPrincipal_VisibleChanged(object sender, EventArgs e) {
            //Cuando se hace presente:
            agregarPerfiles();
        }

        private void btn_Recetas_Click(object sender, EventArgs e) {

            if(pictureBox1.Image == null) {
                //sin perfil
                RECETA receta_form = new RECETA(this);
                this.Hide();
                receta_form.Show();

            } else {
                //Con perfil
                RECETA receta_form = new RECETA(this,login);
                this.Hide();
                receta_form.Show();
            }
        }

        private void btn_Comercios_Click(object sender, EventArgs e) {
            COMERCIOS comercio_form = new COMERCIOS(this);
            this.Hide();
            comercio_form.Show();
        }

        private void btn_Perfil_Click(object sender, EventArgs e) {

            if(pictureBox1.Image == null) {

                MessageBox.Show("Acceda a un perfil para entrar");

            }else{
                PERFIL perfil_form = new PERFIL(this,login,URImagen);
                this.Hide();
                perfil_form.Show();
            }
        }

        private void btn_Datos_Click(object sender, EventArgs e) {
            MAIN_CARGAR cargar_form = new MAIN_CARGAR(this);
            this.Hide();
            cargar_form.Show();
        }

    }
}
