using System.Collections.Generic;
using System;

namespace ApiRestaurante.Models
{
    public class Movimiento
    {
        public Int64? iDMovimiento { get; set; }
        public Int64 iMTipoMovimiento { get; set; }
        public Int64 iMMotivoMovimiento { get; set; }
        public Int64? iAlmacenOrigen { get; set; }
        public Int64? iAlmacenDestino { get; set; }
        public string tEmpresaRuc { get; set; }
        public Int64? iMTipoDocumento { get; set; }
        public string tSerieDoc { get; set; }
        public string tNumeroDoc { get; set; }
        public Int64? iMProveedor { get; set; }
        public string tSerieGuia { get; set; }
        public string tNumeroGuia { get; set; }
        public string tObservaciones { get; set; }
        public DateTime fFechaMovimiento { get; set; }
        public int iUsuarioRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public string tNombre { get; set; }
        public List<Movimiento_Detalle> Detalle { get; set; }
        public Int64? iCompra { get; set; }
        public int iOrigenRegistro { get; set; }
        public int? iVenta { get; set; }
        public Int64? iDCotizacion { get; set; }
        public Int64? iDOrden { get; set; }
        public string Orden { get; set; }
        public Int64? Cliente { get; set; }
        public Int64? Mecanico { get; set; }
        public Int64? Vehiculo { get; set; }
        public DateTime FEmision { get; set; }
        public DateTime FRecepcion { get; set; }
        public DateTime FAproximada { get; set; }
        public Int64? iDSucursal { get; set; }
        public int TipoMovimientoOrden { get; set; }
        public Int64 iDOrdenDetalle { get; set; }
        public string tMoneda { get; set; }
        public decimal nTipoCambio { get; set; }
    }

    public class Movimiento_Detalle
    {
        public Int64 iDMovimiento { get; set; }
        public Int64 iMProducto { get; set; }
        public Int64? iMProductoAgrupador { get; set; }
        public decimal nCantidad { get; set; }
        public string tLote { get; set; }
        // CR ===================================
        public DateTime? fFechaVencimiento { get; set; }
        // CR ===================================
        public string UnidadMedida { get; set; }
        public Int64? iPresentacion { get; set; }
        public decimal nPrecioCompra { get; set; }
        public decimal nPrecioVenta { get; set; }
        public string tObservaciones { get; set; }
        public decimal nPCBase { get; set; }
        public decimal nPCIgv { get; set; }
        public decimal nPVBase { get; set; }
        public decimal nPVIgv { get; set; }
        public decimal nPCTBase { get; set; }
        public decimal nPCTIgv { get; set; }
        public decimal nPVTBase { get; set; }
        public decimal nPVTIgv { get; set; }
        public decimal nPCTotal { get; set; }
        public decimal nPVTotal { get; set; }
        public Int64 iDStock { get; set; }
        public Int64 iDCotizacionPadre { get; set; }
        public int iDCotizacionPadreItem { get; set; }
        public int iDCotizacionPadreMov { get; set; }
        public string afectacion { get; set; }
        public decimal? pUnitario { get; set; }
        public decimal? pVenta { get; set; }
        public Int64? almacen { get; set; }
        public Int32? iUsuarioRegistro { get; set; }
        public Int64? iDOrden { get; set; }
        public string tMonedaP { get; set; }
        public decimal? nTotalInicial { get; set; }
        public string tMoneda { get; set; }
        public decimal nTipoCambio { get; set; }
        public decimal nMargenGanancia { get; set; }
        public decimal nFactorGanancia { get; set; }
        public Int64 iMOperacion { get; set; }
        public int iAfectaIgv { get; set; }
        public decimal nPCBaseSoles { get; set; }
        public decimal nPCIgvSoles { get; set; }
        public decimal nPCompraSoles { get; set; }
        public decimal nPCTBaseSoles { get; set; }
        public decimal nPCTIgvSoles { get; set; }
        public decimal nPCTotalSoles { get; set; }
        public decimal nPVBaseSoles { get; set; }
        public decimal nPVIgvSoles { get; set; }
        public decimal nPVentaSoles { get; set; }
        public decimal nPVTBaseSoles { get; set; }
        public decimal nPVTIgvSoles { get; set; }
        public decimal nPVTotalSoles { get; set; }
        public decimal nPCompraInicial { get; set; }
    }
    public class Almacen
    {
    }
}
