using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministradorInventario
{
    public class ConexionDB
    {
        SqlConnection con;

        #region "Constructor"
        public ConexionDB()
        {
            con = new SqlConnection("Server=DESKTOP-EECIKM8\\SQLEXPRESS;Database=Inventario;integrated security=true");

        }
        #endregion


        #region "Funciones conectar y desconectar del SQL"
        public SqlConnection conectar()
        {
            try
            {
                con.Open();
                return con;
            }
            catch(Exception)
            {
                return null;
            }   
        }

        public bool desconectar()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception )
            {
                return false;
            }

        }

        #endregion
    }
}
