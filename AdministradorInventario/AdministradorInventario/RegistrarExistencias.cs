﻿using System;
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
    public partial class RegistrarExistencias : Form
    {
        ErrorProvider error = new ErrorProvider();
        public RegistrarExistencias()
        {
            InitializeComponent();
        }

        private void RegistrarExistencias_Load(object sender, EventArgs e)
        {

        }

        #region "Botones de ingresar y cerrar"
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarID() == false)
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
                    if (ProductoConsulta.Insertar(producto))
                    {
                        MessageBox.Show("Registro insertado exitosamente!!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error algo salio mal");
                    }
                    
                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                

            }
        }

        #endregion

        #region "Validaciones"
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
