using System;
using App.DataAccess.Repository.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace App.DataAccess.Repository.Test
{
    [TestClass]
    public class ArtistDATest
    {
        [TestMethod]
        public void CountTest()
        {
            IArtistRepository repository = new ArtistRepository();
            Assert.IsTrue(repository.Count() > 0);
        }

        [TestMethod]
        public void GetAllArtistsTest()
        {
            IArtistRepository repository = new ArtistRepository();
            var data = repository.GetAll();
            Assert.IsTrue(data.Count() > 0);
        }
    }
}
