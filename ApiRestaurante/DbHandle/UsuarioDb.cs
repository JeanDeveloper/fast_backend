using ApiRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.DbHandle
{
    public class UsuarioDb : GeneralDb
    {
        public List<Empresas> Empresas_ListarPorUsuario(int iMUsuario)
        {
            List<Empresas> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MEmpresas_ListarPorUsuario_V1", connection);
                command.Parameters.Add("@iMUsuario", SqlDbType.Int).Value = iMUsuario;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    Empresas entidad = null;
                    listEntidad = new List<Empresas>();
                    while (reader.Read())
                    {
                        entidad = new Empresas();
                        entidad.tEmpresaRuc = reader.GetString(0);
                        entidad.tEmpresa = reader.GetString(1);
                        entidad.tCodigoValidacion = reader.GetString(2);
                        entidad.Sucursal = Sucursal_ListarPorEmpresa(reader.GetString(0));
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public List<Sucursal> Sucursal_ListarPorEmpresa(string tEmpresaRuc)
        {
            List<Sucursal> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_rest_MSucursal_ListarPorEmpresa_V1", connection);
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    Sucursal entidad = null;
                    listEntidad = new List<Sucursal>();
                    while (reader.Read())
                    {
                        entidad = new Sucursal();
                        entidad.iDSucursal = reader.GetInt64(0);
                        entidad.tSucursal = reader.GetString(1);
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
