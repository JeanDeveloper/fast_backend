using ApiRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.DbHandle
{
    public class SeguridadDb : GeneralDb
    {
        public UsuarioApi UsuarioApi_Validar(string tUsuario, string tPassword)
        {
            UsuarioApi entidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_UsuarioApi_Token", connection);
                command.Parameters.Add("@tUsuario", SqlDbType.VarChar).Value = tUsuario;
                command.Parameters.Add("@tPassword", SqlDbType.VarChar).Value = tPassword;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        entidad = new UsuarioApi();
                        entidad.iUsuarioApi = reader.GetInt64(0);
                        entidad.tMessage = reader.GetString(1);
                        entidad.iEstado = reader.GetInt32(2);
                        entidad.tVersionAndroid = reader.GetString(3);
                        entidad.tVersionIOS = reader.GetString(4);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return entidad;
        }
        public Usuario Usuario_IniciarSession(string tUsuario, string tPassword)
        {
            Usuario entidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MUsuario_IniciarSession", connection);
                command.Parameters.Add("@tUsuario", SqlDbType.VarChar).Value = tUsuario;
                command.Parameters.Add("@tPassword", SqlDbType.VarChar).Value = tPassword;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        entidad = new Usuario();
                        entidad.iMUsuario = reader.GetInt32(0);
                        entidad.tUsuario = reader.GetString(1);
                        entidad.tRol = reader.GetString(2);
                        entidad.tEmpresaRuc = reader.GetString(3);
                        entidad.tEmpresa = reader.GetString(4);
                        entidad.iDSucursal = reader.GetInt64(5);
                        entidad.tSucursal = reader.GetString(6);
                        entidad.tUbigeo = reader.GetString(7);
                        entidad.tRegion = reader.GetString(8);
                        entidad.tProvincia = reader.GetString(9);
                        entidad.tDistrito = reader.GetString(10);
                        entidad.tTipozona = reader.GetString(11);
                        entidad.tDireccion = reader.GetString(12);
                        entidad.tCodigoValidacion = reader.GetString(13);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return entidad;
        }
    }
}
