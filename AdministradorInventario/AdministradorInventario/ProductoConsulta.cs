using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministradorInventario
{
    class ProductoConsulta
    {
        #region "Consulta de insertar"
        public static bool Insertar(Productos e)
        {
            try
            {
                ConexionDB conexion = new ConexionDB();
                string consulta = "insert into InventarioProductos values (" + e.ID + ",'" + e.Clave + "','"+ e.Nombre + "'," + e.Precio +","+ e.Cantidad + ")";
                SqlCommand comando = new SqlCommand(consulta,conexion.conectar());

                int cantidadR = comando.ExecuteNonQuery();
                if (cantidadR == 1)
                {
                    conexion.desconectar();
                    return true;
                }
                else return false;

               
                
            }
            catch (Exception )
            {
                return false;
            }
        }
        #endregion

        #region "Consulta de mostrar"
        public static DataTable MostradoGlobal()
        {
            try
            {
                ConexionDB conexion = new ConexionDB();
                string consulta = "select *  from InventarioProductos;";
                SqlCommand comando = new SqlCommand(consulta, conexion.conectar());
                SqlDataReader dataReader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable tabla = new DataTable();
                tabla.Load(dataReader);

                conexion.desconectar();

                return tabla;
            }
            catch (Exception )
            {
                return null;
            }
        }
        #endregion

        #region "Consulta de actualizar"

        public static bool Actualizar(Productos e)
        {
            try
            {
                ConexionDB conexion = new ConexionDB();
                string consulta = "update InventarioProductos set Clave = '" + e.Clave + "', Nombre = '" + e.Nombre + "', Precio =" + e.Precio + ", Cantidad =" + e.Cantidad + "  where ID = " + e.ID + "";
                SqlCommand comando = new SqlCommand(consulta, conexion.conectar());

                int cantidadR = comando.ExecuteNonQuery();
                if (cantidadR == 1)
                {
                    conexion.desconectar();
                    return true;
                }
                else
                {
                    conexion.desconectar();
                    return false;
                }
            }
            catch (Exception )
            {
                return false;
            }
        }

        #endregion

        #region "Consulta de buscar"
        public static Productos Consultar(int ID)
        {
            try
            {
                ConexionDB conexion = new ConexionDB();
                string consulta = "select * from InventarioProductos where ID = " + ID + "";
                SqlCommand comando = new SqlCommand(consulta, conexion.conectar());
                SqlDataReader dataReader = comando.ExecuteReader();
                Productos producto = new Productos();
                if (dataReader.Read())
                {
                    producto.ID = Convert.ToInt32(dataReader["ID"].ToString());
                    producto.Clave = dataReader["Clave"].ToString();
                    producto.Nombre = dataReader["Nombre"].ToString();
                    producto.Precio = Convert.ToDecimal(dataReader["Precio"].ToString());
                    producto.Cantidad = Convert.ToInt32(dataReader["Cantidad"].ToString());
                    conexion.desconectar();
                    return producto;
                   
                }
                else
                {
                    conexion.desconectar();
                    return null;
                }

               
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}
