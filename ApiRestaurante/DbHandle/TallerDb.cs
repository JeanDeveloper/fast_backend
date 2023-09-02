using ApiRestaurante.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ApiRestaurante.DbHandle
{
    public class TallerDb:GeneralDb
    {
        public List<MessageOut> ActualizarOrdenServicio(Int64 OrdenServicio)
        {
            List<MessageOut> listEntidad = null;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("wsp_Taller_OrdenServicio_Facturar", connection);
                command.Parameters.Add("@OrdenServicio", SqlDbType.BigInt).Value = OrdenServicio;
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
    }
}
