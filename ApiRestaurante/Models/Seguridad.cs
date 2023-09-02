using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.Models
{
    public class UsuarioApi
    {
        public Int64 iUsuarioApi { get; set; }
        public string tMessage { get; set; }
        public int iEstado { get; set; }
        public string tVersionAndroid { get; set; }
        public string tVersionIOS { get; set; }
    }
    public class Usuario
    {
        public int iMUsuario { get; set; }
        public string tUsuario { get; set; }
        public string tRol { get; set; }
        public string tEmpresaRuc { get; set; }
        public string tEmpresa { get; set; }
        public Int64 iDSucursal { get; set; }
        public string tSucursal { get; set; }
        public string tUbigeo { get; set; }
        public string tRegion { get; set; }
        public string tProvincia { get; set; }
        public string tDistrito { get; set; }
        public string tTipozona { get; set; }
        public string tDireccion { get; set; }
        public string tCodigoValidacion { get; set; }
    }
}
