using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.Models
{
    public class MCiudad
    {
        public int iMCiudad { get; set; }
        public string tDescripcion { get; set; }
    }

    public class DProgramacion
    {
        public string fHoraSalida { get; set; }
        public string tServicio { get; set; }
        public int iCapacidad { get; set; }
        public string tRuta { get; set; }
        public string tFecha { get; set; }
        public string tPrecio { get; set; }
        public Int64 iDProgramacion { get; set; }
        public Int64 iDProgramacionFecha { get; set; }
        public int iNumeroViaje { get; set; }
        public Int64 iMModeloTransporte { get; set; }
        public string tPlaca { get; set; }
    }

    public class MVehiculo
    {
        public int iTipo { get; set; }
        public int inivel { get; set; }
        public int iColumna { get; set; }
        public int iFila { get; set; }
        public int iAsiento { get; set; }
        public int iEstado { get; set; }
        public decimal iPrecio { get; set; }
        public Int64 iMVentaTransporte { get; set; }
        public string tColor { get; set; }
    }

    public class BoletoReservaAnular
    {
        public string tEmpresaRuc { get; set; }
        public Int64 iMVentaTransporte { get; set; }
    }

    public class BoletoAnular
    {
        public Int64 iMVentaTransporte { get; set; }
    }

    public class MBoletoDetalle
    {
        public Int64 iMPasajero { get; set; }
        public String tPasajeroDoc { get; set; }
        public String tPasajeroTipoDoc { get; set; }
        public String tPasajero { get; set; }
        public String tFechaViaje { get; set; }
        public String tHoraViaje { get; set; }

        public Int64 iDProgramacion { get; set; }
        public Int64 iDProgramacionFecha { get; set; }
        public Int64 iDProgramacionPrecio { get; set; }
        public string tUbicacionPdf { get; set; }
        public decimal? nDescuento { get; set; }
        public int? iMCodigoVenta { get; set; }
        public decimal? nPrecio { get; set; }
        public decimal? nTotalPagar { get; set; }
        public bool? lVentaGratuita { get; set; }
        public string tSerie { get; set; }
        public string tNumero { get; set; }
        public string tRuta { get; set; }
    }

    public class VentaBoleto
    {
        public Int64? iMVentaTransporte { get; set; }
        public string tEmpresaRuc { get; set; }
        public Int64? iMCliente { get; set; }
        public string? tClienteDoc { get; set; }
        public string? tCliente { get; set; }
        public string? tClienteDir { get; set; }
        public Int64 iMPasajero { get; set; }
        public string? iMPasajeroTipoDoc { get; set; }
        public string? tPasajeroDoc { get; set; }
        public string? tPasajero { get; set; }
        public string? tTipoComprobante { get; set; }
        public Int64 iDProgramacionFecha { get; set; }
        public int iMCiudadTransporteSalida { get; set; }
        public int iMCiudadTransporteLlegada { get; set; }
        public string iNroAsiento { get; set; }
        public decimal? nPrecio { get; set; }
        public decimal? nDescuento { get; set; }
        public decimal? nTotalPagar { get; set; }
        public bool? lVentaGratuita { get; set; }
    }

    public class CodigoVentaBoleto
    {
        public Int64? iMVentaTransporte { get; set; }
        public Int64? iDComprobante { get; set; }
    }

    public class MOrdenTraslado
    {
        public Int64 iMOrden { get; set; }
        public int iNumero { get; set; }
        public String tSerie { get; set; }
        public String tNumero { get; set; }
        public String tRemitente { get; set; }
        public String tConsignado { get; set; }
        public bool lPAnticipado { get; set; }
        public String tOrigen { get; set; }
        public String tDestino { get; set; }
        public String tFecha { get; set; }
        public String tHora { get; set; }
        public decimal iImporteTotal { get; set; }
    }

    public class CodigOrdenTraslado
    {
        public Int64? iMOrden { get; set; }
        public Int64? iDComprobante { get; set; }
    }

    public class OrdenTrasladoRegistrar
    {
        public string tEmpresaRuc { get; set; }
        public Int64? iDSucursal { get; set; }
        public Int64? iMCiudadOrigen { get; set; }
        public Int64? iMCiudadDestino { get; set; }
        public Int64? iMCliente { get; set; }
        public string? tClienteDoc { get; set; }
        public string? tCliente { get; set; }
        public string? tClienteDir { get; set; }
        public Int64? iMRemitente { get; set; }
        public string? iMRemitenteTipoDoc { get; set; }
        public string? tRemitenteDoc { get; set; }
        public string? tRemitente { get; set; }
        public Int64? iMConsignado { get; set; }
        public string? iMConsignadoTipoDoc { get; set; }
        public string? tConsignadoDoc { get; set; }
        public string? tConsignado { get; set; }
        public bool? iPagoAnticipado { get; set; }
        public bool? iVentaGratuita { get; set; }
        public decimal? iDescuento { get; set; }
        public decimal? iImporteTotal { get; set; }
        public string? tTipoComprobante { get; set; }
        public Int64? iUsuario { get; set; }
        public int? iEstado { get; set; }
        public string productos { get; set; }
    }
}
