using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colegio.Data.ADO;
using Colegio.Entities;

namespace Colegio.Data.Test
{
    [TestClass]
    public class AlumnoDapperDATest
    {
        [TestMethod]
        public void InsertarAlumnoConTransaccionTest()
        {
            AlumnoDapperDA da = new AlumnoDapperDA();
            int nuevoAlumno = da.InsertarAlumnoConTransaccion(new Alumno()
            {
                Nombres = $"Francisco Transacción",
                Apellidos = "Huacho Dapper",
                Direccion = $"Nuevo - {Guid.NewGuid().ToString()}",
                Sexo = "M",
                FechaNacimiento = DateTime.Today
            });

            Assert.IsTrue(nuevoAlumno > 0);
        }

        [TestMethod]
        public void ReporteDeNotasDeAlumnosTest()
        {
            var da = new AlumnoDapperDA();

            Assert.IsTrue(da.ReporteDeNotasDeAlumnos(2, 1).Count > 0);

        }
    }
}
