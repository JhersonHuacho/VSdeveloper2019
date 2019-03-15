using Colegio.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Colegio.Data.ADO
{
    public class AlumnoDapperDA : BaseConnection
    {
        public int InsertarAlumnoConTransaccion(Alumno entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                var tx = cn.BeginTransaction();
                try
                {
                    result = cn.Query<int>("usp_InsertarAlumno",
                                            new { Nombres = entity.Nombres,
                                                  Apellidos = entity.Apellidos,
                                                  Direccion = entity.Direccion,
                                                  Sexo = entity.Sexo,
                                                  FechaNacimiento = entity.FechaNacimiento
                                                },
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

        public List<Alumno> ReporteDeNotasDeAlumnos(int idGrado, int idCurso)
        {
            var result = new List<Alumno>();
            var sql = "usp_ReporteDeNotas";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<Alumno>(sql, new { pGradoID = idGrado, pCursoID = idCurso }
                                             , commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }

    }
}
