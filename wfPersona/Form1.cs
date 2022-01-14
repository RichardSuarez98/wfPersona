using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfPersona
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Contacto ContactoActual { get; set; } 

        private void txtInsertarModificar_Click(object sender, EventArgs e)
        {
            Contacto contacto = new Contacto();
            contacto.nombre = txtNombre.Text;
            contacto.edad = Convert.ToInt32(txtEdad.Text);

            

            if (ContactoActual==null)
            {
                int resultado = ContactoDAL.AgregarContacto(contacto);

                if (resultado > 0)
                {
                    MessageBox.Show("Exito al guardar");
                }
                else
                {
                    MessageBox.Show("Error al guardar");
                }
                this.borrarPantalla();
            }
            else
            {
                contacto.id = ContactoActual.id;
                int resultado = ContactoDAL.ModificarContacto(contacto);

                if (resultado > 0)
                {
                    MessageBox.Show("Exito al Modificar");
                }
                else
                {
                    MessageBox.Show("Error al Modificar");
                }
                this.borrarPantalla();

            }





        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            frmBuscar busc = new frmBuscar();
            busc.ShowDialog();

            if (busc.contactoPersonal!=null)
            {
                ContactoActual = busc.contactoPersonal;
                txtId.Text = Convert.ToString(busc.contactoPersonal.id);
                txtNombre.Text = busc.contactoPersonal.nombre;
                txtEdad.Text = Convert.ToString(busc.contactoPersonal.edad);
            }
           
        }

        public void borrarPantalla()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtEdad.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            int resultado = ContactoDAL.EliminarContacto(ContactoActual.id);
            if (resultado>0)
            {
                MessageBox.Show("Eliminado");
            }
            else
            {
                MessageBox.Show("Error al eliminar");

            }
            this.borrarPantalla();
        }
    }
}
