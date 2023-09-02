using System.Collections.Generic;
using System;

namespace ApiRestaurante.Models
{
    public class DInsertWebService
    {
        public string Comprobante { get; set; }
        public string TipoDoc { get; set; }
        public string FormatoPdf { get; set; }
        public Int64 iDCotizacion { get; set; }
        public string iTipo { get; set; }
        public int UsuarioId { get; set; }
        public string tEmpresaRuc { get; set; }
    }

    public class DAnular
    {
        public int ComprobanteId { get; set; }
        public string Motivo { get; set; }
        public string UsuarioId { get; set; }
    }
    public class Comprobante
    {
        public Int64 ComprobanteId { get; set; }
        public string RucEmisor { get; set; }
        public string FechaEmision { get; set; }
        public string RucCliente { get; set; }
        public string RazonSocialCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string CorreoCliente { get; set; }
        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public string SerieOrigen { get; set; }
        public string NumeroOrigen { get; set; }
        public string TipoDocOrigen { get; set; }
        public string Moneda { get; set; }
        public string TipoCambio { get; set; }
        public string Importe { get; set; }
        public string Subtotal { get; set; }
        public string Descuento { get; set; }
        public string Igv { get; set; }
        public string EstadoDocumento { get; set; }
        public string EstadoSunat { get; set; }
        public string FechaEnvio { get; set; }
        public string DirectorioXml { get; set; }
        public string DirectorioZip { get; set; }
        public string DirectorioPdf { get; set; }
        public string DirectorioZipSunat { get; set; }
        public string Anulado { get; set; }
        public string FechaAnulado { get; set; }
        public string MotivoBaja { get; set; }
        public int EmailsEnviados { get; set; }
        public int NResumenes { get; set; }
        public int EnviadoPortal { get; set; }
        public string Empresa { get; set; }
        public string FechaOrigen { get; set; }
        public string Item { get; set; }
        public string CodigoPro { get; set; }
        public string UM { get; set; }
        public string Descripcion { get; set; }
        public string PrecioUnit { get; set; }
        public string Cantidad { get; set; }
        public string IgvPro { get; set; }
        public string Precio { get; set; }
        public int Consulta { get; set; }
        public string CodigoErrorSunat { get; set; }
        public string CodigoErrorSistema { get; set; }
        public string UsuarioRegistra { get; set; }
        public int IsDayAutorized { get; set; }
        public decimal monto_detraccion { get; set; }
        public string texto_detraccion { get; set; }
        public string Observacion { get; set; }
        public string OrdenCompra { get; set; }
        public decimal ImporteSoles { get; set; }
        public string ModalidadPago { get; set; }
        public string PlacaVehiculo { get; set; }
        public string Requerimiento { get; set; }
        public string FechaVencimiento { get; set; }
        public string FechaRegistro { get; set; }
        public string IdTipo_Doc { get; set; }
        public bool IsLast { get; set; }
        public string tipo_doc_origen { get; set; }
        public string correlativo_orgien { get; set; }
        public string UbicacionPDF { get; set; }
        public string tTransporteConsignatario { get; set; }
        public string tTransporteOrigen { get; set; }
        public string tTransporteDestinp { get; set; }
        public string tEmbarcacionPesquera { get; set; }
        public string tLiquidacion { get; set; }
        public string tTicket { get; set; }
        public string TipoDocSunat { get; set; }
        public int DiasTranscurridos { get; set; }
        public int nDiasAnulacion { get; set; }
        public Int64 iMCliente { get; set; }
        public string GuiTransporte { get; set; }
        public Int64 iDAlmacen { get; set; }
        public decimal gratuitas { get; set; }
        public decimal inafectas { get; set; }
        public decimal exoneradas { get; set; }
        public decimal recargo_consumo { get; set; }
        public decimal exportacion { get; set; }
        public decimal ICBPer { get; set; }
        public Int64 iMVendedor { get; set; }
        public string tVendedor { get; set; }
        public List<ComprobanteDetalle> detalle { get; set; }
        public int iEstadoSunat { get; set; }
        public int iEstadoOse { get; set; }
        public decimal nPendiente { get; set; }
        public decimal nCancelado { get; set; }
        public string tDireccionEmisor { get; set; }
        public string tTelefonoEmisor { get; set; }
        public string tMontoLetras { get; set; }
        public string emp_nomcomercial { get; set; }
        public string tipo_nc { get; set; }
        public string sustento_nc { get; set; }
        public string correlativo_mod_nc { get; set; }
        public string doc_mod_nc { get; set; }
        public string fec_mod_nc { get; set; }
        public string tipo_doc { get; set; }
        public string hash { get; set; }
        public string mensaje_consulta { get; set; }
        public string doc_cliente { get; set; }
        public string cdp_moneda { get; set; }
        public Int64 iTransporteOrigen { get; set; }
        public Int64 iTransporteDestino { get; set; }
        public string tOrigenVenta { get; set; }
        public string tGuiaRemision { get; set; }
        public Int64 iDSucursalVenta { get; set; }
        public string tCiudadTransporteOrigen { get; set; }
        public string tCiudadTransporteDestino { get; set; }
        public string tConsignatarioEncomienda { get; set; }
        public bool lPagado { get; set; }
        public decimal PendientePago { get; set; }
        public Int32 iMDetraccion { get; set; }
        public bool lRetencionIGV { get; set; }
        public decimal nRetencionIGV { get; set; }
        public decimal nRetencionIGVPorcentaje { get; set; }
    }

    public class ComprobanteDetalle
    {
        public int Item { get; set; }
        public string CodigoProducto { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Cantidad { get; set; }
        public string DescProducto { get; set; }
        public string Observacion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal ValorVenta { get; set; }
        public decimal IgvUnit { get; set; }
        public decimal Descuento { get; set; }
        public string TipoAfectacion { get; set; }
        public decimal PrecioUnitario9 { get; set; }
        public decimal Redondeo { get; set; }
        public decimal IgvTotal { get; set; }
        public bool AplicaIgv { get; set; }
        public int Consulta { get; set; }
        public string CodigoErrorSunat { get; set; }
        public string CodigoErrorSistema { get; set; }
        public int iAfectacionTipo { get; set; }
        public string tAfectacionNom { get; set; }
        public Int64 iDStock { get; set; }
        public Int64 iOrdenServicioDetalle { get; set; }
        public string tMarca { get; set; }
    }

    public class Library
    {
        public int Year_ { get; set; }
        public string EstadoSunat { get; set; }
        public string EstadoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string DocumentoSerie { get; set; }
        public string FormatoPdf { get; set; }
        public string EstadoAnulado { get; set; }
        public string tServicio { get; set; }
        public string tTipo { get; set; }
        public Int64 iAlmacen { get; set; }
        public int iNumeracion { get; set; }
    }
    public class UnidadMedida
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string uFecha { get; set; }
        public string rFecha { get; set; }
    }
}
