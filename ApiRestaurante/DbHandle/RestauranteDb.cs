using ApiRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.DbHandle
{
    public class RestauranteDb : GeneralDb
    {
        public List<MSalon> MSalon_Listar(string tEmpresaRuc, Int64 iDSucursal)
        {
            List<MSalon> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MSalon_Listar_V1", connection);
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.Parameters.Add("@iDSucursal", SqlDbType.BigInt).Value = iDSucursal;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MSalon entidad = null;
                    listEntidad = new List<MSalon>();
                    while (reader.Read())
                    {
                        entidad = new MSalon();
                        entidad.iMSalon = reader.GetInt64(0);
                        entidad.tSalon = reader.GetString(1);
                        entidad.tColor = reader.GetString(2);
                        entidad.tObservacion = reader.GetString(3);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public List<MMesa> MMesa_Listar(Int64 iMSalon)
        {
            List<MMesa> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MMesa_Listar_V1", connection);
                command.Parameters.Add("@iMSalon", SqlDbType.BigInt).Value = iMSalon;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MMesa entidad = null;
                    listEntidad = new List<MMesa>();
                    while (reader.Read())
                    {
                        entidad = new MMesa();
                        entidad.iMMesa = reader.GetInt64(0);
                        entidad.tMesa = reader.GetString(1);
                        entidad.tColor = reader.GetString(2);
                        entidad.tEstado = reader.GetString(3);
                        entidad.tHora = reader.GetString(4);
                        entidad.nImporte = reader.GetDecimal(5);
                        entidad.tCliente = reader.GetString(6);
                        entidad.iPax = reader.GetInt32(7);
                        entidad.iDPedido = reader.GetInt64(8);
                        entidad.tMesaUnion = reader.GetString(9);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public List<DPedidoDetalle> DPedidoDetalle_Listar(Int64 iMMesa, string tEmpresaRuc)
        {
            List<DPedidoDetalle> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DPedidoDetalle_Listar_V2", connection);
                command.Parameters.Add("@iMMesa", SqlDbType.BigInt).Value = iMMesa;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    DPedidoDetalle entidad = null;
                    listEntidad = new List<DPedidoDetalle>();
                    while (reader.Read())
                    {
                        entidad = new DPedidoDetalle();
                        entidad.iDPedidoDetalle = reader.GetInt64(0);
                        entidad.nCantidad = reader.GetDecimal(1);
                        entidad.iMProducto = reader.GetInt64(2);
                        entidad.tProducto = reader.GetString(3);
                        entidad.nPrecioUnitario = reader.GetDecimal(4);
                        entidad.nTotal = reader.GetDecimal(5);
                        entidad.tObservacion = reader.GetString(6);
                        entidad.nAdicional = reader.GetDecimal(7);
                        entidad.lCortesia = reader.GetBoolean(8);
                        entidad.fRegistro = reader.GetString(9);
                        entidad.tUsuario = reader.GetString(10);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public DPedidoDetalleId DPedidoDetalle_ListarPorId(Int64 iDPedidoDetalle)
        {
            DPedidoDetalleId listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DPedidoDetalle_ListarPorId_V1", connection);
                command.Parameters.Add("@iDPedidoDetalle", SqlDbType.BigInt).Value = iDPedidoDetalle;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new DPedidoDetalleId();
                        listEntidad.iDPedidoDetalle = reader.GetInt64(0);
                        listEntidad.iMProducto = reader.GetInt64(1);
                        listEntidad.lCortesia = reader.GetBoolean(2);
                        listEntidad.tObservacion = reader.GetString(3);
                        listEntidad.iTipoConsumo = reader.GetInt32(4);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public List<MCategoria> MCategoria_Listar(string tEmpresaRuc)
        {
            List<MCategoria> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MCategoria_Listar_V1", connection);
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MCategoria entidad = null;
                    listEntidad = new List<MCategoria>();
                    while (reader.Read())
                    {
                        entidad = new MCategoria();
                        entidad.iMCategoria = reader.GetInt64(0);
                        entidad.tCategoria = reader.GetString(1);
                        entidad.iMImpresora = reader.GetInt64(2);
                        entidad.tImpresora = reader.GetString(3);
                        entidad.SubCategoria = MSubCategoria_Listar(reader.GetInt64(0));
                        if (entidad.SubCategoria == null) entidad.SubCategoria = new List<MSubCategoria>();
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public List<MSubCategoria> MSubCategoria_Listar(Int64 iMCategoria)
        {
            List<MSubCategoria> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MSubCategoria_Listar_V1", connection);
                command.Parameters.Add("@iMCategoria", SqlDbType.BigInt).Value = iMCategoria;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MSubCategoria entidad = null;
                    listEntidad = new List<MSubCategoria>();
                    while (reader.Read())
                    {
                        entidad = new MSubCategoria();
                        entidad.iMSubCategoria = reader.GetInt64(0);
                        entidad.tSubCategoria = reader.GetString(1);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public List<MProducto> MProductos_Listar(string tEmpresaRuc)
        {
            List<MProducto> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MProducto_Listar_V1", connection);
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MProducto entidad = null;
                    listEntidad = new List<MProducto>();
                    while (reader.Read())
                    {
                        entidad = new MProducto();
                        entidad.iMProducto = reader.GetInt64(0);
                        entidad.tProducto = reader.GetString(1);
                        entidad.tImagenProducto = reader.GetString(2);
                        entidad.nPrecioUnitario = reader.GetDecimal(3);
                        entidad.iMCategoria = reader.GetInt64(4);
                        entidad.iMSubCategoria = reader.GetInt64(5);
                        entidad.tSubCategoria = reader.GetString(6);
                        entidad.Operadores = MOperador_Listar(reader.GetInt64(0)); 
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public List<MOperador> MOperador_Listar(Int64 iMProducto)
        {
            List<MOperador> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MOperador_Listar_V1", connection);
                command.Parameters.Add("@iMProducto", SqlDbType.BigInt).Value = iMProducto;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MOperador entidad = null;
                    listEntidad = new List<MOperador>();
                    while (reader.Read())
                    {
                        entidad = new MOperador();
                        entidad.iMOperador = reader.GetInt64(0);
                        entidad.tOperador = reader.GetString(1);
                        entidad.iSeleccion = reader.GetInt32(2);
                        entidad.Propiedades = MPropiedad_Listar(reader.GetInt64(0));
                        if (entidad.Propiedades == null) entidad.Propiedades = new List<MPropiedad>();
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public List<MPropiedad> MPropiedad_Listar(Int64 iMOperador)
        {
            List<MPropiedad> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MPropiedad_Listar_V1", connection);
                command.Parameters.Add("@iMOperador", SqlDbType.BigInt).Value = iMOperador;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MPropiedad entidad = null;
                    listEntidad = new List<MPropiedad>();
                    while (reader.Read())
                    {
                        entidad = new MPropiedad();
                        entidad.iMPropiedad = reader.GetInt64(0);
                        entidad.tPropiedad = reader.GetString(1);
                        entidad.lPorDefecto = reader.GetBoolean(2);
                        entidad.nPrecioAdicional = reader.GetDecimal(3);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public Response DPedido_Registrar(DPedido data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DPedido_Registrar_V1", connection);
                command.Parameters.Add("@iMMesa", SqlDbType.BigInt).Value = data.iMMesa;
                command.Parameters.Add("@tCliente", SqlDbType.VarChar).Value = data.tCliente;
                command.Parameters.Add("@iPax", SqlDbType.Int).Value = data.iPax;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = data.tEmpresaRuc;
                command.Parameters.Add("@iDSucursal", SqlDbType.BigInt).Value = data.iDSucursal;
                command.Parameters.Add("@iUsuarioRegistro", SqlDbType.Int).Value = data.iUsuarioRegistro;
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
        public Response DPedidoDetalle_Registrar(DPedidoProducto data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DPedidoDetalle_Registrar_V3", connection);
                command.Parameters.Add("@iDPedido", SqlDbType.BigInt).Value = data.iDPedido;
                command.Parameters.Add("@tJson", SqlDbType.VarChar).Value = data.productos;

                command.Parameters.Add("@iDFormatoOrden", SqlDbType.BigInt).Value = data.iDFormatoOrden;
                command.Parameters.Add("@iConexion", SqlDbType.Int).Value = data.iConexion;
                command.Parameters.Add("@iUsuario", SqlDbType.BigInt).Value = data.iUsuario;
                command.Parameters.Add("@tAndroInfo", SqlDbType.VarChar).Value = data.tAndroInfo;
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
        public Response DPedido_Precuenta(Int64 iDPedido, Int64 iDFormato)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DPedido_Precuenta_V1", connection);
                command.Parameters.Add("@iDPedido", SqlDbType.BigInt).Value = iDPedido;
                command.Parameters.Add("@iDFormatoOrden", SqlDbType.BigInt).Value = iDFormato;
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
        public Response DPedidoDetalle_Anular(DPedidoDetalleAnular data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DPedidoDetalle_Anular_V2", connection);
                command.Parameters.Add("@iDPedido", SqlDbType.BigInt).Value = data.iDPedido;
                command.Parameters.Add("@iUsuarioRegistro", SqlDbType.BigInt).Value = data.iUsuarioRegistro;
                command.Parameters.Add("@tJson", SqlDbType.VarChar).Value = data.productos;
                command.Parameters.Add("@iDFormatoOrden", SqlDbType.BigInt).Value = data.iDFormatoAnulacion;
                command.Parameters.Add("@iConexion", SqlDbType.Int).Value = data.iConexion;
                command.Parameters.Add("@tAndroInfo", SqlDbType.VarChar).Value = data.tAndroInfo;
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

        public Response DPedidoDetalle_AnularQA(DPedidoDetalleAnularQA data)
        {   
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DPedidoDetalle_Anular_V2QA", connection);
                command.Parameters.Add("@iDPedido", SqlDbType.BigInt).Value = data.iDPedido;
                command.Parameters.Add("@iUsuarioRegistro", SqlDbType.BigInt).Value = data.iUsuarioRegistro;
                command.Parameters.Add("@tJson", SqlDbType.VarChar).Value = data.productos;
                command.Parameters.Add("@iDFormatoOrden", SqlDbType.BigInt).Value = data.iDFormatoAnulacion;
                command.Parameters.Add("@iConexion", SqlDbType.Int).Value = data.iConexion;
                command.Parameters.Add("@tAndroInfo", SqlDbType.VarChar).Value = data.tAndroInfo;
                command.Parameters.Add("@reasonID", SqlDbType.BigInt).Value = data.reasonId;
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

        public DFormato DFormatoEmpresa_Listar(string tEmpresaRuc, Int64 iDSucursal)
        {
            DFormato listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DFormato_PorEmpresa_V1", connection);
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.Parameters.Add("@iDSucursal", SqlDbType.BigInt).Value = iDSucursal;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new DFormato();
                        listEntidad.iDFormatoPrecuenta = reader.GetInt64(0);
                        listEntidad.iDFormatoOrden = reader.GetInt64(1);
                        listEntidad.iDFormatoAnulacion = reader.GetInt64(2);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public Response DUnirMesas(DUnirMesas data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_UnionMesa_Registrar_V1", connection);
                command.Parameters.Add("@iMMesaPrincipal", SqlDbType.BigInt).Value = data.iMMesaPrincipal;
                command.Parameters.Add("@tJson", SqlDbType.VarChar).Value = data.mesas;
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

        public Response DDesUnirMesas(DDesUnirMesas data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DesUnionMesa_Registrar_V1", connection);
                command.Parameters.Add("@iMMesa", SqlDbType.BigInt).Value = data.iMMesa;
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

        public Response DTransferirMesa(DTransferirMesa data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_TransferirMesa_Registrar_V1", connection);
                command.Parameters.Add("@iMMesaOrigen", SqlDbType.BigInt).Value = data.iMMesaOrigen;
                command.Parameters.Add("@iMMesaDestino", SqlDbType.BigInt).Value = data.iMMesaDestino;
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
        public List<MLlevarDelivery> MParaLlevarDelivery_Listar(Int64 iMCanal, Int64 iDSucursal)
        {
            List<MLlevarDelivery> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MMesaLlevarDelivery_Listar_V1", connection);
                command.Parameters.Add("@iMCanal", SqlDbType.BigInt).Value = iMCanal;
                command.Parameters.Add("@iDSucursal", SqlDbType.BigInt).Value = iDSucursal;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MLlevarDelivery entidad = null;
                    listEntidad = new List<MLlevarDelivery>();
                    while (reader.Read())
                    {
                        entidad = new MLlevarDelivery();
                        entidad.iDPedido = reader.GetInt64(0);
                        entidad.tDescripcion = reader.GetString(1);
                        entidad.tClienteResponsable = reader.GetString(2);
                        entidad.iCapacidad = reader.GetInt32(3);
                        entidad.nTotal = reader.GetDecimal(4);
                        entidad.tHora = reader.GetString(5);
                        entidad.iEstado = reader.GetInt32(6);
                        entidad.iEstadoPago = reader.GetInt32(7);
                        entidad.iEstadoEnvio = reader.GetInt32(8);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public Response DLiberar(DLiberarMesa data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MMesa_Liberar_V3", connection);
                command.Parameters.Add("@iMMesa", SqlDbType.BigInt).Value = data.iMMesa;
                command.Parameters.Add("@iDPedido", SqlDbType.BigInt).Value = data.iDPedido;
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

        public Response DPedidoOrdenLlevar_Registrar(DPedidoOrdenLlevar data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DPedidoLlevar_Registrar_V2", connection);
                command.Parameters.Add("@iDPedido", SqlDbType.BigInt).Value = data.iDPedido;
                command.Parameters.Add("@tJson", SqlDbType.VarChar).Value = data.productos;
                command.Parameters.Add("@tCliente", SqlDbType.VarChar).Value = data.tCliente;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = data.tEmpresaRuc;
                command.Parameters.Add("@iDSucursal", SqlDbType.BigInt).Value = data.iDSucursal;
                command.Parameters.Add("@iUsuarioRegistro", SqlDbType.Int).Value = data.iUsuarioRegistro;
                command.Parameters.Add("@tVersionApp", SqlDbType.VarChar).Value = data.tVersionApp;

                command.Parameters.Add("@iDFormatoOrden", SqlDbType.BigInt).Value = data.iDFormatoOrden;
                command.Parameters.Add("@iConexion", SqlDbType.Int).Value = data.iConexion;
                command.Parameters.Add("@tAndroInfo", SqlDbType.VarChar).Value = data.tAndroInfo;
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

        public Response DPedidoOrdenDelivery_Registrar(DPedidoOrdenDelivery data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DPedidoDelivery_Registrar_V2", connection);
                command.Parameters.Add("@iDPedido", SqlDbType.BigInt).Value = data.iDPedido;
                command.Parameters.Add("@tJson", SqlDbType.VarChar).Value = data.productos;
                command.Parameters.Add("@tTelefono", SqlDbType.VarChar).Value = data.tTelefono;
                command.Parameters.Add("@tCliente", SqlDbType.VarChar).Value = data.tCliente;
                command.Parameters.Add("@tDireccion", SqlDbType.VarChar).Value = data.tDireccion;
                command.Parameters.Add("@tReferencia", SqlDbType.VarChar).Value = data.tReferencia;
                command.Parameters.Add("@iZona", SqlDbType.BigInt).Value = data.iZona;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = data.tEmpresaRuc;
                command.Parameters.Add("@iDSucursal", SqlDbType.BigInt).Value = data.iDSucursal;
                command.Parameters.Add("@iUsuarioRegistro", SqlDbType.Int).Value = data.iUsuarioRegistro;
                command.Parameters.Add("@tVersionApp", SqlDbType.VarChar).Value = data.tVersionApp;

                command.Parameters.Add("@iDFormatoOrden", SqlDbType.BigInt).Value = data.iDFormatoOrden;
                command.Parameters.Add("@iConexion", SqlDbType.Int).Value = data.iConexion;
                command.Parameters.Add("@tAndroInfo", SqlDbType.VarChar).Value = data.tAndroInfo;
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

        public List<DPedidoDetalle> DPedidoDetalleLlevar_Listar(Int64 iDPedido, string tEmpresaRuc)
        {
            List<DPedidoDetalle> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DPedidoDetalleLlevar_Listar_V2", connection);
                command.Parameters.Add("@iDPedido", SqlDbType.BigInt).Value = iDPedido;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    DPedidoDetalle entidad = null;
                    listEntidad = new List<DPedidoDetalle>();
                    while (reader.Read())
                    {
                        entidad = new DPedidoDetalle();
                        entidad.iDPedidoDetalle = reader.GetInt64(0);
                        entidad.nCantidad = reader.GetDecimal(1);
                        entidad.iMProducto = reader.GetInt64(2);
                        entidad.tProducto = reader.GetString(3);
                        entidad.nPrecioUnitario = reader.GetDecimal(4);
                        entidad.nTotal = reader.GetDecimal(5);
                        entidad.tObservacion = reader.GetString(6);
                        entidad.nAdicional = reader.GetDecimal(7);
                        entidad.lCortesia = reader.GetBoolean(8);
                        entidad.fRegistro = reader.GetString(9);
                        entidad.tUsuario = reader.GetString(10);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public List<MZonaDelivery> MZona_Listar(Int64 iDSucursal)
        {
            List<MZonaDelivery> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MZonaDelivery_Listar_V1", connection);
                command.Parameters.Add("@iDSucursal", SqlDbType.BigInt).Value = iDSucursal;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MZonaDelivery entidad = null;
                    listEntidad = new List<MZonaDelivery>();
                    while (reader.Read())
                    {
                        entidad = new MZonaDelivery();
                        entidad.iMZonaDelivery = reader.GetInt64(0);
                        entidad.tZona = reader.GetString(1);
                        entidad.iPrecio = reader.GetDecimal(2);
                        entidad.iMProductoDelivery = reader.GetInt64(3);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public List<MClienteDelivery> MClienteDelivery_Listar(string tTelefono, Int64 iDSucursal)
        {
            List<MClienteDelivery> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MClienteDelivery_BuscarPorTelefono_Listar_V1", connection);
                command.Parameters.Add("@tTelefono", SqlDbType.VarChar).Value = tTelefono;
                command.Parameters.Add("@iDSucursal", SqlDbType.BigInt).Value = iDSucursal;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MClienteDelivery entidad = null;
                    listEntidad = new List<MClienteDelivery>();
                    while (reader.Read())
                    {
                        entidad = new MClienteDelivery();
                        entidad.tTelefono = reader.GetString(0);
                        entidad.tNombre = reader.GetString(1);
                        entidad.tDireccion = reader.GetString(2);
                        entidad.tReferencia = reader.GetString(3);
                        entidad.iMZona = reader.GetInt64(4);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public Response DPedidoDelivery_Registrar(DPedidoDelivery data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MDeliveryPrevio_Registrar_V1", connection);
                command.Parameters.Add("@iDPedido", SqlDbType.BigInt).Value = data.iDPedido;
                command.Parameters.Add("@tTelefono", SqlDbType.VarChar).Value = data.tTelefono;
                command.Parameters.Add("@tNombre", SqlDbType.VarChar).Value = data.tNombre;
                command.Parameters.Add("@tDireccion", SqlDbType.VarChar).Value = data.tDireccion;
                command.Parameters.Add("@tReferencia", SqlDbType.VarChar).Value = data.tReferencia;
                command.Parameters.Add("@iMZona", SqlDbType.BigInt).Value = data.iMZona;
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

        public List<MReason> MGetReasonByEnterprise(string ruc)
        {
            List<MReason> Reasonlist = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_lm_MListarMotivosBajaPedido", connection);
                command.Parameters.Add("@tRucEmpresa", SqlDbType.VarChar).Value = ruc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MReason reason = null;
                    Reasonlist = new List<MReason>();
                    while (reader.Read())
                    {
                        reason = new MReason();
                        reason.iMMotivoBajaPedido = reader.GetInt64(0);
                        reason.tDescripcion = reader.GetString(1);
                        Reasonlist.Add(reason);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return Reasonlist;
        }


    }
}
