using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Data.ADO
{
    public class BaseConnection
    {
        public string GetConnection()
        {
            string cadenaConexion = "Data Source=.;" +
                                        "Initial Catalog=dbColegio; " +
                                        "User ID=sa; Password=sql";
            return cadenaConexion;
        }
    }
}
