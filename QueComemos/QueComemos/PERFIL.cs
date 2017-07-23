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
    public partial class PERFIL : Form {

        BASE_DATOS SQL = new BASE_DATOS();
        MenuPrincipal ventPadre;
        string login;
        string IDperfil;
        string URLImagen;
        string fecha;

        public PERFIL(MenuPrincipal ventPadre, string login, string URLImagen) {
            InitializeComponent();

            this.ventPadre = ventPadre;
            this.login = login;
            this.URLImagen = URLImagen;
           
            this.cargarPerfil();
        }

        private void cargarPerfil(){
            //Carga el contenido del perfil desde el login pasado por el main.

            label1.Text = login;

            Image avatar = Image.FromFile(URLImagen);
            pictureBox1.Image = avatar;

            fecha = DateTime.Today.ToShortDateString();

            this.cargarDias();
            this.cargarPeso();

        }

        private void cargarDias() {
            //Carga la semana de comidas.
            
            //Buscar el Id del perfil:
            DataTable dtPerfil = SQL.devolverTablaDataSet("SELECT IdPerfil_P FROM Perfiles WHERE Nombre_P LIKE '" + login + "%'", "Lunes");
            DataRow fila = dtPerfil.Rows[0];
            IDperfil = fila[0].ToString();

            //////////////////////////
            //busca cual es el dia lunes de esta semana.
            int restarDias = 0;

            switch(DateTime.Today.DayOfWeek.ToString()) {
                
            case "Monday":
            restarDias = 0;
            break;

            case "Tuesday":
            restarDias = -1;
            break;

            case "Wednesday":
            restarDias = -2;
            break;

            case "Thursday":
            restarDias = -3;
            break;

            case "Friday":
            restarDias = -4;
            break;

            case "Saturday":
            restarDias = -5;
            break;

            case "Sunday":
            restarDias = -6;
            break;
            }

            DateTime dya = DateTime.Today.AddDays(restarDias);
            string dia = dya.ToShortDateString();

            //////////////////////////
            //Actualizar el peso de la ultima fecha.
            dtPerfil = SQL.devolverTablaDataSet("EXEC PROC_PESO_FECHA "+ IDperfil,"PesoHistorico");
            fila = dtPerfil.Rows[0];
            textBox1.Text = fila[1].ToString();
            string fechaPeso = fila[0].ToString();
            string[] fechaSinHora = fechaPeso.Split(' ');
            label2.Text = fechaSinHora[0];            

            //////////////////////////

            //LUNES:
            DataTable dtLunes = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC "+ IDperfil +",'"+ dia +"'", "Lunes");
            dataGridView1.DataSource = dtLunes;
            tabPage1.Text += " " + dia;

            //MARTES:
            dya = DateTime.Today.AddDays((restarDias) + 1);
            dia = dya.ToShortDateString();
            DataTable dtMartes = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia + "'", "Martes");
            dataGridView2.DataSource = dtMartes;
            tabPage2.Text += " " + dia;

            //MIERCOLES:
            dya = DateTime.Today.AddDays((restarDias) + 2);
            dia = dya.ToShortDateString();
            DataTable dtMiercoles = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia + "'", "Miercoles");
            dataGridView3.DataSource = dtMiercoles;
            tabPage3.Text += " " + dia;

            //JUEVES:
            dya = DateTime.Today.AddDays((restarDias) + 3);
            dia = dya.ToShortDateString();
            DataTable dtJueves = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia + "'", "Jueves");
            dataGridView4.DataSource = dtJueves;
            tabPage4.Text += " " + dia;

            //VIERNES:
            dya = DateTime.Today.AddDays((restarDias) + 4);
            dia = dya.ToShortDateString();
            DataTable dtViernes = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia + "'", "Viernes");
            dataGridView5.DataSource = dtViernes;
            tabPage5.Text += " " + dia;

            //SABADO:
            dya = DateTime.Today.AddDays((restarDias) + 5);
            dia = dya.ToShortDateString();
            DataTable dtSabado = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia + "'", "Sabado");
            dataGridView6.DataSource = dtSabado;
            tabPage6.Text += " " + dia;

            //DOMINGO:
            dya = DateTime.Today.AddDays((restarDias) + 6);
            dia = dya.ToShortDateString();
            DataTable dtDomingo = SQL.devolverTablaDataSet("EXEC PROC_FECHA_REC " + IDperfil + ",'" + dia + "'", "Domingo");
            dataGridView7.DataSource = dtDomingo;
            tabPage7.Text += " " + dia;

        }

        private void cargarPeso() {
            //Actualiza el peso de la ultimo pesaje.

            DataTable dtPerfil = SQL.devolverTablaDataSet("EXEC PROC_PESO_FECHA " + IDperfil, "PesoHistorico");
            DataRow fila = dtPerfil.Rows[0];
            textBox1.Text = fila[1].ToString();
            string fechaPeso = fila[0].ToString();
            string[] fechaSinHora = fechaPeso.Split(' ');
            label2.Text = fechaSinHora[0];
        }

        private void actualizarUltimoPeso() {
            //Carga el nuevo peso:
            string consultaSQL = "INSERT INTO PesosHistoricos (IdPerfil_PH, Fecha_PH , Peso_PH) SELECT "+IDperfil+", '"+fecha+ "', "+textBox1.Text.ToString();

            SQL.agregarDatosSQL(consultaSQL);

            this.cargarPeso();
        }

        private void button1_Click(object sender, EventArgs e) {
            //Actualizar el peso del texBox1.
            this.actualizarUltimoPeso();

        }

        private void PERFIL_FormClosing(object sender, FormClosingEventArgs e) {
            ventPadre.Show();
            this.Dispose();

        }
    }
}
