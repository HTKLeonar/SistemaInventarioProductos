using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministradorInventario
{
    class Productos
    {
        #region "Metodos get y set de la clase"
        public int ID { get; set; } 
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        #endregion
    }
}
