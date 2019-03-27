using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.DataAccess.Repository.Interface;

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
    }
}
