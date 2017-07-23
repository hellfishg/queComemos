using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueComemos {
    class Validar {
        
        public bool validarTexBoxVacio(TextBox tBox, EventArgs e, ErrorProvider errorP) {
            bool validar = false;

            if(tBox.Text.Trim() == "") {

                errorP.SetError(tBox, "Este Campo no puede quedar vacio!");
                tBox.Focus();

            } else {
                errorP.Clear();
                validar = true;
            }

            return validar;
        }

        public bool validarComboBoxVacio(ComboBox tBox, EventArgs e, ErrorProvider errorP) {
            bool validar = false;

            if(tBox.Text.Trim() == "") {

                errorP.SetError(tBox, "Este Campo no puede quedar vacio!");
                tBox.Focus();

            } else {
                errorP.Clear();
                validar = true;
            }

            return validar;
        }
        
        public void soloNumeros(string campo, string nomComp, KeyPressEventArgs e) {

            try {
                
                if(char.IsNumber(e.KeyChar)) {
                    e.Handled = false;

                } else if(char.IsControl(e.KeyChar)) {
                    e.Handled = false;

                } else {
                    e.Handled = true;
                }

            } catch(Exception ex) {

                MessageBox.Show("ERROR");
            }
        }


    }
}
