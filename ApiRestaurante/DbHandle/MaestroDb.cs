using ApiRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.DbHandle
{
    public class MaestroDb : GeneralDb
    {
        public List<MTipoDocumentoIdentidad> MTipoDocumentoIdentidad_Listar()
        {
            List<MTipoDocumentoIdentidad> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_MTipoDocumentoIdentidad_Listar", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MTipoDocumentoIdentidad entidad = null;
                    listEntidad = new List<MTipoDocumentoIdentidad>();
                    while (reader.Read())
                    {
                        entidad = new MTipoDocumentoIdentidad();
                        entidad.iMTipoDocumentoIdentidad = reader.GetString(0);
                        entidad.tDescripcion = reader.GetString(1);
                        listEntidad.Add(entidad);
                    }
                }

                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public List<MCliente> MCliente_Buscar_Por_NroDoc(string tNroDocumento, string Empresa)
        {
            List<MCliente> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_MCliente_Buscar_Por_NroDoc", connection);
                command.Parameters.Add("@tNroDocumento", SqlDbType.VarChar).Value = tNroDocumento;
                command.Parameters.Add("@tRucEmpresa", SqlDbType.VarChar).Value = Empresa;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MCliente entidad = null;
                    listEntidad = new List<MCliente>();
                    while (reader.Read())
                    {
                        entidad = new MCliente();
                        entidad.iMCliente = reader.GetInt64(0);
                        entidad.tNroDocumento = reader.GetString(1);
                        entidad.tNombre = reader.GetString(2);
                        entidad.tDireccion = reader.GetString(3);
                        entidad.tCorreo = reader.GetString(4);
                        entidad.iMTipoDocumentoIdentidad = reader.GetString(5);
                        entidad.tTelefonoPrincipal = reader.GetString(6);
                        listEntidad.Add(entidad);
                    }
                }

                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public List<MEmpleado> MEmpleados_Listar(string tEmpresaRuc)
        {
            List<MEmpleado> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_MEmpleado_Listar", connection);
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MEmpleado entidad = null;
                    listEntidad = new List<MEmpleado>();
                    while (reader.Read())
                    {
                        entidad = new MEmpleado();
                        entidad.iMEmpleado = reader.GetInt64(0);
                        entidad.tNombres = reader.GetString(1);
                        entidad.iUsuario = reader.GetInt32(2);
                        entidad.tUsuario = reader.GetString(3);
                        entidad.iMTipoDocumentoIdentidad = reader.GetString(6);
                        entidad.descripcionDocumento = reader.GetString(7);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public List<MCaja> MCaja_Listar(string tEmpresaRuc)
        {
            List<MCaja> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_gf_MCaja_Listar", connection);
                command.Parameters.Add("@tRucEmpresa", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MCaja entidad = null;
                    listEntidad = new List<MCaja>();
                    while (reader.Read())
                    {
                        entidad = new MCaja();
                        entidad.iMCaja = reader.GetInt64(0);
                        entidad.iDSucursal = reader.GetInt64(1);
                        entidad.tSucursal = reader.GetString(2);
                        entidad.tNombre = reader.GetString(3);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public List<MVistaMenu1> MMenuPrincipal_Listar(Int64 iMUsuario, string tEmpresaRuc)
        {
            List<MVistaMenu1> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_ListaMenuPrincipal_v2", connection);
                command.Parameters.Add("@iMUsuario", SqlDbType.BigInt).Value = iMUsuario;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MVistaMenu1 entidad = null;
                    listEntidad = new List<MVistaMenu1>();
                    while (reader.Read())
                    {
                        entidad = new MVistaMenu1();
                        entidad.iMMenu = reader.GetInt64(0);
                        entidad.tModulo = reader.GetString(1);
                        entidad.tNombre = reader.GetString(2);
                        entidad.tRuta = reader.GetString(3);
                        entidad.tIcono = reader.GetString(4);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public List<MVistaMenu2> MNavBarRight_Listar(Int64 iMUsuario, string tEmpresaRuc)
        {
            List<MVistaMenu2> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_ListaNavBarRight_v2", connection);
                command.Parameters.Add("@iMUsuario", SqlDbType.BigInt).Value = iMUsuario;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MVistaMenu2 entidad = null;
                    listEntidad = new List<MVistaMenu2>();
                    while (reader.Read())
                    {
                        entidad = new MVistaMenu2();
                        entidad.iMMenu = reader.GetInt64(0);
                        entidad.tModulo = reader.GetString(1);
                        entidad.tNombre = reader.GetString(2);
                        entidad.tRuta = reader.GetString(3);
                        entidad.tIcono = reader.GetString(4);
                        entidad.iTipo = reader.GetInt32(5);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }

        public Response DConfiguracionImpresora_Registrar(DConfigInpresora data)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DConfiguracionImpresora_Registrar_V1", connection);
                command.Parameters.Add("@jsonImpresora", SqlDbType.VarChar).Value = data.jsonImpresora;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = data.tEmpresaRuc;
                command.Parameters.Add("@iDSucursal", SqlDbType.BigInt).Value = data.iDSucursal;
                command.Parameters.Add("@iMUsuario", SqlDbType.BigInt).Value = data.iMUsuario;
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

        public List<DConfigInpresora> MConfiguracionImpresora_Listar(Int64 iMUsuario, string tEmpresaRuc, Int64 iDSucursal)
        {
            List<DConfigInpresora> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_DConfiguracionImpresora_listar_V1", connection);
                command.Parameters.Add("@iMUsuario", SqlDbType.BigInt).Value = iMUsuario;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.Parameters.Add("@iDSucursal", SqlDbType.VarChar).Value = iDSucursal;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    DConfigInpresora entidad = null;
                    listEntidad = new List<DConfigInpresora>();
                    while (reader.Read())
                    {
                        entidad = new DConfigInpresora();
                        entidad.jsonImpresora = reader.GetString(0);
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
