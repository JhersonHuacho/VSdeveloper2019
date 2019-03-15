using System;
using Colegio.Data.ADO;
using Colegio.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Colegio.Data.Test
{
    [TestClass]
    public class AlumnoDATest
    {
        [TestMethod]
        public void InsertarAlumnoTest()
        {
            var da = new AlumnoDA();
            var nuevoAlumno = da.InsertarAlumno(new Alumno()
            {
                Nombres = $"Francisco ADO",
                Apellidos = "Huacho",
                Direccion = $"Nuevo - {Guid.NewGuid().ToString()}",
                Sexo = "M",
                FechaNacimiento = DateTime.Today
            });

            Assert.IsTrue(nuevoAlumno > 0);
        }

        [TestMethod]
        public void ListarAlumnoTest()
        {
            var da = new AlumnoDA();

            Assert.IsTrue(da.listarAlumno("f%").Count > 0);
        }
    }
}
