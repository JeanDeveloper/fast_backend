using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.Models
{
    public class MCajaDiaria
    {
        public Int64 iDCajaDiaria { get; set; }
        public string fFecha { get; set; }
        public Int64 iMCaja { get; set; }
        public string tMCaja { get; set; }
        public Int64 iDSucursal { get; set; }
        public string tDSucursal { get; set; }
        public decimal nInicial { get; set; }
        public int iEstado { get; set; }
        public Int64 iMResponsable { get; set; }
        public string tMResponsable { get; set; }
    }

    public class MCajaDiariaBuscarPorId
    {
        public Int64 iMCaja { get; set; }
        public string tMCaja { get; set; }
        public decimal nInicial { get; set; }
        public int iEstado { get; set; }
        public decimal nImporteFinal { get; set; }
        public decimal nTotalEgresos { get; set; }
        public decimal nTotalIngresos { get; set; }
    }

    public class CajaDiariaDetalle
    {
        public Int64 iDCajaDiariaDetalle { get; set; }
        public string fFecha { get; set; }
        public string tDescripcion { get; set; }
        public string tNombreCliente { get; set; }
        public decimal nEfectivo { get; set; }
        public decimal nTarjeta { get; set; }
        public decimal nNotaCredito { get; set; }
        public decimal nImporte { get; set; }
        public int iEstado { get; set; }
        public string tTipoComprobante { get; set; }
        public string tNroComprobante { get; set; }
        public string tMotivo { get; set; }
    }

    public class CajaDiariaAbiertaUsuario
    {
        public Int64 iDCajaDiaria { get; set; }
        public string fFecha { get; set; }
        public Int64 iMCaja { get; set; }
        public string tMCaja { get; set; }
        public Int64 iDSucursal { get; set; }
        public string tDSucursal { get; set; }
        public int iMoneda { get; set; }
    }

    public class CajaDiariaRegistrar
    {
        public string tEmpresaRuc { get; set; }
        public Int64 iMCaja { get; set; }
        public Int64 iDSucursal { get; set; }
        public Int64 iResponsable { get; set; }
        public int iMoneda { get; set; }
        public decimal nInicial { get; set; }
        public Int64 iUsuarioRegistro { get; set; }
    }

    public class CajaDiariaCerrar
    {
        public Int64 iDCajaDiaria { get; set; }
        public Int64 iUsuario { get; set; }
        //public string tObservacionesCierre { get; set; }
        //public string tEmailCierreCaja { get; set; }
        public int lReabrirCaja { get; set; }
        //public decimal? nSobrante { get; set; }
        //public decimal? nFaltante { get; set; }
        //public decimal? nEfectivoFisico { get; set; }

    }

    public class CajaDiariaDetalleRegistrar
    {
        public Int64 iDCajaDiaria { get; set; }
        public int iTipo { get; set; }
        public string tMotivoCaja { get; set; }
        public string tDescripcion { get; set; }
        public Int64? iMCliente { get; set; }
        public Int64? iMEmpleado { get; set; }
        public int iMoneda { get; set; }
        public decimal nTipoCambio { get; set; }
        public decimal nEfectivo { get; set; }
        public decimal nTarjeta { get; set; }
        public decimal nNotaCredito { get; set; }
        public decimal nImporte { get; set; }
        public Int64? iCodigoVenta { get; set; }
        public Int64? iDCotizacion { get; set; }
        public Int64? iDCompra { get; set; }
        public string operaciones { get; set; }
        public Int64? iUsuarioRegistro { get; set; }
        public string tObservaciones { get; set; }
        public Int64? iMCentroCosto { get; set; }
        public Int64? iDContratoVentaCuota { get; set; }
        public string tTotalLetras { get; set; }
        public Int64? iDFormato { get; set; }
        public Int64? iDOrdenServicio { get; set; }
        public int? lCobranza { get; set; }
    }

    public class TerminalCajaDiaria
    {
        public Int64 iMTerminal { get; set; }
        public string tNombre { get; set; }
        public string tBanco { get; set; }
        public decimal iImporte { get; set; }
    }

    public class Caja
    {
    }
}
