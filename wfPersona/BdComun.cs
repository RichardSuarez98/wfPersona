using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfPersona
{
    public class BdComun
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=contact;Data Source=DESKTOP-0BRL7LM\\SQLEXPRESS");
           
                conn.Open();
                return conn;
           
        }

    }
}
