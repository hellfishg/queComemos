using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace QueComemos {
    class BASE_DATOS {

        string rutaNeptunoSQL = "Data Source=localhost\\sqlexpress;Initial Catalog=queComemos;Integrated Security=True";

        public DataTable devolverTablaDataSet (String ConsultaSQL, String NombreTabla) {

            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(rutaNeptunoSQL);
            SqlDataAdapter adaptador = new SqlDataAdapter(ConsultaSQL, cn);
            cn.Open();
            adaptador.Fill(ds, NombreTabla);
            cn.Close();
            return ds.Tables[NombreTabla];
        }


    }
}
