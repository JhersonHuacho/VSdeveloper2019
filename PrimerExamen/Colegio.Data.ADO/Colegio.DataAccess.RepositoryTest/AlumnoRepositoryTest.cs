using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Colegio.DataAccess.Repository;
using System.Data.Entity;
using Colegio.DataAcces.Repository.Interfaces;

namespace Colegio.DataAccess.RepositoryTest
{
    [TestClass]
    public class AlumnoRepositoryTest
    {
        private readonly DbContext _context;

        public AlumnoRepositoryTest()
        {
            _context = new ColegioDataModel();
        }

        //[TestMethod]
        //public void listarAlumnosTest()
        //{
        //    IAlumnoRepository repository = new AlumnoRepository(_context);
        //    var data = repository.listarPorNombres("f%");

        //    Assert.IsTrue(data.Count() > 0);
        //}

        [TestMethod]
        public void listarTodosLosAlumnos()
        {
            IAlumnoRepository repository = new AlumnoRepository(_context);
            var entities = repository.listarTodosLosAlumnos("f%");

            Assert.IsTrue(entities.Count() > 0);
        }

        [TestMethod]
        public void listarTodosLosAlumnosUnitOfWorkTest()
        {
            using (var unitOfWork = new ColegioUnitOfWork())
            {
                var cantRows = unitOfWork.AlumnoRepository.listarTodosLosAlumnos("f%");
                Assert.IsTrue(cantRows.Count() > 0);
            }
        }

        //prueba
        //[TestMethod]
        //public void listarAlumnosUnitOfWorkTest()
        //{
        //    using (var unitOfWork = new ColegioUnitOfWork())
        //    {
        //        var cantRows = unitOfWork.AlumnoRepository;
        //        Assert.IsTrue(cantRows.Count() > 0);
        //    }
        //}

    }
}
