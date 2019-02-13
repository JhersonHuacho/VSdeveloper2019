using Chinook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data
{
    public class GenreDA : BaseConnection
    {
        public List<Genre> GetGenreWithSP(string filterByName)
        {
            var result = new List<Genre>();
            var sql = "usp_GetGenre";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                /*2: Create ua instancia de Command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                // agregando el parametro
                cmd.Parameters.Add(new SqlParameter("@pNombre", filterByName));

                cn.Open(); //Abriendo la conexion a la DB
                           /*3. ejecutando el comando*/

                var indice = 0;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    indice = reader.GetOrdinal("GenreId");
                    var genreId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    var name = reader.GetString(indice);

                    result.Add(new Genre() {
                        GenreId = genreId,
                        Name = name
                    });
                }
            }

            return result;
        }

        public int InsertGenre(Genre entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                IDbCommand command = new SqlCommand("usp_InsertGenre");
                command.Connection = cn;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@pNombre", entity.Name));
                result = Convert.ToInt32(command.ExecuteScalar());
            }

            return result;
        }
    }
}
