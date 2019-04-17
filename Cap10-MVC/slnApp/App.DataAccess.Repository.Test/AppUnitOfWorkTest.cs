using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.DataAccess.Repository.Interface;
using App.Entities.Base;

namespace App.DataAccess.Repository.Test
{
    /// <summary>
    /// Descripción resumida de AppUnitOfWorkTest
    /// </summary>
    [TestClass]
    public class AppUnitOfWorkTest
    {
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
    }
}
