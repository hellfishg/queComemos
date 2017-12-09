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
        DataTable dtBackUp;

        public LISTA_DE_COMPRAS(RECETA ventPadre, DataTable dtReceta) {
            InitializeComponent();

            this.ventPadre = ventPadre;
            this.dtBackUp = dtReceta.Copy();
            this.dataGridView1.DataSource = dtBackUp;

        }

        private void LISTA_DE_COMPRAS_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e) {
            int selectedCount = dataGridView1.SelectedRows.Count;

            while(selectedCount > 0) {

                if(!dataGridView1.SelectedRows[0].IsNewRow)
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                selectedCount--;
            }
        }
    }
}
