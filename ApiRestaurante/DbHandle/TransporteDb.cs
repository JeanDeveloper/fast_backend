using ApiRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.DbHandle
{
    public class TransporteDb : GeneralDb
    {
        public List<MCiudad> MCiudad_Listar(string tEmpresaRuc)
        {
            List<MCiudad> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_MCiudad_Transporte_Listar_V1", connection);
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MCiudad entidad = null;
                    listEntidad = new List<MCiudad>();
                    while (reader.Read())
                    {
                        entidad = new MCiudad();
                        entidad.iMCiudad = reader.GetInt32(0);
                        entidad.tDescripcion = reader.GetString(1);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public List<DProgramacion> MProgramacion_Listar(string tEmpresaRuc, DateTime fFecha, int iOrigen, int iDestino)
        {
            List<DProgramacion> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_DProgramacion_Listar_Activos_V1", connection);
                command.Parameters.Add("@fFecha", SqlDbType.Date).Value = fFecha;
                command.Parameters.Add("@iMCiudadTransporteOrigen", SqlDbType.Int).Value = iOrigen;
                command.Parameters.Add("@iMCiudadTransporteDestino", SqlDbType.Int).Value = iDestino;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    DProgramacion entidad = null;
                    listEntidad = new List<DProgramacion>();
                    while (reader.Read())
                    {
                        entidad = new DProgramacion();
                        entidad.fHoraSalida = reader.GetString(0);
                        entidad.tServicio = reader.GetString(1);
                        entidad.iCapacidad = reader.GetInt32(3);
                        entidad.iDProgramacion = reader.GetInt64(6);
                        entidad.iDProgramacionFecha = reader.GetInt64(7);
                        entidad.iNumeroViaje = reader.GetInt32(8);
                        entidad.tRuta = reader.GetString(13);
                        entidad.tFecha = reader.GetString(14);
                        entidad.tPrecio = reader.GetString(15);
                        entidad.iMModeloTransporte = reader.GetInt64(16);
                        entidad.tPlaca = reader.GetString(17);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public List<MVehiculo> MNivelesVehiculo_Listar(Int64 iMModeloTransporte)
        {
            List<MVehiculo> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_app_MMNivelesVehiculo_Listar", connection);
                command.Parameters.Add("@iMModeloTransporte", SqlDbType.BigInt).Value = iMModeloTransporte;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MVehiculo entidad = null;
                    listEntidad = new List<MVehiculo>();
                    while (reader.Read())
                    {
                        entidad = new MVehiculo();
                        entidad.inivel = reader.GetInt32(0);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public List<MVehiculo> MModeloAsiento_Buscar(Int64 iDProgramacionFecha, Int64 iMModeloTransporte, int iNivel, int iMOrigen, int iMDestino)
        {
            List<MVehiculo> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_app_MModeloAsiento_Buscar", connection);
                command.Parameters.Add("@iDProgramacionFecha", SqlDbType.BigInt).Value = iDProgramacionFecha;
                command.Parameters.Add("@iMModeloTransporte", SqlDbType.BigInt).Value = iMModeloTransporte;
                command.Parameters.Add("@iNivel", SqlDbType.Int).Value = iNivel;
                command.Parameters.Add("@iMOrigen", SqlDbType.Int).Value = iMOrigen;
                command.Parameters.Add("@iMDestino", SqlDbType.Int).Value = iMDestino;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MVehiculo entidad = null;
                    listEntidad = new List<MVehiculo>();
                    while (reader.Read())
                    {
                        entidad = new MVehiculo();
                        entidad.iTipo = reader.GetInt32(0);
                        entidad.inivel = reader.GetInt32(1);
                        entidad.iColumna = reader.GetInt32(2);
                        entidad.iFila = reader.GetInt32(3);
                        entidad.iAsiento = reader.GetInt32(4);
                        entidad.iEstado = reader.GetInt32(5);
                        entidad.iPrecio = reader.GetDecimal(6);
                        entidad.iMVentaTransporte = reader.GetInt64(7);
                        entidad.tColor = reader.GetString(8);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public List<MBoletoDetalle> MObtenerDatosBoleto_Buscar(Int64 iMVentaTransporte)
        {
            List<MBoletoDetalle> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_app_MObtenerDatosBoleto_Buscar", connection);
                command.Parameters.Add("@iMVentaTransporte", SqlDbType.BigInt).Value = iMVentaTransporte;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MBoletoDetalle entidad = null;
                    listEntidad = new List<MBoletoDetalle>();
                    while (reader.Read())
                    {
                        entidad = new MBoletoDetalle();
                        entidad.iMPasajero = reader.GetInt64(0);
                        entidad.tPasajeroDoc = reader.GetString(1);
                        entidad.tPasajeroTipoDoc = reader.GetString(2);
                        entidad.tPasajero = reader.GetString(3);
                        entidad.tFechaViaje = reader.GetString(4);
                        entidad.tHoraViaje = reader.GetString(5);

                        entidad.iDProgramacion = reader.GetInt64(6);
                        entidad.iDProgramacionFecha = reader.GetInt64(7);
                        entidad.iDProgramacionPrecio = reader.GetInt64(8);
                        entidad.tUbicacionPdf = reader.GetString(9);
                        entidad.nDescuento = reader.GetDecimal(10);
                        entidad.iMCodigoVenta = reader.GetInt32(11);
                        entidad.nPrecio = reader.GetDecimal(12);
                        entidad.nTotalPagar = reader.GetDecimal(13);
                        entidad.lVentaGratuita = reader.GetBoolean(14);
                        entidad.tSerie = reader.GetString(15);
                        entidad.tNumero = reader.GetString(16);

                        entidad.tRuta = reader.GetString(17);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public Response MVentasBoleto_Reserva_Anular(BoletoReservaAnular data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_app_MVentas_Transporte_CancelarReserva", connection);
                command.Parameters.Add("@iMVentaTransporte", SqlDbType.BigInt).Value = data.iMVentaTransporte;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = data.tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new Response();
                        listEntidad.code = reader.GetInt32(0);
                        listEntidad.message = reader.GetString(1);
                        listEntidad.data = reader.GetInt64(2);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public Response MVentasBoleto_Transporte_Registrar(VentaBoleto data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_MVentas_Transporte_Registrar", connection);
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = data.tEmpresaRuc;
                command.Parameters.Add("@iMCliente", SqlDbType.BigInt).Value = data.iMCliente;
                command.Parameters.Add("@tClienteDoc", SqlDbType.VarChar).Value = data.tClienteDoc;
                command.Parameters.Add("@tCliente", SqlDbType.VarChar).Value = data.tCliente;
                command.Parameters.Add("@tClienteDir", SqlDbType.VarChar).Value = data.tClienteDir;
                command.Parameters.Add("@iMPasajero", SqlDbType.BigInt).Value = data.iMPasajero;
                command.Parameters.Add("@iMPasajeroTipoDoc", SqlDbType.VarChar).Value = data.iMPasajeroTipoDoc;
                command.Parameters.Add("@tPasajeroDoc", SqlDbType.VarChar).Value = data.tPasajeroDoc;
                command.Parameters.Add("@tPasajero", SqlDbType.VarChar).Value = data.tPasajero;
                command.Parameters.Add("@tTipoComprobante", SqlDbType.VarChar).Value = data.tTipoComprobante;
                command.Parameters.Add("@iDProgramacionFecha", SqlDbType.BigInt).Value = data.iDProgramacionFecha;
                command.Parameters.Add("@iMCiudadTransporteSalida", SqlDbType.Int).Value = data.iMCiudadTransporteSalida;
                command.Parameters.Add("@iMCiudadTransporteLlegada", SqlDbType.Int).Value = data.iMCiudadTransporteLlegada;
                command.Parameters.Add("@iNroAsiento", SqlDbType.VarChar).Value = data.iNroAsiento;
                command.Parameters.Add("@nPrecio", SqlDbType.Decimal).Value = data.nPrecio;
                command.Parameters.Add("@nDescuento", SqlDbType.Decimal).Value = data.nDescuento;
                command.Parameters.Add("@nTotalPagar", SqlDbType.Decimal).Value = data.nTotalPagar;
                command.Parameters.Add("@lVentaGratuita", SqlDbType.Bit).Value = data.lVentaGratuita;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new Response();
                        listEntidad.code = reader.GetInt32(0);
                        listEntidad.message = reader.GetString(1);
                        listEntidad.data = reader.GetInt64(2);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public Response MCodigoVentasTransporte_Registrar(CodigoVentaBoleto data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_MCodigoVentas_Transporte_Registrar", connection);
                command.Parameters.Add("@iMVentaTransporte", SqlDbType.BigInt).Value = data.iMVentaTransporte;
                command.Parameters.Add("@iDComprobante", SqlDbType.BigInt).Value = data.iDComprobante;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new Response();
                        listEntidad.code = reader.GetInt32(0);
                        listEntidad.message = reader.GetString(1);
                        listEntidad.data = reader.GetInt64(2);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public Response MVentasReserva_Transporte_Registrar(VentaBoleto data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_MReserva_Transporte_Registrar", connection);
                command.Parameters.Add("@iMVentaTransporte", SqlDbType.BigInt).Value = data.iMVentaTransporte;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = data.tEmpresaRuc;
                command.Parameters.Add("@iMCliente", SqlDbType.BigInt).Value = data.iMCliente;
                command.Parameters.Add("@tClienteDoc", SqlDbType.VarChar).Value = data.tClienteDoc;
                command.Parameters.Add("@tCliente", SqlDbType.VarChar).Value = data.tCliente;
                command.Parameters.Add("@tClienteDir", SqlDbType.VarChar).Value = data.tClienteDir;
                command.Parameters.Add("@iMPasajero", SqlDbType.BigInt).Value = data.iMPasajero;
                command.Parameters.Add("@iMPasajeroTipoDoc", SqlDbType.VarChar).Value = data.iMPasajeroTipoDoc;
                command.Parameters.Add("@tPasajeroDoc", SqlDbType.VarChar).Value = data.tPasajeroDoc;
                command.Parameters.Add("@tPasajero", SqlDbType.VarChar).Value = data.tPasajero;
                command.Parameters.Add("@tTipoComprobante", SqlDbType.VarChar).Value = data.tTipoComprobante;
                command.Parameters.Add("@iDProgramacionFecha", SqlDbType.BigInt).Value = data.iDProgramacionFecha;
                command.Parameters.Add("@iMCiudadTransporteSalida", SqlDbType.Int).Value = data.iMCiudadTransporteSalida;
                command.Parameters.Add("@iMCiudadTransporteLlegada", SqlDbType.Int).Value = data.iMCiudadTransporteLlegada;
                command.Parameters.Add("@iNroAsiento", SqlDbType.VarChar).Value = data.iNroAsiento;
                command.Parameters.Add("@nPrecio", SqlDbType.Decimal).Value = data.nPrecio;
                command.Parameters.Add("@nDescuento", SqlDbType.Decimal).Value = data.nDescuento;
                command.Parameters.Add("@nTotalPagar", SqlDbType.Decimal).Value = data.nTotalPagar;
                command.Parameters.Add("@lVentaGratuita", SqlDbType.Bit).Value = data.lVentaGratuita;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new Response();
                        listEntidad.code = reader.GetInt32(0);
                        listEntidad.message = reader.GetString(1);
                        listEntidad.data = reader.GetInt64(2);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public Response MVentasBoleto_Transporte_Reservar(VentaBoleto data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_MVentas_Transporte_Reservar", connection);
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = data.tEmpresaRuc;
                command.Parameters.Add("@iMPasajero", SqlDbType.BigInt).Value = data.iMPasajero;
                command.Parameters.Add("@iMPasajeroTipoDoc", SqlDbType.VarChar).Value = data.iMPasajeroTipoDoc;
                command.Parameters.Add("@tPasajeroDoc", SqlDbType.VarChar).Value = data.tPasajeroDoc;
                command.Parameters.Add("@tPasajero", SqlDbType.VarChar).Value = data.tPasajero;
                command.Parameters.Add("@iDProgramacionFecha", SqlDbType.BigInt).Value = data.iDProgramacionFecha;
                command.Parameters.Add("@iMCiudadTransporteSalida", SqlDbType.Int).Value = data.iMCiudadTransporteSalida;
                command.Parameters.Add("@iMCiudadTransporteLlegada", SqlDbType.Int).Value = data.iMCiudadTransporteLlegada;
                command.Parameters.Add("@iNroAsiento", SqlDbType.VarChar).Value = data.iNroAsiento;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new Response();
                        listEntidad.code = reader.GetInt32(0);
                        listEntidad.message = reader.GetString(1);
                        listEntidad.data = reader.GetInt64(2);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public Response MVentasBoleto_Anular(BoletoAnular data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_app_MVentas_Transporte_Anular", connection);
                command.Parameters.Add("@iMVentaTransporte", SqlDbType.BigInt).Value = data.iMVentaTransporte;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new Response();
                        listEntidad.code = reader.GetInt32(0);
                        listEntidad.message = reader.GetString(1);
                        listEntidad.data = reader.GetInt64(2);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public Response MOrdenTraslado_Registrar(OrdenTrasladoRegistrar data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DOrdenTraslado_Registrar_V1", connection);
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = data.tEmpresaRuc;
                command.Parameters.Add("@iDSucursal", SqlDbType.BigInt).Value = data.iDSucursal;
                command.Parameters.Add("@iMCiudadOrigen", SqlDbType.BigInt).Value = data.iMCiudadOrigen;
                command.Parameters.Add("@iMCiudadDestino", SqlDbType.BigInt).Value = data.iMCiudadDestino;
                command.Parameters.Add("@iMCliente", SqlDbType.BigInt).Value = data.iMCliente;
                command.Parameters.Add("@tClienteDoc", SqlDbType.VarChar).Value = data.tClienteDoc;
                command.Parameters.Add("@tCliente", SqlDbType.VarChar).Value = data.tCliente;
                command.Parameters.Add("@tClienteDir", SqlDbType.VarChar).Value = data.tClienteDir;
                command.Parameters.Add("@iMRemitente", SqlDbType.BigInt).Value = data.iMRemitente;
                command.Parameters.Add("@iMRemitenteTipoDoc", SqlDbType.VarChar).Value = data.iMRemitenteTipoDoc;
                command.Parameters.Add("@tRemitenteDoc", SqlDbType.VarChar).Value = data.tRemitenteDoc;
                command.Parameters.Add("@tRemitente", SqlDbType.VarChar).Value = data.tRemitente;
                command.Parameters.Add("@iMConsignado", SqlDbType.BigInt).Value = data.iMConsignado;
                command.Parameters.Add("@iMConsignadoTipoDoc", SqlDbType.VarChar).Value = data.iMConsignadoTipoDoc;
                command.Parameters.Add("@tConsignadoDoc", SqlDbType.VarChar).Value = data.tConsignadoDoc;
                command.Parameters.Add("@tConsignado", SqlDbType.VarChar).Value = data.tConsignado;
                command.Parameters.Add("@iPagoAnticipado", SqlDbType.Bit).Value = data.iPagoAnticipado;
                command.Parameters.Add("@iVentaGratuita", SqlDbType.Bit).Value = data.iVentaGratuita;
                command.Parameters.Add("@iDescuento", SqlDbType.Decimal).Value = data.iDescuento;
                command.Parameters.Add("@iImporteTotal", SqlDbType.Decimal).Value = data.iImporteTotal;
                command.Parameters.Add("@tTipoComprobante", SqlDbType.VarChar).Value = data.tTipoComprobante;
                command.Parameters.Add("@iUsuario", SqlDbType.BigInt).Value = data.iUsuario;
                command.Parameters.Add("@iEstado", SqlDbType.Int).Value = data.iEstado;
                command.Parameters.Add("@tJson", SqlDbType.VarChar).Value = data.productos;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new Response();
                        listEntidad.code = reader.GetInt32(0);
                        listEntidad.message = reader.GetString(1);
                        listEntidad.data = reader.GetInt64(2);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public Response MCodigoOrdenTraslado_Registrar(CodigOrdenTraslado data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_MCodigoOrdenTraslado_Transporte_Registrar", connection);
                command.Parameters.Add("@iMOrden", SqlDbType.BigInt).Value = data.iMOrden;
                command.Parameters.Add("@iDComprobante", SqlDbType.BigInt).Value = data.iDComprobante;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new Response();
                        listEntidad.code = reader.GetInt32(0);
                        listEntidad.message = reader.GetString(1);
                        listEntidad.data = reader.GetInt64(2);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public List<MOrdenTraslado> MOrdenTraslado_Listar(string tEmpresaRuc, DateTime fDesde, DateTime fHasta)
        {
            List<MOrdenTraslado> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_MOrdenTraslado_Listar_V1", connection);
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.Parameters.Add("@fDesde", SqlDbType.Date).Value = fDesde;
                command.Parameters.Add("@fHasta", SqlDbType.Date).Value = fHasta;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MOrdenTraslado entidad = null;
                    listEntidad = new List<MOrdenTraslado>();
                    while (reader.Read())
                    {
                        entidad = new MOrdenTraslado();
                        entidad.iMOrden = reader.GetInt64(0);
                        entidad.iNumero = reader.GetInt32(1);
                        entidad.tSerie = reader.GetString(2);
                        entidad.tNumero = reader.GetString(3);
                        entidad.tRemitente = reader.GetString(4);
                        entidad.tConsignado = reader.GetString(5);
                        entidad.lPAnticipado = reader.GetBoolean(6);
                        entidad.tOrigen = reader.GetString(7);
                        entidad.tDestino = reader.GetString(8);
                        entidad.tFecha = reader.GetString(9);
                        entidad.tHora = reader.GetString(10);
                        entidad.iImporteTotal = reader.GetDecimal(11);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
    }
}
