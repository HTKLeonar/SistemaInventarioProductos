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
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

     

        #region "Menus Modificar y Registrar"
        private void button2_Click(object sender, EventArgs e)
        {
            RegistrarExistencias registrar = new RegistrarExistencias();
            registrar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModificarDatos modificar = new ModificarDatos();
            modificar.Show();
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            //MostrarDatosAlInsertar();
        }

        #region "Mostrar Datos al DataGridView"
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

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarDatosAlInsertar();
        }
        #endregion
    }
}
