using System;
using System.Collections.Generic;
using App.EF.CodeFirst.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.EF.CodeFirst.Test
{
    [TestClass]
    public class ArtistDATest
    {
        [TestMethod]
        public void CountTest()
        {
            var da = new ArtistDA();
            Assert.IsTrue(da.Count() > 0);
        }

        [TestMethod]
        public void GetArtistEdgerLoadingTest()
        {
            var da = new ArtistDA();
            var found = da.GetArtistEdgerLoading(2);
            Assert.IsNotNull(found);
        }

        [TestMethod]
        public void GetArtistEdgerLoadingDosTest()
        {
            var da = new ArtistDA();
            var found = da.GetArtistEdgerLoadingDos(2);
            Assert.IsNotNull(found);
        }

        [TestMethod]
        public void InsertArtistTest()
        {
            var da = new ArtistDA();
            var id = da.InsertArtist(new Artist() {
                Name = "Artist " + Guid.NewGuid().ToString()                    
            });
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void DeleteBatchArtistsTest()
        {
            var da = new ArtistDA();
            var id = da.DeleteBatchArtist(new List<int>() { 287, 288 });
            Assert.IsTrue(id);
        }
    }
}
