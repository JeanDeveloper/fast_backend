using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.Models
{
    public class Response
    {
        public int code { get; set; }
        public string message { get; set; }
        public dynamic data { get; set; }
    }
    public class MessageOut
    {
        public Int64 MessageOut_ { get; set; }
        public string MessageResult { get; set; }
        public string MessageValue { get; set; }
        public Int64 Numero { get; set; }
        public decimal nAlto { get; set; }
        public decimal nAncho { get; set; }
        public decimal nMargenSuperior { get; set; }
        public decimal nMargenInferior { get; set; }
        public decimal nMargenIzquierdo { get; set; }
        public decimal nMargenDerecho { get; set; }
        public int iFilas { get; set; }
        public int iMinDecimales { get; set; }
        public int iMaxDecimales { get; set; }
        public Int64 iDSucursal { get; set; }
    }
}
