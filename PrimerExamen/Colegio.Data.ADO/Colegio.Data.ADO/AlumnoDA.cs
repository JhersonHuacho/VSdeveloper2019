using Colegio.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Data.ADO
{
    public class AlumnoDA : BaseConnection
    {
        public int InsertarAlumno(Alumno entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                IDbCommand command = new SqlCommand("usp_InsertarAlumno");
                command.Connection = cn;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Nombres", entity.Nombres));
                command.Parameters.Add(new SqlParameter("@Apellidos", entity.Apellidos));
                command.Parameters.Add(new SqlParameter("@Direccion", entity.Direccion));
                command.Parameters.Add(new SqlParameter("@Sexo", entity.Sexo));
                command.Parameters.Add(new SqlParameter("@FechaNacimiento", entity.FechaNacimiento));
                result = Convert.ToInt32(command.ExecuteScalar());
            }

            return result;
        }

        public List<Alumno> listarAlumno(string filterByName)
        {
            var result = new List<Alumno>();
            var sql = "SELECT AlumnoID, Nombres, Apellidos, Direccion, Sexo, FechaNacimiento FROM Alumno WHERE Nombres LIKE @nombre";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open(); 

                cmd.Parameters.Add(new SqlParameter("@nombre", filterByName));

                var indice = 0;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    indice = reader.GetOrdinal("AlumnoID");
                    var alumnoId = reader.GetInt32(indice);
                    indice = reader.GetOrdinal("Nombres");
                    var nombres = reader.GetString(indice);
                    indice = reader.GetOrdinal("Apellidos");
                    var apellidos = reader.GetString(indice);
                    indice = reader.GetOrdinal("Direccion");
                    var direccion = reader.GetString(indice);
                    indice = reader.GetOrdinal("Sexo");
                    var sexo = reader.GetString(indice);
                    indice = reader.GetOrdinal("FechaNacimiento");
                    var fechaNacimiento = reader.GetDateTime(indice);

                    result.Add( new Alumno()
                                {
                                    AlumnoID = alumnoId,
                                    Nombres = nombres,
                                    Apellidos = apellidos,
                                    Direccion = direccion,
                                    Sexo = sexo,
                                    FechaNacimiento = fechaNacimiento
                                }
                        );
                }
            }

            return result;
        }
    }
}
