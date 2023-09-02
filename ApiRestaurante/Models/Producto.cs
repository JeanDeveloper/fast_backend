using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.Models
{
    public class MProductoPorNombre
    {
        public Int64 iMProducto { get; set; }
        public string tDescripcion { get; set; }
        public string tObservaciones { get; set; }
        public string tUnidad { get; set; }
        public decimal iPrecioTotal { get; set; }
    }
    public class Producto
    {
    }
    public class ERPProducto
    {
        public string tProducto { get; set; }
        public int iTipo { get; set; }
    }
    public class JGRespuesta
    {
        public bool success { get; set; }
        public int status { get; set; }
        public string response { get; set; }
    }
}
