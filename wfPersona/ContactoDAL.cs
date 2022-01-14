using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfPersona
{
    public class ContactoDAL
    {


        public static int AgregarContacto(Contacto contac)
        {
            int retorono = 0;
            using (SqlConnection conn= BdComun.ObtenerConexion())
            {
                string query = "insert into contactoPersonal values('"+contac.nombre+"',"+contac.edad+" )    ";
                SqlCommand comando = new SqlCommand(query,conn);
                retorono = comando.ExecuteNonQuery();
                conn.Close();
                return retorono;
            }
        }

        public static List<Contacto> BuscarContacto(string nombre)
        {
            List<Contacto> Lista = new List<Contacto>();

            using (SqlConnection conn = BdComun.ObtenerConexion())
            {
                string query = "select *from contactoPersonal Where nombre like '%"+nombre+"' ";
                SqlCommand comando = new SqlCommand(query,conn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Contacto contac = new Contacto();
                    contac.id = reader.GetInt32(0);
                    contac.nombre = reader.GetString(1);
                    contac.edad = reader.GetInt32(2);
                    Lista.Add(contac);
                }
                return Lista;
            }
        }




        public static Contacto ContactoSeleccionado(int id)
        {
            Contacto contact = new Contacto();
            using (SqlConnection conn = BdComun.ObtenerConexion())
            {
                string query = "select *from contactoPersonal where id="+id+" ";
                SqlCommand comando = new SqlCommand(query,conn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    contact.id = reader.GetInt32(0);
                    contact.nombre = reader.GetString(1);
                    contact.edad = reader.GetInt32(2);
                }
                conn.Close();
                return contact;
            }
        }




        public static int ModificarContacto(Contacto contact)
        {
            int retorno = 0;
            using (SqlConnection conn = BdComun.ObtenerConexion())
            {
                string query = "update contactoPersonal set nombre='"+contact.nombre+"' , edad="+contact.edad+" where id="+contact.id+"   ";
                SqlCommand comando = new SqlCommand(query,conn);
                retorno = comando.ExecuteNonQuery();
                conn.Close();

                return retorno;
            }

        }

        public static int EliminarContacto(int id)
        {
            int retorno = 0;
            using (SqlConnection conn = BdComun.ObtenerConexion())
            {
                string query = "delete from contactoPersonal where id="+id+" ";
                SqlCommand comando = new SqlCommand(query,conn);
                retorno = comando.ExecuteNonQuery();
                conn.Close();
                return retorno;
            }
        }





    }
}
