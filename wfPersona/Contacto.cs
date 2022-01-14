using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfPersona
{
    public class Contacto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }


        public Contacto() { }

        public Contacto(int id, string nombre, int edad)
        {
            this.id = id;
            this.nombre = nombre;
            this.edad = edad;
        }
    }
}
