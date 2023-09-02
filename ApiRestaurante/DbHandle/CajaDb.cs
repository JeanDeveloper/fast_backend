using ApiRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.DbHandle
{
    public class CajaDb : GeneralDb
    {
        public List<MCajaDiaria> MCajaDiaria_Listar(string tEmpresaRuc, DateTime fFechaInicio, DateTime fFechaFin)
        {
            List<MCajaDiaria> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_cd_DCajaDiaria_Listar", connection);
                command.Parameters.Add("@fFechaInicio", SqlDbType.Date).Value = fFechaInicio;
                command.Parameters.Add("@fFechaFin", SqlDbType.Date).Value = fFechaFin;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MCajaDiaria entidad = null;
                    listEntidad = new List<MCajaDiaria>();
                    while (reader.Read())
                    {
                        entidad = new MCajaDiaria();
                        entidad.iDCajaDiaria = reader.GetInt64(0);
                        entidad.fFecha = reader.GetString(1);
                        entidad.iMCaja = reader.GetInt64(2);
                        entidad.tMCaja = reader.GetString(3);
                        entidad.iDSucursal = reader.GetInt64(4);
                        entidad.tDSucursal = reader.GetString(5);
                        entidad.nInicial = reader.GetDecimal(8);
                        entidad.iEstado = reader.GetInt32(9);
                        entidad.iMResponsable = reader.GetInt64(11);
                        entidad.tMResponsable = reader.GetString(12);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public Response DCajaDiaria_Registrar(CajaDiariaRegistrar data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_DCajaDiaria_Registrar", connection);
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = data.tEmpresaRuc;
                command.Parameters.Add("@iMCaja", SqlDbType.BigInt).Value = data.iMCaja;
                command.Parameters.Add("@iDSucursal", SqlDbType.BigInt).Value = data.iDSucursal;
                command.Parameters.Add("@iResponsable", SqlDbType.BigInt).Value = data.iResponsable;
                command.Parameters.Add("@iMoneda", SqlDbType.BigInt).Value = data.iMoneda;
                command.Parameters.Add("@nInicial", SqlDbType.Decimal).Value = data.nInicial;
                command.Parameters.Add("@iUsuarioRegistro", SqlDbType.BigInt).Value = data.iUsuarioRegistro;
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

        public List<MCajaDiariaBuscarPorId> DCajaDiaria_BuscarPorId(string iDCajaDiaria)
        {
            List<MCajaDiariaBuscarPorId> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_cd_DCajaDiaria_BuscarPorId_V4", connection);
                command.Parameters.Add("@iDCajaDiaria", SqlDbType.BigInt).Value = iDCajaDiaria;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MCajaDiariaBuscarPorId entidad = null;
                    listEntidad = new List<MCajaDiariaBuscarPorId>();
                    while (reader.Read())
                    {
                        entidad = new MCajaDiariaBuscarPorId();
                        entidad.iMCaja = reader.GetInt64(2);
                        entidad.tMCaja = reader.GetString(3);
                        entidad.nInicial = reader.GetDecimal(8);
                        entidad.iEstado = reader.GetInt32(9);
                        entidad.nImporteFinal = reader.GetDecimal(15);
                        entidad.nTotalEgresos = reader.GetDecimal(17);
                        entidad.nTotalIngresos = reader.GetDecimal(18);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public List<TerminalCajaDiaria> MTerminal_DCajaDiaria_Importe_Buscar(Int64 iMCaja, Int64 iDCajaDiaria)
        {
            List<TerminalCajaDiaria> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_wb_MTerminal_DCajaDiaria_Importe_Buscar", connection);
                command.Parameters.Add("@iMCaja", SqlDbType.BigInt).Value = iMCaja;
                command.Parameters.Add("@iDCajaDiaria", SqlDbType.BigInt).Value = iDCajaDiaria;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    TerminalCajaDiaria entidad = null;
                    listEntidad = new List<TerminalCajaDiaria>();
                    while (reader.Read())
                    {
                        entidad = new TerminalCajaDiaria();
                        entidad.iMTerminal = reader.GetInt64(0);
                        entidad.tNombre = reader.GetString(2);
                        entidad.tBanco = reader.GetString(9);
                        entidad.iImporte = reader.GetDecimal(11);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public List<CajaDiariaDetalle> DCajaDiariaDetalle_Listar(Int64 iDCajaDiaria, int iTipo)
        {
            List<CajaDiariaDetalle> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_cd_DCajaDiariaDetalle_Listar_V9", connection);
                command.Parameters.Add("@iDCajaDiaria", SqlDbType.BigInt).Value = iDCajaDiaria;
                command.Parameters.Add("@iTipo", SqlDbType.Int).Value = iTipo;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    CajaDiariaDetalle entidad = null;
                    listEntidad = new List<CajaDiariaDetalle>();
                    while (reader.Read())
                    {
                        entidad = new CajaDiariaDetalle();
                        entidad.iDCajaDiariaDetalle = reader.GetInt64(0);
                        entidad.fFecha = reader.GetString(2);
                        entidad.tMotivo = reader.GetString(6);
                        entidad.tDescripcion = reader.GetString(7);
                        entidad.tNombreCliente = reader.GetString(9);
                        entidad.nEfectivo = reader.GetDecimal(16);
                        entidad.nTarjeta = reader.GetDecimal(17);
                        entidad.nNotaCredito = reader.GetDecimal(18);
                        entidad.nImporte = reader.GetDecimal(19);
                        entidad.iEstado = reader.GetInt32(20);
                        entidad.tTipoComprobante = reader.GetString(32);
                        entidad.tNroComprobante = reader.GetString(33);
                        
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public Response DCajaDiaria_Cerrar(CajaDiariaCerrar data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_DCajaDiaria_Cerrar", connection);
                command.Parameters.Add("@iDCajaDiaria", SqlDbType.BigInt).Value = data.iDCajaDiaria;
                command.Parameters.Add("@iUsuario", SqlDbType.BigInt).Value = data.iUsuario;
                //command.Parameters.Add("@tObservacionesCierre", SqlDbType.VarChar).Value = data.tObservacionesCierre;
                //command.Parameters.Add("@tEmailCierreCaja", SqlDbType.VarChar).Value = data.tEmailCierreCaja;
                command.Parameters.Add("@lReabrirCaja", SqlDbType.Int).Value = data.lReabrirCaja;
                //command.Parameters.Add("@nSobrante", SqlDbType.Decimal).Value = data.nSobrante;
                //command.Parameters.Add("@nFaltante", SqlDbType.Decimal).Value = data.nFaltante;
                //command.Parameters.Add("@nEfectivoFisico", SqlDbType.Decimal).Value = data.nEfectivoFisico;
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
        public List<CajaDiariaAbiertaUsuario> DCajaDiariaAbiertaUsuario_Listar(DateTime fFechaInicio, DateTime fFechaFin, string tEmpresaRuc, Int64 iDSucursal, Int64 iMUsuario)
        {
            List<CajaDiariaAbiertaUsuario> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_DCajaDiariaAbiertaUsuario_Listar", connection);
                command.Parameters.Add("@fFechaInicio", SqlDbType.Date).Value = fFechaInicio;
                command.Parameters.Add("@fFechaFin", SqlDbType.Date).Value = fFechaFin;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.Parameters.Add("@iDSucursal", SqlDbType.BigInt).Value = iDSucursal;
                command.Parameters.Add("@iMUsuario", SqlDbType.BigInt).Value = iMUsuario;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    CajaDiariaAbiertaUsuario entidad = null;
                    listEntidad = new List<CajaDiariaAbiertaUsuario>();
                    while (reader.Read())
                    {
                        entidad = new CajaDiariaAbiertaUsuario();
                        entidad.iDCajaDiaria = reader.GetInt64(0);
                        entidad.fFecha = reader.GetString(1);
                        entidad.iMCaja = reader.GetInt64(2);
                        entidad.tMCaja = reader.GetString(3);
                        entidad.iDSucursal = reader.GetInt64(4);
                        entidad.tDSucursal = reader.GetString(5);
                        entidad.iMoneda = reader.GetInt32(6);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public Response DCajaDiariaDetalle_Registrar(CajaDiariaDetalleRegistrar data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_app_DCajaDiariaDetalle_Registrar", connection);
                command.Parameters.Add("@iDCajaDiaria", SqlDbType.BigInt).Value = data.iDCajaDiaria;
                command.Parameters.Add("@iTipo", SqlDbType.Int).Value = data.iTipo;
                command.Parameters.Add("@tMotivoCaja", SqlDbType.VarChar).Value = data.tMotivoCaja;
                command.Parameters.Add("@tDescripcion", SqlDbType.VarChar).Value = data.tDescripcion;
                command.Parameters.Add("@iMCliente", SqlDbType.BigInt).Value = data.iMCliente;
                command.Parameters.Add("@iMEmpleado", SqlDbType.BigInt).Value = data.iMEmpleado;
                command.Parameters.Add("@iMoneda", SqlDbType.BigInt).Value = data.iMoneda;
                command.Parameters.Add("@nTipoCambio", SqlDbType.Decimal).Value = data.nTipoCambio;
                command.Parameters.Add("@nEfectivo", SqlDbType.Decimal).Value = data.nEfectivo;
                command.Parameters.Add("@nTarjeta", SqlDbType.Decimal).Value = data.nTarjeta;
                command.Parameters.Add("@nNotaCredito", SqlDbType.Decimal).Value = data.nNotaCredito;
                command.Parameters.Add("@nImporte", SqlDbType.Decimal).Value = data.nImporte;
                command.Parameters.Add("@iCodigoVenta", SqlDbType.BigInt).Value = data.iCodigoVenta;
                command.Parameters.Add("@iDCotizacion", SqlDbType.BigInt).Value = data.iDCotizacion;
                command.Parameters.Add("@iDCompra", SqlDbType.BigInt).Value = data.iDCompra;
                command.Parameters.Add("@operaciones", SqlDbType.VarChar).Value = data.operaciones;
                command.Parameters.Add("@iUsuarioRegistro", SqlDbType.BigInt).Value = data.iUsuarioRegistro;
                command.Parameters.Add("@tObservaciones", SqlDbType.VarChar).Value = data.tObservaciones;
                command.Parameters.Add("@iDContratoVentaCuota", SqlDbType.BigInt).Value = data.iDContratoVentaCuota;
                command.Parameters.Add("@iMCentroCosto", SqlDbType.BigInt).Value = data.iMCentroCosto;
                command.Parameters.Add("@iDFormato", SqlDbType.BigInt).Value = data.iDFormato;
                command.Parameters.Add("@iDOrdenServicio", SqlDbType.BigInt).Value = data.iDOrdenServicio;
                command.Parameters.Add("@lCobranza", SqlDbType.Int).Value = data.lCobranza;
                command.Parameters.Add("@tTotalLetras", SqlDbType.VarChar).Value = data.tTotalLetras;

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
    }
}
