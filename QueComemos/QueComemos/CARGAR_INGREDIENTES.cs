﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueComemos {
    public partial class CARGAR_INGREDIENTES : Form {

        MAIN_CARGAR ventPadre;

        public CARGAR_INGREDIENTES(MAIN_CARGAR ventPadre) {
            InitializeComponent();

            this.ventPadre = ventPadre;
        }

        private void CARGAR_INGREDIENTES_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();
        }
    }
}
