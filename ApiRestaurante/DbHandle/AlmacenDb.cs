using ApiRestaurante.Models;
using Microsoft.Extensions.Hosting;
using System.Data.SqlClient;
using System.Data;

namespace ApiRestaurante.DbHandle
{
    public class AlmacenDb: GeneralDb
    {
        public MessageOut DMovimiento_Registrar(Movimiento nMovimiento)
        {
            MessageOut listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_DMovimiento_Registrar_V5", connection);
                command.Parameters.Add("iMTipoMovimiento", SqlDbType.BigInt).Value = nMovimiento.iMTipoMovimiento;
                command.Parameters.Add("iMMotivoMovimiento", SqlDbType.BigInt).Value = nMovimiento.iMMotivoMovimiento;
                command.Parameters.Add("iAlmacenOrigen", SqlDbType.BigInt).Value = nMovimiento.iAlmacenOrigen;
                command.Parameters.Add("iAlmacenDestino", SqlDbType.BigInt).Value = nMovimiento.iAlmacenDestino;
                command.Parameters.Add("tEmpresaRuc", SqlDbType.VarChar).Value = nMovimiento.tEmpresaRuc;
                command.Parameters.Add("iMTipoDocumento", SqlDbType.BigInt).Value = nMovimiento.iMTipoDocumento;
                command.Parameters.Add("tSerieDoc", SqlDbType.VarChar).Value = nMovimiento.tSerieDoc;
                command.Parameters.Add("tNumeroDoc", SqlDbType.VarChar).Value = nMovimiento.tNumeroDoc;
                command.Parameters.Add("iMProveedor", SqlDbType.BigInt).Value = nMovimiento.iMProveedor;
                command.Parameters.Add("tSerieGuia", SqlDbType.VarChar).Value = nMovimiento.tSerieGuia;
                command.Parameters.Add("tNumeroGuia", SqlDbType.VarChar).Value = nMovimiento.tNumeroGuia;
                command.Parameters.Add("tObservaciones", SqlDbType.VarChar).Value = nMovimiento.tObservaciones;
                command.Parameters.Add("fFechaMovimiento", SqlDbType.Date).Value = nMovimiento.fFechaMovimiento;
                command.Parameters.Add("iUsuarioRegistro", SqlDbType.Int).Value = nMovimiento.iUsuarioRegistro;
                command.Parameters.Add("iCompra", SqlDbType.BigInt).Value = nMovimiento.iCompra;
                command.Parameters.Add("iOrigenRegistro", SqlDbType.Int).Value = nMovimiento.iOrigenRegistro;
                command.Parameters.Add("iVenta", SqlDbType.BigInt).Value = nMovimiento.iVenta;
                command.Parameters.Add("iDCotizacion", SqlDbType.BigInt).Value = nMovimiento.iDCotizacion;
                command.Parameters.Add("iDOrden", SqlDbType.BigInt).Value = nMovimiento.iDOrden;
                command.Parameters.Add("tMoneda", SqlDbType.VarChar).Value = nMovimiento.tMoneda;
                command.Parameters.Add("nTipoCambio", SqlDbType.Decimal).Value = nMovimiento.nTipoCambio;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new MessageOut();
                        listEntidad.MessageResult = reader.GetString(0);
                        listEntidad.MessageValue = reader.GetString(1);
                        listEntidad.MessageOut_ = reader.GetInt64(2);
                    }
                }

                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public MessageOut DmovimientoDetalle_Registrar(Movimiento_Detalle nMovimientoDetalle)
        {
            MessageOut listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_DmovimientoDetalle_Registrar_V10", connection);
                command.Parameters.Add("@iDMovimiento", SqlDbType.BigInt).Value = nMovimientoDetalle.iDMovimiento;
                command.Parameters.Add("@iMProducto", SqlDbType.BigInt).Value = nMovimientoDetalle.iMProducto;
                command.Parameters.Add("@iMProductoAgrupador", SqlDbType.BigInt).Value = nMovimientoDetalle.iMProductoAgrupador;
                command.Parameters.Add("@nCantidad", SqlDbType.Decimal).Value = nMovimientoDetalle.nCantidad;
                command.Parameters.Add("@tLote", SqlDbType.VarChar).Value = nMovimientoDetalle.tLote;
                command.Parameters.Add("@iPresentacion", SqlDbType.BigInt).Value = nMovimientoDetalle.iPresentacion;
                command.Parameters.Add("@UnidadMedida", SqlDbType.VarChar).Value = nMovimientoDetalle.UnidadMedida;
                command.Parameters.Add("@nPrecioCompra", SqlDbType.Decimal).Value = nMovimientoDetalle.nPrecioCompra;
                command.Parameters.Add("@nPrecioVenta", SqlDbType.Decimal).Value = nMovimientoDetalle.nPrecioVenta;
                command.Parameters.Add("@tObservaciones", SqlDbType.VarChar).Value = nMovimientoDetalle.tObservaciones;
                command.Parameters.Add("@nPCBase", SqlDbType.Decimal).Value = nMovimientoDetalle.nPCBase;
                command.Parameters.Add("@nPCIgv", SqlDbType.Decimal).Value = nMovimientoDetalle.nPCIgv;
                command.Parameters.Add("@nPVBase", SqlDbType.Decimal).Value = nMovimientoDetalle.nPVBase;
                command.Parameters.Add("@nPVIgv", SqlDbType.Decimal).Value = nMovimientoDetalle.nPVIgv;
                command.Parameters.Add("@nPCTBase", SqlDbType.Decimal).Value = nMovimientoDetalle.nPCTBase;
                command.Parameters.Add("@nPCTIgv", SqlDbType.Decimal).Value = nMovimientoDetalle.nPCTIgv;
                command.Parameters.Add("@nPVTBase", SqlDbType.Decimal).Value = nMovimientoDetalle.nPVTBase;
                command.Parameters.Add("@nPVTIgv", SqlDbType.Decimal).Value = nMovimientoDetalle.nPVTIgv;
                command.Parameters.Add("@nPCTotal", SqlDbType.Decimal).Value = nMovimientoDetalle.nPCTotal;
                command.Parameters.Add("@nPVTotal", SqlDbType.Decimal).Value = nMovimientoDetalle.nPVTotal;
                command.Parameters.Add("@iDStockV", SqlDbType.BigInt).Value = nMovimientoDetalle.iDStock;
                command.Parameters.Add("@iDCotizacionPadre", SqlDbType.BigInt).Value = nMovimientoDetalle.iDCotizacionPadre;
                command.Parameters.Add("@iDCotizacionPadreItem", SqlDbType.Int).Value = nMovimientoDetalle.iDCotizacionPadreItem;
                command.Parameters.Add("@fFechaVencimiento", SqlDbType.Date).Value = nMovimientoDetalle.fFechaVencimiento;
                command.Parameters.Add("@iDOrden", SqlDbType.BigInt).Value = nMovimientoDetalle.iDOrden;
                command.Parameters.Add("@tMoneda", SqlDbType.VarChar).Value = nMovimientoDetalle.tMoneda;
                command.Parameters.Add("@nTipoCambio", SqlDbType.Decimal).Value = nMovimientoDetalle.nTipoCambio;
                command.Parameters.Add("@nMargenGanancia", SqlDbType.Decimal).Value = nMovimientoDetalle.nMargenGanancia;
                command.Parameters.Add("@nFactorGanancia", SqlDbType.Decimal).Value = nMovimientoDetalle.nFactorGanancia;
                command.Parameters.Add("@iMOperacion", SqlDbType.BigInt).Value = nMovimientoDetalle.iMOperacion;
                command.Parameters.Add("@iAfectaIgv", SqlDbType.Int).Value = nMovimientoDetalle.iAfectaIgv;
                command.Parameters.Add("@nPCBaseSoles", SqlDbType.Decimal).Value = nMovimientoDetalle.nPCBaseSoles;
                command.Parameters.Add("@nPCIgvSoles", SqlDbType.Decimal).Value = nMovimientoDetalle.nPCIgvSoles;
                command.Parameters.Add("@nPCompraSoles", SqlDbType.Decimal).Value = nMovimientoDetalle.nPCompraSoles;
                command.Parameters.Add("@nPCTBaseSoles", SqlDbType.Decimal).Value = nMovimientoDetalle.nPCTBaseSoles;
                command.Parameters.Add("@nPCTIgvSoles", SqlDbType.Decimal).Value = nMovimientoDetalle.nPCTIgvSoles;
                command.Parameters.Add("@nPCTotalSoles", SqlDbType.Decimal).Value = nMovimientoDetalle.nPCTotalSoles;
                command.Parameters.Add("@nPVBaseSoles", SqlDbType.Decimal).Value = nMovimientoDetalle.nPVBaseSoles;
                command.Parameters.Add("@nPVIgvSoles", SqlDbType.Decimal).Value = nMovimientoDetalle.nPVIgvSoles;
                command.Parameters.Add("@nPVentaSoles", SqlDbType.Decimal).Value = nMovimientoDetalle.nPVentaSoles;
                command.Parameters.Add("@nPVTBaseSoles", SqlDbType.Decimal).Value = nMovimientoDetalle.nPVTBaseSoles;
                command.Parameters.Add("@nPVTIgvSoles", SqlDbType.Decimal).Value = nMovimientoDetalle.nPVTIgvSoles;
                command.Parameters.Add("@nPVTotalSoles", SqlDbType.Decimal).Value = nMovimientoDetalle.nPVTotalSoles;
                command.Parameters.Add("@nPCompraInicial", SqlDbType.Decimal).Value = nMovimientoDetalle.nPCompraInicial;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new MessageOut();
                        listEntidad.MessageResult = reader.GetString(0);
                        listEntidad.MessageValue = reader.GetString(1);
                        listEntidad.MessageOut_ = reader.GetInt64(2);
                    }
                }

                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public MessageOut DMovimiento_Editar(Movimiento mMovimiento)
        {
            MessageOut listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_DMovimiento_Editar_V1", connection);
                command.Parameters.Add("@tSerieDoc", SqlDbType.VarChar).Value = mMovimiento.tSerieDoc;
                command.Parameters.Add("@tNumeroDoc", SqlDbType.VarChar).Value = mMovimiento.tNumeroDoc;
                command.Parameters.Add("@tObservaciones", SqlDbType.VarChar).Value = mMovimiento.tObservaciones;
                command.Parameters.Add("@fFechaMovimiento", SqlDbType.Date).Value = mMovimiento.fFechaMovimiento;
                command.Parameters.Add("@iUsuarioRegistro", SqlDbType.Int).Value = mMovimiento.iUsuarioRegistro;
                command.Parameters.Add("@iOrigenRegistro", SqlDbType.Int).Value = mMovimiento.iOrigenRegistro;
                command.Parameters.Add("@iVenta", SqlDbType.BigInt).Value = mMovimiento.iVenta;
                command.Parameters.Add("@iDCotizacion", SqlDbType.BigInt).Value = mMovimiento.iDCotizacion;
                command.Parameters.Add("@iMCliente", SqlDbType.BigInt).Value = mMovimiento.iMProveedor;
                command.Parameters.Add("@iMTipoDocumento", SqlDbType.BigInt).Value = mMovimiento.iMTipoDocumento;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new MessageOut();
                        listEntidad.MessageResult = reader.GetString(0);
                        listEntidad.MessageValue = reader.GetString(1);
                    }
                }

                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
    }
}
