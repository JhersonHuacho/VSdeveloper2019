using Chinook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;

namespace Chinook.Data
{
    public class ArtistDapperDA:BaseConnection
    {
        public int GetCount()
        {
            var result = 0;
            var sql = "SELECT COUNT(1) FROM Artist";
            
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<int>(sql).First();
            }

            return result;
        }

        public List<Artist> GetArtists()
        {
            var result = new List<Artist>();
            var sql = "SELECT ArtistId,Name FROM Artist";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<Artist>(sql).ToList();
            }

            return result;
        }

        public List<Artist> GetArtists(string filterByName)
        {
            var result = new List<Artist>();
            var sql = "SELECT ArtistId,Name FROM Artist WHERE Name like @name";

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<Artist>(sql, new { name = filterByName }).ToList();
            }

            return result;
        }
        public List<Artist> GetArtistsWithSP(string filterByName)
        {
            var result = new List<Artist>();
            var sql = "usp_GetArtist";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<Artist>(sql, new { pNombre = filterByName }, commandType: CommandType.StoredProcedure).ToList();             
            }

            return result;
        }

        public int InsertArtists(Artist entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<int>("usp_InsertArtist", new { Name = entity.Name }, commandType: CommandType.StoredProcedure).Single();
            }

            return result;
        }

        public int UpdateArtists(Artist entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                IDbCommand command = new SqlCommand("usp_UpdateArtist");
                command.Connection = cn;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ArtistId", entity.ArtistId));
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                result = Convert.ToInt32(command.ExecuteScalar());
            }

            return result;
        }

        public int InsertArtistsWithOutput(Artist entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name);
                parameters.Add("ID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                cn.Query("usp_InsertArtistWithOutput", parameters, commandType: CommandType.StoredProcedure);                

                result = parameters.Get<int>("ID");
            }

            return result;
        }

        // Transacción local
        public int InsertArtistsWithTransaction(Artist entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                var tx = cn.BeginTransaction();
                try
                {
                    result = cn.Query<int>("usp_InsertArtist", 
                                            new { Name = entity.Name },
                                            commandType: CommandType.StoredProcedure,
                                            transaction: tx).Single();
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();                    
                }
            }

            return result;
        }

        // Transacción distribuida
        public int InsertArtistsWithTransactionDistribuida(Artist entity)
        {
            var result = 0;

            using (var tx = new TransactionScope())
            {
                try
                {
                    using (IDbConnection cn = new SqlConnection(GetConnection()))
                    {
                        result = cn.Query<int>("usp_InsertArtist", 
                                               new { Name = entity.Name }, 
                                               commandType: CommandType.StoredProcedure).Single();
                    }
                    tx.Complete();
                }
                catch (Exception ex)
                {

                }
            }

            return result;
        }
    }
}
