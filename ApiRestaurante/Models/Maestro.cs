using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiRestaurante.Models
{
    public class MTipoDocumentoIdentidad
    {
        public string iMTipoDocumentoIdentidad { get; set; }
        public string tDescripcion { get; set; }
    }

    public class MCliente
    {
        public Int64 iMCliente { get; set; }
        public string tNroDocumento { get; set; }
        public string tNombre { get; set; }
        public string tDireccion { get; set; }
        public string tCorreo { get; set; }
        public string iMTipoDocumentoIdentidad { get; set; }
        public string tTelefonoPrincipal { get; set; }
    }

    public class ClienteBuscarWSDni
    {
        public string TNroDocumento { get; set; }
        public string TNombres { get; set; }
        public string TSexo { get; set; }
        public string FFechaNacimiento { get; set; }
        public long Statuscode { get; set; }
        public long Codeerror { get; set; }
        public string Message { get; set; }
        public object Username { get; set; }
        public object Password { get; set; }
        public long StatusCode { get; set; }
        public object StatusMessage { get; set; }
    }

    public class MEmpleado
    {
        public Int64 iMEmpleado { get; set; }
        public string tNombres { get; set; }
        public int iUsuario { get; set; }
        public string tUsuario { get; set; }
        public string iMTipoDocumentoIdentidad { get; set; }
        public string descripcionDocumento { get; set; }
    }

    public class MCaja
    {
        public Int64 iMCaja { get; set; }
        public Int64 iDSucursal { get; set; }
        public string tSucursal { get; set; }
        public string tNombre { get; set; }
    }

    public class MVistaMenu1
    {
        public Int64 iMMenu { get; set; }
        public string? tModulo { get; set; }
        public string? tNombre { get; set; }
        public string? tRuta { get; set; }
        public string? tIcono { get; set; }
    }

    public class MVistaMenu2
    {
        public Int64 iMMenu { get; set; }
        public string? tModulo { get; set; }
        public string? tNombre { get; set; }
        public string? tRuta { get; set; }
        public string? tIcono { get; set; }
        public int iTipo { get; set; }
    }

    public class DConfigInpresora
    {
        public string? jsonImpresora { get; set; }
        public string? tEmpresaRuc { get; set; }
        public string? iDSucursal { get; set; }
        public string? iMUsuario { get; set; }
    }

    public class Maestro
    {
    }
}
