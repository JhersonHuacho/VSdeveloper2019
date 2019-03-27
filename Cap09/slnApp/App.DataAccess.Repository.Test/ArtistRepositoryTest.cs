using System;
using App.DataAccess.Repository.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.Entity;

namespace App.DataAccess.Repository.Test
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        private readonly DbContext _context;
        public ArtistRepositoryTest()
        {
            _context = new AppDataModel();
        }

        [TestMethod]
        public void Count()
        {
            IArtistRepository repository = new ArtistRepository(_context);
            int count = repository.Count();

            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void GetAll()
        {
            IArtistRepository repository = new ArtistRepository(_context);
            var data = repository.GetAll(item=>item.Name.Contains("Aero")
            ,item=>item.OrderBy(item2=>item2.Name));

            Assert.IsTrue(data.Count() > 0);
        }
    }
}
