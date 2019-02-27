using Chinook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Chinook.Data
{
    public class GenreDapperDA : BaseConnection
    {
        public List<Genre> GetGenreWithSP(string filterByName)
        {
            var result = new List<Genre>();
            var sql = "usp_GetGenre";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<Genre>(sql, new { pNombre = filterByName }, commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }

        public int InsertGenre(Genre entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<int>("usp_InsertGenre", new { pNombre = entity.Name }, commandType: CommandType.StoredProcedure).Single();
            }

            return result;
        }

        public int UpdateGenre(Genre entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<int>( "usp_UpdateGenre", 
                                        new { GenreId = entity.GenreId, pNombre = entity.Name }, 
                                        commandType: CommandType.StoredProcedure).Single();               
            }

            return result;
        }

        public bool UpdateGenreOtraForma(Genre entity)
        {
            var result = false;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Query("usp_UpdateGenre_otraForma",
                         new { GenreId = entity.GenreId, pNombre = entity.Name },
                         commandType: CommandType.StoredProcedure);
                result = true;
            }

            return result;
        }
    }
}
