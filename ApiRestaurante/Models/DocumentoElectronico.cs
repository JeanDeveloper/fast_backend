using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace ApiRestaurante.Models
{
    public class DocumentoElectronico
    {

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string IdDocumento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string TipoDocumento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public Contribuyente Emisor { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public Contribuyente Receptor { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string FechaEmision { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Moneda { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.AllowNull)]
#endif
        public string TipoOperacion { get; set; }

        public decimal Gravadas { get; set; }

        public decimal Gratuitas { get; set; }

        public decimal Inafectas { get; set; }

        public decimal Exoneradas { get; set; }
        public decimal Exportacion { get; set; }

        public decimal DescuentoGlobal { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public List<DetalleDocumento> Items { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal TotalVenta { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal TotalIgv { get; set; }

        public decimal TotalIsc { get; set; }

        public decimal TotalOtrosTributos { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string MontoEnLetras { get; set; }

        public string PlacaVehiculo { get; set; }

        public decimal MontoPercepcion { get; set; }

        public decimal MontoDetraccion { get; set; }

        public List<DatoAdicional> DatoAdicionales { get; set; }

        public string TipoDocAnticipo { get; set; }

        public string DocAnticipo { get; set; }

        public string MonedaAnticipo { get; set; }

        public decimal MontoAnticipo { get; set; }

        public string DescripcionAnticipo { get; set; }

        public int CodigoVentaAnticipoOri { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.AllowNull)]
#endif
        public DatosGuia DatosGuiaTransportista { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.AllowNull)]
#endif
        public List<DocumentoRelacionado> Relacionados { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.AllowNull)]
#endif
        public List<Discrepancia> Discrepancias { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal CalculoIgv { get; set; }

        public decimal CalculoIsc { get; set; }

        public decimal CalculoDetraccion { get; set; }

        public int CodigoOrigen { get; set; }

        public string Email { get; set; }

        public decimal MontoEfectivo { get; set; }

        public decimal MontoTarjeta { get; set; }

        public decimal MontoVuelto { get; set; }

        public string OrdenTrabajo { get; set; }

        public string OrdenCompra { get; set; }

        public string ModalidaPago { get; set; }

        public string Serie { get; set; }

        public string Numero { get; set; }

        public string TipoCambio { get; set; }

        public string Redondeo { get; set; }

        public string GuiaRemision { get; set; }

        public string Observacion1 { get; set; }
        public string Observacion2 { get; set; }

        public string FechaOrigen { get; set; }

        public decimal RecargoConsumo { get; set; }

        public string Mesero { get; set; }

        public string Mesa { get; set; }
        public string IpVenta { get; set; }

        public string FechaVencimiento { get; set; }

        public int iDetraccion { get; set; }

        public string tTransporteConsignatario { get; set; }
        public long iTransporteOrigen { get; set; }
        public string tTransporteOrigen { get; set; }

        public long iTransporteDestino { get; set; }
        public string tTransporteDestino { get; set; }

        // public string tClienteTelefono { get; set; }
        public string tFecha_Descripcion { get; set; }
        public decimal nimportenotacredito { get; set; }
        public string tEmbarcacionPesquera { get; set; }
        public string tLiquidacion { get; set; }
        public string tTicket { get; set; }
        public bool lFinanciamiento { get; set; }
        public int anulado { get; set; }
        public int lEstadoAnticipo { get; set; }
        public Int64? iMCliente { get; set; }
        public Int64? iDAlmacen { get; set; }
        public int lTipoVenta { get; set; }
        public string GuiTransporte { get; set; }
        public decimal TotalOtrosCargos { get; set; }
        public bool lNotaSalida { get; set; }
        public int lAfectaStock { get; set; }
        //#if !SILVERLIGHT
        //        [JsonProperty(Required = Required.Always)]
        //#endif
        public DatosVehiculo Vehiculo { get; set; }
        /// <summary>
        /// /////////////////////////////////////////////////////public GuiaRemision GuiaRemisionManual { get; set; }
        /// </summary>

        public DocumentoElectronico()
        {
            Emisor = new Contribuyente
            {
                TipoDocumento = "6" // RUC.
            };
            Receptor = new Contribuyente
            {
                TipoDocumento = "6" // RUC.
            };
            CalculoIgv = 0.18m;
            CalculoIsc = 0.10m;
            CalculoDetraccion = 0.04m;
            Items = new List<DetalleDocumento>();
            DatoAdicionales = new List<DatoAdicional>();
            Relacionados = new List<DocumentoRelacionado>();
            Discrepancias = new List<Discrepancia>();
            TipoDocumento = "01"; // Factura.
            TipoOperacion = "01"; // Venta Interna.
            Moneda = "PEN"; // Soles.
        }


    }

    public class DatosVehiculo
    {
        public string Marca { get; set; }

        public string CodigoProducto { get; set; }

        public string ClaseVehiculo { get; set; }

        public string CodigoVehiculo { get; set; }

        public string Modelo { get; set; }

        public string Chasis { get; set; }

        public string AnioFabricacion { get; set; }

        public string Case { get; set; }

        public string Motor { get; set; }

        public string Color { get; set; }

        public string Embarque { get; set; }

        public string Categoria { get; set; }

        public string Carroceria { get; set; }

        public string Version { get; set; }

        public string ModeloTecnico { get; set; }

        public string CodigoModelo { get; set; }

        public string Cilindros { get; set; }

        public string Desplazamiento { get; set; }

        public string Potencia { get; set; }

        public string Combustible { get; set; }

        public string PesoBruto { get; set; }

        public string PesoNeto { get; set; }

        public string CargaUtil { get; set; }

        public string NroAsientos { get; set; }

        public string NroEjes { get; set; }

        public string DistanciaEjes { get; set; }

        public string NroRuedas { get; set; }

        public string Largo { get; set; }

        public string Alto { get; set; }

        public string Ancho { get; set; }

        public string Puertas { get; set; }

        public string Lote { get; set; }

        public string NroCilindros { get; set; }
    }

    public class Discrepancia
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string NroReferencia { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Tipo { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Descripcion { get; set; }
    }

    public class DocumentoRelacionado

    {
#if !SILVERLIGHT
        [JsonProperty(Order = 1, Required = Required.Always)]
#endif
        public string NroDocumento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 2, Required = Required.Always)]
#endif
        public string TipoDocumento { get; set; }
    }
    public class DatosGuia
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public Contribuyente DireccionDestino { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public Contribuyente DireccionOrigen { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string RucTransportista { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string TipoDocTransportista { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string NombreTransportista { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string NroLicenciaConducir { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string PlacaVehiculo { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string CodigoAutorizacion { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string MarcaVehiculo { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string ModoTransporte { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string UnidadMedida { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal PesoBruto { get; set; }

        public DatosGuia()
        {
            DireccionDestino = new Contribuyente();
            DireccionOrigen = new Contribuyente();
        }
    }
    public class DatoAdicional
    {
#if !SILVERLIGHT
        [JsonProperty(Order = 1, Required = Required.Always)]
#endif
        public string Codigo { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 2, Required = Required.Always)]
#endif
        public string Contenido { get; set; }
    }

    public class DetalleDocumento
    {

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public int Id { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal Cantidad { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string UnidadMedida { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string CodigoItem { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Descripcion { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal PrecioUnitario { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal PrecioReferencial { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string TipoPrecio { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string TipoImpuesto { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal Impuesto { get; set; }

        public decimal ImpuestoSelectivo { get; set; }

        public decimal OtroImpuesto { get; set; }

        public Descuentos DescuentoV21 { get; set; }
        public decimal Descuento { get; set; }
        public decimal DescuentoIGV { get; set; }
        public decimal DescuentoUnidad { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal TotalVenta { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal Suma { get; set; }

        public string Observacion { get; set; }

        public decimal PrecioUnit9 { get; set; }
        public decimal Redondeo { get; set; }
        public decimal IgvVenta { get; set; }
        public int AplicaIgv { get; set; }

        public decimal Total { get; set; }
        public string UnidadMedidaCliente { get; set; }
        public decimal PCBase { get; set; }
        public decimal PCIgv { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PCTBase { get; set; }
        public decimal PCTIgv { get; set; }
        public decimal PCTotal { get; set; }
        public Int64 iDStock { get; set; }
        public string Lote { get; set; }
        public bool aplica_ICBPer { get; set; }
        public Int64 iDCotizacionPadre { get; set; }
        public int iDCotizacionPadreItem { get; set; }
        public int iDCotizacionPadreMov { get; set; }
        public int iDPedidoDetalle { get; set; }
        public DetalleDocumento()
        {
            Id = 1;
            UnidadMedida = "NIU";
            TipoPrecio = "01";
            TipoImpuesto = "10";
        }
        public Int64 iDOrden { get; set; }
        public Int64 OrdenServicio { get; set; }
        public string tMoneda { get; set; }
        public decimal nTipoCambio { get; set; }
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

    public class Descuentos
    {
        public string Codigo { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoBase { get; set; }
    }

    public class Contribuyente
    {

#if !SILVERLIGHT
        [JsonProperty(Order = 1, Required = Required.Always)]
#endif
        public string NroDocumento { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Order = 2, Required = Required.Always)]
#endif
        public string TipoDocumento { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Order = 3, Required = Required.Always)]
#endif
        public string NombreLegal { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 4)]
#endif
        public string NombreComercial { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Order = 5)]
#endif
        public string Ubigeo { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Order = 6)]
#endif
        public string Direccion { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 7)]
#endif
        public string Urbanizacion { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 8)]
#endif
        public string Departamento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 9)]
#endif
        public string Provincia { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 10)]
#endif
        public string Distrito { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 11)]
#endif
        public string Telefono { get; set; }
        public string CodDireccion { get; set; }
        public Int64 iMCliente { get; set; }
    }
}
