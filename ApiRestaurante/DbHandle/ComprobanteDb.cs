using ApiRestaurante.Models;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.DbHandle
{
    public class ComprobanteDb : GeneralDb
    {
        public List<MessageOut> JsonLog_Registrar(int ComprobanteId, int UsuarioId, string JsonLogBody)
        {
            List<MessageOut> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_JsonLog_Registrar", connection);
                command.Parameters.Add("@ComprobanteId", SqlDbType.Int).Value = ComprobanteId;
                command.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                command.Parameters.Add("@JsonLogBody", SqlDbType.VarChar).Value = JsonLogBody;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MessageOut entidad = null;
                    listEntidad = new List<MessageOut>();
                    while (reader.Read())
                    {
                        entidad = new MessageOut();
                        entidad.MessageResult = reader.GetString(0);
                        entidad.MessageValue = reader.GetString(1);

                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public MessageOut Comprobante_Cotizacion_Registrar_V1(Int64 codigo_venta, int iTipo)
        {
            MessageOut listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_Comprobante_Cotizacion_Registrar_V2", connection);
                command.Parameters.Add("@CODIGO_VENTA", SqlDbType.BigInt).Value = codigo_venta;
                command.Parameters.Add("@ITIPO", SqlDbType.Int).Value = iTipo;
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
        public MessageOut Comprobante_Verificar_Promocion(Int64 codigo_venta, int iVentasPromocionCantidad)
        {
            MessageOut listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_Comprobante_Verificar_Promocion_V1", connection);
                command.Parameters.Add("@codigo_venta", SqlDbType.BigInt).Value = codigo_venta;
                command.Parameters.Add("@iVentasPromocionCantidad", SqlDbType.Int).Value = iVentasPromocionCantidad;
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

        public List<Comprobante> selectComprobantes(int Comprobante_Id)
        {
            List<Comprobante> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("wsp_Comprobantes_Select_V8", connection);
                command.Parameters.Add("@ComprobanteId_ ", SqlDbType.Int).Value = Comprobante_Id;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    Comprobante entidad = null;
                    listEntidad = new List<Comprobante>();
                    while (reader.Read())
                    {
                        entidad = new Comprobante();
                        entidad.ComprobanteId = reader.GetInt32(0);
                        entidad.RucEmisor = reader.GetString(1);
                        entidad.FechaEmision = reader.GetString(2);
                        entidad.RucCliente = reader.GetString(3);
                        entidad.RazonSocialCliente = reader.GetString(4);
                        entidad.DireccionCliente = reader.GetString(5);
                        entidad.CorreoCliente = reader.GetString(6);
                        entidad.TipoDocumento = reader.GetString(7);
                        entidad.Serie = reader.GetString(8);
                        entidad.Numero = reader.GetString(9);
                        entidad.TipoDocOrigen = reader.GetString(10);
                        entidad.SerieOrigen = reader.GetString(11);
                        entidad.NumeroOrigen = reader.GetString(12);
                        entidad.Moneda = reader.GetString(13);
                        entidad.TipoCambio = reader.GetDecimal(14).ToString();
                        entidad.Importe = reader.GetDecimal(15).ToString();
                        entidad.Subtotal = reader.GetDecimal(16).ToString();
                        entidad.Descuento = reader.GetDecimal(17).ToString();
                        entidad.Igv = reader.GetDecimal(18).ToString();
                        entidad.EstadoDocumento = reader.GetString(19);
                        entidad.EstadoSunat = reader.GetString(20);
                        entidad.FechaEnvio = reader.GetString(21);
                        entidad.DirectorioXml = reader.GetString(22);
                        entidad.DirectorioZip = reader.GetString(23);
                        entidad.DirectorioPdf = reader.GetString(24);
                        entidad.DirectorioZipSunat = reader.GetString(25);
                        entidad.Anulado = reader.GetString(26);
                        entidad.FechaAnulado = reader.GetString(27);
                        entidad.MotivoBaja = reader.GetString(28);
                        entidad.EmailsEnviados = reader.GetInt32(29);
                        entidad.NResumenes = reader.GetInt32(30);
                        entidad.EnviadoPortal = reader.GetInt32(31);
                        entidad.Empresa = reader.GetString(32);
                        entidad.FechaOrigen = reader.GetString(33);
                        entidad.IsDayAutorized = reader.GetInt32(34);
                        entidad.UsuarioRegistra = reader.GetString(35);
                        entidad.monto_detraccion = reader.GetDecimal(36);
                        entidad.texto_detraccion = reader.GetString(37);
                        entidad.Observacion = reader.GetString(38);
                        entidad.OrdenCompra = reader.GetString(39);
                        entidad.PlacaVehiculo = reader.GetString(40);
                        entidad.ModalidadPago = reader.GetString(41);
                        entidad.Requerimiento = reader.GetString(42);
                        entidad.FechaVencimiento = reader.GetString(43);
                        entidad.FechaRegistro = reader.GetString(44);
                        entidad.IdTipo_Doc = reader.GetString(45);
                        entidad.IsLast = reader.GetBoolean(46);
                        entidad.UbicacionPDF = reader.GetString(47);
                        entidad.tTransporteConsignatario = reader.GetString(48);
                        entidad.tTransporteOrigen = reader.GetString(49);
                        entidad.tTransporteDestinp = reader.GetString(50);
                        entidad.tEmbarcacionPesquera = reader.GetString(51);
                        entidad.tLiquidacion = reader.GetString(52);
                        entidad.tTicket = reader.GetString(53);
                        entidad.DiasTranscurridos = reader.GetInt32(54);
                        entidad.nDiasAnulacion = reader.GetInt32(55);
                        entidad.iDAlmacen = reader.GetInt64(56);
                        entidad.gratuitas = reader.GetDecimal(57);
                        entidad.inafectas = reader.GetDecimal(58);
                        entidad.exoneradas = reader.GetDecimal(59);
                        entidad.recargo_consumo = reader.GetDecimal(60);
                        entidad.exportacion = reader.GetDecimal(61);
                        entidad.iMVendedor = reader.GetInt64(62);
                        entidad.tVendedor = reader.GetString(63);
                        entidad.ICBPer = reader.GetDecimal(64);
                        entidad.nPendiente = reader.GetDecimal(66);
                        entidad.nCancelado = reader.GetDecimal(67);
                        entidad.tDireccionEmisor = reader.GetString(68);
                        entidad.tTelefonoEmisor = reader.GetString(69);
                        entidad.tMontoLetras = reader.GetString(70);
                        entidad.emp_nomcomercial = reader.GetString(71);
                        entidad.tipo_nc = reader.GetString(72);
                        entidad.sustento_nc = reader.GetString(73);
                        entidad.correlativo_mod_nc = reader.GetString(74);
                        entidad.doc_mod_nc = reader.GetString(75);
                        entidad.fec_mod_nc = reader.GetString(76);
                        entidad.tipo_doc = reader.GetString(77);
                        entidad.hash = reader.GetString(78);
                        entidad.mensaje_consulta = reader.GetString(79);
                        entidad.doc_cliente = reader.GetString(80);
                        entidad.cdp_moneda = reader.GetString(81);
                        entidad.iTransporteOrigen = reader.GetInt64(82);
                        entidad.iTransporteDestino = reader.GetInt64(83);
                        entidad.tOrigenVenta = reader.GetString(84);
                        entidad.tGuiaRemision = reader.GetString(85);
                        entidad.iDSucursalVenta = reader.GetInt64(86);
                        entidad.tCiudadTransporteOrigen = reader.GetString(87);
                        entidad.tCiudadTransporteDestino = reader.GetString(88);
                        entidad.tConsignatarioEncomienda = reader.GetString(89);
                        entidad.lPagado = reader.GetBoolean(90);
                        entidad.PendientePago = reader.GetDecimal(91);
                        entidad.iMDetraccion = reader.GetInt32(92);
                        entidad.lRetencionIGV = reader.GetBoolean(93);
                        entidad.nRetencionIGV = reader.GetDecimal(94);
                        entidad.nRetencionIGVPorcentaje = reader.GetDecimal(95);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public List<Models.Library> selectDocumentoSerieByTipo(string RucEmpresa, string TipoDoc, int iDSucursal, int UsuarioId, bool? lTransporte)
        {
            List<Models.Library> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("wsp_ComprobantesSerie_SelectByTipo_V4", connection);
                command.Parameters.Add("@RucEmpresa", SqlDbType.VarChar).Value = RucEmpresa;
                command.Parameters.Add("@TipoDoc", SqlDbType.VarChar).Value = TipoDoc;
                command.Parameters.Add("@iDSucursal", SqlDbType.Int).Value = iDSucursal;
                command.Parameters.Add("@iDUsuario", SqlDbType.Int).Value = UsuarioId;
                command.Parameters.Add("@lTransporte", SqlDbType.Bit).Value = lTransporte;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    Models.Library entidad = null;
                    listEntidad = new List<Models.Library>();
                    while (reader.Read())
                    {
                        entidad = new Models.Library();
                        entidad.DocumentoSerie = reader.GetString(0);
                        entidad.FormatoPdf = reader.GetString(1);
                        entidad.tServicio = reader.GetString(2);
                        entidad.tTipo = reader.GetString(3);
                        entidad.iNumeracion = reader.GetInt32(4);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;

        }

        public List<UnidadMedida> selectNumeroDoc(string TipoDoc, string SerieDoc, string RucEmisor)
        {
            List<UnidadMedida> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("wsp_ComprobantesNumero_SelectBySerie_V2", connection);
                command.Parameters.Add("@TipoDoc", SqlDbType.VarChar).Value = TipoDoc;
                command.Parameters.Add("@SerieDoc", SqlDbType.VarChar).Value = SerieDoc;
                command.Parameters.Add("@RucEmisor", SqlDbType.VarChar).Value = RucEmisor;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    UnidadMedida entidad = null;
                    listEntidad = new List<UnidadMedida>();
                    while (reader.Read())
                    {
                        entidad = new UnidadMedida();
                        entidad.codigo = reader.GetInt32(0).ToString();
                        entidad.uFecha = reader.GetString(1);
                        entidad.rFecha = reader.GetString(2);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public List<MessageOut> comprobante_sendMail(int Comprobante, string Correo, string autoriza, string Mensaje)
        {
            List<MessageOut> list = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("wsp_Comprobante_SendMail", connection);
                command.Parameters.Add("@CodigoVenta", SqlDbType.Int).Value = Comprobante;
                command.Parameters.Add("@NCorreo", SqlDbType.VarChar).Value = Correo;
                command.Parameters.Add("@Autoriza", SqlDbType.VarChar).Value = autoriza;
                command.Parameters.Add("@Mensaje", SqlDbType.VarChar).Value = Mensaje;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MessageOut entidad = null;
                    list = new List<MessageOut>();
                    while (reader.Read())
                    {
                        entidad = new MessageOut();
                        entidad.MessageResult = reader.GetString(0);
                        entidad.MessageValue = reader.GetString(1);
                        list.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return list;
        }
    }
}
