using Chinook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Chinook.Data
{
    public class AlbumDapperDA : BaseConnection
    {
        public int InsertAlbum(Album entity)
        {
            var result = 0;
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<int>("usp_InsertAlbum"
                                       , new
                                       { //pAlbumId = entity.AlbumId,
                                           pTitle = entity.Title,
                                           pArtistId = entity.ArtistId,
                                       }
                                       , commandType: CommandType.StoredProcedure).Single();
            }
            return result;
        }

        public bool UpdateAlbum(Album entity)
        {
            var result = false;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Query("usp_UpdateAlbum",
                         new {  pAlbumId = entity.AlbumId,
                                pTitle = entity.Title,
                                pArtistId = entity.ArtistId
                         }
                         , commandType: CommandType.StoredProcedure);
                result = true;
            }

            return result;
        }
    }
}
