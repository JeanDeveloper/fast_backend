using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.Models
{
    public class MSalon
    {
        public Int64 iMSalon { get; set; }
        public string tSalon { get; set; }
        public string tColor { get; set; }
        public string tObservacion { get; set; }
    }
    public class MMesa
    {
        public Int64 iMMesa { get; set; }
        public string tMesa { get; set; }
        public string tColor { get; set; }
        public string tEstado { get; set; }
        public string tHora { get; set; }
        public decimal nImporte { get; set; }
        public string tCliente { get; set; }
        public int iPax { get; set; }
        public Int64 iDPedido { get; set; }
        public string tMesaUnion { get; set; }
    }
    public class DPedidoDetalle
    {
        public Int64 iDPedidoDetalle { get; set; }
        public decimal nCantidad { get; set; }
        public Int64 iMProducto { get; set; }
        public string tProducto { get; set; }
        public decimal nPrecioUnitario { get; set; }
        public decimal nTotal { get; set; }
        public string tObservacion { get; set; }
        public decimal nAdicional { get; set; }
        public bool lCortesia { get; set; }
        public string fRegistro { get; set; }
        public string tUsuario { get; set; }
    }
    public class DPedidoDetalleId
    {
        public Int64 iDPedidoDetalle { get; set; }
        public Int64 iMProducto { get; set; }
        public bool lCortesia { get; set; }
        public string tObservacion { get; set; }
        public int iTipoConsumo { get; set; }
    }
    public class MCategoria
    {
        public Int64 iMCategoria { get; set; }
        public string tCategoria { get; set; }
        public Int64 iMImpresora { get; set; }
        public string tImpresora { get; set; }
        public List<MSubCategoria> SubCategoria { get; set; }
    }
    public class MSubCategoria
    {
        public Int64 iMSubCategoria { get; set; }
        public string tSubCategoria { get; set; }
    }
    public class MProducto
    {
        public Int64 iMProducto { get; set; }
        public string tProducto { get; set; }
        public string tImagenProducto { get; set; }
        public decimal nPrecioUnitario { get; set; }
        public Int64 iMCategoria { get; set; }
        public Int64 iMSubCategoria { get; set; }
        public string tSubCategoria { get; set; }
        public List<MOperador> Operadores { get; set; }
        

    }
    public class MOperador
    {
        public Int64 iMOperador { get; set; }
        public string tOperador { get; set; }
        public int iSeleccion { get; set; }
        public List<MPropiedad> Propiedades { get; set; }
    }
    public class MPropiedad
    {
        public Int64 iMPropiedad { get; set; }
        public string tPropiedad { get; set; }
        public bool lPorDefecto { get; set; }
        public decimal nPrecioAdicional { get; set; }
    }
    public class DPedido
    {
        public Int64 iMMesa { get; set; }
        public string tCliente { get; set; }
        public int iPax { get; set; }
        public string tEmpresaRuc { get; set; }
        public Int64 iDSucursal { get; set; }
        public Int64 iUsuarioRegistro { get; set; }
    }
    public class DPedidoProducto
    {
        public Int64 iDPedido { get; set; }
        public Int64 iDFormatoOrden { get; set; }
        public string productos { get; set; }
        public int iConexion { get; set; }
        public Int64 iUsuario { get; set; }
        public string tAndroInfo { get; set; }
    }
    public class DPedidoDetalleAnular
    {
        public Int64 iDPedido { get; set; }
        public Int64 iDFormatoAnulacion { get; set; }
        public Int64 iUsuarioRegistro { get; set; }
        public string productos { get; set; }
        public int iConexion { get; set; }
        public string tAndroInfo { get; set; }
    }


    public class DPedidoDetalleAnularQA
    {
        public Int64 iDPedido { get; set; }
        public Int64 iDFormatoAnulacion { get; set; }
        public Int64 iUsuarioRegistro { get; set; }
        public string productos { get; set; }
        public int iConexion { get; set; }
        public string tAndroInfo { get; set; }
        public int reasonId { get; set; }
    }


    public class DFormato
    {
        public Int64 iDFormatoPrecuenta { get; set; }
        public Int64 iDFormatoOrden { get; set; }
        public Int64 iDFormatoAnulacion { get; set; }
    }
    public class DUnirMesas
    {
        public Int64 iMMesaPrincipal { get; set; }
        public string mesas { get; set; }
    }

    public class DDesUnirMesas
    {
        public Int64 iMMesa { get; set; }
    }

    public class DTransferirMesa
    {
        public Int64 iMMesaOrigen { get; set; }
        public Int64 iMMesaDestino { get; set; }
    }

    public class MLlevarDelivery
    {
        public Int64 iDPedido { get; set; }
        public string tDescripcion { get; set; }
        public string tClienteResponsable { get; set; }
        public int iCapacidad { get; set; }
        public decimal nTotal { get; set; }
        public string tHora { get; set; }
        public int iEstado { get; set; }
        public int iEstadoPago { get; set; }
        public int iEstadoEnvio { get; set; }
    }

    public class DLiberarMesa
    {
        public Int64? iMMesa { get; set; }
        public Int64 iDPedido { get; set; }
    }

    public class DPedidoOrdenLlevar
    {
        public Int64 iDPedido { get; set; }
        public Int64 iDFormatoOrden { get; set; }
        public string productos { get; set; }
        public int iConexion { get; set; }
        public string tCliente { get; set; }
        public string tEmpresaRuc { get; set; }
        public Int64 iDSucursal { get; set; }
        public int iUsuarioRegistro { get; set; }
        public string tVersionApp { get; set; }
        public string tAndroInfo { get; set; }
    }

    public class DPedidoOrdenDelivery
    {
        public Int64 iDPedido { get; set; }
        public Int64 iDFormatoOrden { get; set; }
        public string productos { get; set; }
        public int iConexion { get; set; }
        public string tTelefono { get; set; }
        public string tCliente { get; set; }
        public string tDireccion { get; set; }
        public string tReferencia { get; set; }
        public Int64 iZona { get; set; }
        public string tEmpresaRuc { get; set; }
        public Int64 iDSucursal { get; set; }
        public int iUsuarioRegistro { get; set; }
        public string tVersionApp { get; set; }
        public string tAndroInfo { get; set; }
    }
    public class MZonaDelivery
    {
        public Int64 iMZonaDelivery { get; set; }
        public string tZona { get; set; }
        public Decimal iPrecio { get; set; }
        public Int64 iMProductoDelivery { get; set; }
    }
    public class MClienteDelivery
    {
        public string tTelefono { get; set; }
        public string tNombre { get; set; }
        public string tDireccion { get; set; }
        public string tReferencia { get; set; }
        public Int64 iMZona { get; set; }
    }
    public class DPedidoDelivery
    {
        public Int64 iDPedido { get; set; }
        public string tTelefono { get; set; }
        public string tNombre { get; set; }
        public string tDireccion { get; set; }
        public string tReferencia { get; set; }
        public Int64 iMZona { get; set; }
    }
    public class MReason
    {
        public Int64 iMMotivoBajaPedido { get; set; }
        public string tDescripcion { get; set; }
    }
}
