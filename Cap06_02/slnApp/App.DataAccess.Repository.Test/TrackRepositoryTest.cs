using System;
using App.DataAccess.Repository.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.Entity;

namespace App.DataAccess.Repository.Test
{
    [TestClass]
    public class TrackRepositoryTest
    {
        private readonly DbContext _context;
        public TrackRepositoryTest()
        {
            _context = new AppDataModel();
        }

        [TestMethod]
        public void GetAll()
        {
            ITrackRepository repository = new TrackRepository(_context);
            var entities = repository.GetTracksAll("%aero%");

            Assert.IsTrue(entities.Count()> 0);
        }

    }
}
