using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.DataAccess.Repository.Interface;
using App.Entities.Base;
using System.Data.Entity;
using System.Linq;

namespace App.DataAccess.Repository.Test
{
    /// <summary>
    /// Descripción resumida de AppUnitOfWorkTest
    /// </summary>
    [TestClass]
    public class AppUnitOfWorkTest
    {
        private readonly DbContext _context;
        public AppUnitOfWorkTest()
        {
            _context = new AppDataModel();
        }

        [TestMethod]
        public void ExistenArtistas()
        {
            using (var unitOfWork = new AppUnitOfWork())
            {
                var cantRows = unitOfWork.ArtistRepository.Count();
                Assert.IsTrue(cantRows > 0);
            }
        }

        [TestMethod]
        public void LoginUsuario()
        {
            Usuario objUsuario = new Usuario() {
                Login = "francisco",
                Password = "123456"
            };

            using (var unitOfWork = new AppUnitOfWork())
            {
                bool result = unitOfWork.UsuarioRepository.LoginUsuario(objUsuario);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void LoginUsuarioDos()
        {
            IUsuarioRepository repository = new UsuarioRepository(_context);
            var data = repository.GetAll(item => item.Login.Contains("francisco") && item.Password.Contains("123456"));

            Assert.IsTrue(data.Count() > 0);
        }
    }
}
