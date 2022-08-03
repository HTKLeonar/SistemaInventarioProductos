using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdministradorInventario
{
    public partial class ModificarDatos : Form
    {
        ErrorProvider error = new ErrorProvider();
        public ModificarDatos()
        {
            InitializeComponent();
        }

        private void ModificarDatos_Load(object sender, EventArgs e)
        {
            MostrarDatosAlInsertar();
        }

        #region "Funcion para mostrar valores al datagrid"
        private void MostrarDatosAlInsertar()
        {
            DataTable datosTabla = ProductoConsulta.MostradoGlobal();
            if (datosTabla == null)
            {
                MessageBox.Show("No se logro accedes a los datos de la tabla");
            }
            else
            {
                dataGridView1.DataSource = datosTabla.DefaultView;
            }
        }
        #endregion

        #region "Botones de consulta, modificacion y cerrar"
        bool consultado = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidarID() == false)
            {
                return;
            }
            else
            {
                Productos producto = ProductoConsulta.Consultar(Convert.ToInt32(textBox1.Text));
                if(producto == null)
                {
                    MessageBox.Show("No existe el ID No." + textBox1.Text);
                    limpiarProductos();
                    consultado = false;
                }
                else
                {
                    textBox2.Text = producto.Clave;
                    textBox3.Text = producto.Nombre;
                    textBox4.Text = producto.Precio.ToString();
                    textBox5.Text = producto.Cantidad.ToString();
                    consultado = true;
                }
            }
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            if (consultado == false)
            {
                MessageBox.Show("Debe consultar un producto primero para modificar");
            }
            else if (ValidarID() == false)
            {
                return;
            }
            else if (ValidarClave() == false)
            {
                return;
            }
            else if (ValidarNombre() == false)
            {
                return;
            }
            else if (ValidarPrecio() == false)
            {
                return;
            }
            else if (ValidarCantidad() == false)
            {
                return;
            }
            else
            {
                try
                {
                    Productos producto = new Productos();
                    producto.ID = int.Parse(textBox1.Text);
                    producto.Clave = textBox2.Text;
                    producto.Nombre = textBox3.Text;
                    producto.Precio = Convert.ToDecimal(textBox4.Text);
                    producto.Cantidad = int.Parse(textBox5.Text);
                    if (ProductoConsulta.Actualizar(producto))
                    {
                        MostrarDatosAlInsertar();
                        limpiarProductos();
                        MessageBox.Show("Registro actualizado exitosamente!!");
                        consultado = false;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Funcion para limpiar los textbox"
        public void limpiarProductos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        #endregion

        #region "validaciones"
        private bool ValidarID()
        {
            int ID;
            if (!int.TryParse(textBox1.Text, out ID) || textBox1.Text == " ")
            {
                error.SetError(textBox1, "Ingresa valor numerico/y no lo dejes vacio");
                return false;
            }
            else
            {
                error.SetError(textBox1, "");
                return true;
            }
        }

        private bool ValidarClave()
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                error.SetError(textBox2, "No dejes vacio el campo");
                return false;
            }
            else
            {
                error.SetError(textBox2, "");
                return true;
            }
        }

        private bool ValidarNombre()
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                error.SetError(textBox3, "No dejes vacio el campo");
                return false;
            }
            else
            {
                error.SetError(textBox3, "");
                return true;
            }
        }

        private bool ValidarPrecio()
        {
            decimal Precio;
            if (!decimal.TryParse(textBox4.Text, out Precio) || textBox4.Text == " ")
            {
                error.SetError(textBox4, "Ingresa valor numerico/y no lo dejes vacio");
                return false;
            }
            else
            {
                error.SetError(textBox4, "");
                return true;
            }
        }

        private bool ValidarCantidad()
        {
            int Cantidad;
            if (!int.TryParse(textBox5.Text, out Cantidad) || textBox5.Text == " ")
            {
                error.SetError(textBox5, "Ingresa valor numerico/y no lo dejes vacio");
                return false;
            }
            else
            {
                error.SetError(textBox5, "");
                return true;
            }
        }
        #endregion
    }
}
