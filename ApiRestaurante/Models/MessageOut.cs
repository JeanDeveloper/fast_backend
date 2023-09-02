using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.Models
{
    public class SuccessMessage
    {
        public string token { get; set; }
        public string Mensaje { get; set; }
        public string error { get; set; }
        public string StatusCode { get; set; }
        public string tRazonSocial { get; set; }
    }

}
