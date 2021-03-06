﻿using Chinook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Chinook.Data
{
    public class ArtistDA:BaseConnection
    {
        public int GetCount()
        {
            var result = 0;

            var sql = "SELECT COUNT(1) FROM Artist";
            /*1: Create una instancia sql DbConnection*/
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                /*2: Create ua instancia de Command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open(); //Abriendo la conexion a la DB
                           /*3. ejecutando el comando*/
                result = (int)cmd.ExecuteScalar();
            }

            return result;
        }

        public List<Artist> GetArtists()
        {
            var result = new List<Artist>();
            var sql = "SELECT ArtistId,Name FROM Artist";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                /*2: Create ua instancia de Command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open(); //Abriendo la conexion a la DB
                           /*3. ejecutando el comando*/

                var indice = 0;
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    indice = reader.GetOrdinal("ArtistId");
                    var artistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    var name = reader.GetString(indice);

                    result.Add(
                            new Artist()
                            {
                                ArtistId = artistId,
                                Name = name
                            }
                        );
                }
            }

            return result;
        }

        public List<Artist> GetArtists(string filterByName)
        {
            var result = new List<Artist>();
            var sql = "SELECT ArtistId,Name FROM Artist WHERE Name like @name";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                /*2: Create ua instancia de Command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open(); //Abriendo la conexion a la DB
                           /*3. ejecutando el comando*/

                /*Configurando los parametros*/
                cmd.Parameters.Add(new SqlParameter("@name", filterByName));

                var indice = 0;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    indice = reader.GetOrdinal("ArtistId");
                    var artistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    var name = reader.GetString(indice);

                    result.Add(
                            new Artist()
                            {
                                ArtistId = artistId,
                                Name = name
                            }
                        );
                }
            }

            return result;
        }
        public List<Artist> GetArtistsWithSP(string filterByName)
        {
            var result = new List<Artist>();
            var sql = "usp_GetArtist";
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
                    indice = reader.GetOrdinal("ArtistId");
                    var artistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    var name = reader.GetString(indice);

                    result.Add( new Artist() {
                        ArtistId = artistId,
                        Name = name
                    });
                }
            }

            return result;
        }

        public int InsertArtists(Artist entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                IDbCommand command = new SqlCommand("usp_InsertArtist");
                command.Connection = cn;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                result = Convert.ToInt32(command.ExecuteScalar());
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
                cn.Open();
                IDbCommand command = new SqlCommand("usp_InsertArtistWithOutput");
                command.Connection = cn;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));

                var paramOutputId = new SqlParameter();
                paramOutputId.ParameterName = "@ID";
                paramOutputId.Direction = ParameterDirection.Output;
                paramOutputId.DbType = DbType.Int32;
                command.Parameters.Add(paramOutputId);

                command.ExecuteScalar();

                result = Convert.ToInt32(paramOutputId.Value);
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
                // Iniciando la transacción local
                IDbTransaction transaction = cn.BeginTransaction();

                try
                {
                    IDbCommand command = new SqlCommand("usp_InsertArtist");
                    command.Connection = cn;
                    command.Transaction = transaction; //-> Local transaction
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                    result = Convert.ToInt32(command.ExecuteScalar());
                    //throw new Exception("Genear un error"); //-> simulando un error
                    transaction.Commit(); //-> confirmando la transacción local
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); //-> Deshaciendo la transacción local
                    result = 0;
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
                        cn.Open();
                        IDbCommand command = new SqlCommand("usp_InsertArtist");
                        command.Connection = cn;                            
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                        result = Convert.ToInt32(command.ExecuteScalar());                                           
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
