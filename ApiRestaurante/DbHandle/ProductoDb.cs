using ApiRestaurante.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.DbHandle
{
    public class ProductoDb: GeneralDb
    {
        public List<MProductoPorNombre> MProducto_ListarPorNombre(string tNombre, string tEmpresaRuc)
        {
            List<MProductoPorNombre> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_api_MProducto_ListarPorNombre_V1", connection);
                command.Parameters.Add("@tNombre", SqlDbType.VarChar).Value = tNombre;
                command.Parameters.Add("@tEmpresaRuc", SqlDbType.VarChar).Value = tEmpresaRuc;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    MProductoPorNombre entidad = null;
                    listEntidad = new List<MProductoPorNombre>();
                    while (reader.Read())
                    {
                        entidad = new MProductoPorNombre();
                        entidad.iMProducto = reader.GetInt64(0);
                        entidad.tDescripcion = reader.GetString(1);
                        entidad.tObservaciones = reader.GetString(2);
                        entidad.tUnidad = reader.GetString(3);
                        entidad.iPrecioTotal = reader.GetDecimal(4);
                        listEntidad.Add(entidad);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public Response KoreaMotosMProducto_EditarPrecioStock(ERPProducto data)
        {
            Response listEntidad = null;
            using (MySqlConnection connection = new MySqlConnection(cadena_erp))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("sp_ws_product", connection);
                command.Parameters.Add("@tJSON", MySqlDbType.VarChar).Value = data.tProducto;
                command.Parameters.Add("@vtipo", MySqlDbType.Int32).Value = data.iTipo;
                command.CommandType = CommandType.StoredProcedure;
                MySqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new Response();
                        listEntidad.code = reader.GetInt32(0);
                        listEntidad.message = reader.GetString(1);
                        listEntidad.data = reader.GetString(2);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
        public Response DNotificacionApi_Registrar(JGRespuesta data, string tJson)
        {
            Response listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p_api_DNotificacionApi_Registrar_V1", connection);
                command.Parameters.Add("@lEstado", SqlDbType.Bit).Value = data.success;
                command.Parameters.Add("@iEstado", SqlDbType.Int).Value = data.status;
                command.Parameters.Add("@tMensaje", SqlDbType.VarChar).Value = data.response;
                command.Parameters.Add("@tJson", SqlDbType.VarChar).Value = tJson;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listEntidad = new Response();
                        listEntidad.code = reader.GetInt32(0);
                        listEntidad.message = reader.GetString(1);
                        listEntidad.data = reader.GetString(2);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return listEntidad;
        }
    }
}
