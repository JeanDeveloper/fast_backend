using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurante.DbHandle
{
    public class GeneralDb
    {
        public static string cadena { get; set; }
        public static string cadena_erp { get; set; }
        public GeneralDb()
        {
        }
        public GeneralDb(string connectionString, string connectionStringErp)
        {
            cadena = connectionString;
            cadena_erp = connectionStringErp;
        }
    }
}
