using System;
using Chinook.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.Data.Test
{
    [TestClass]
    public class AlbumDapperDATest
    {
        [TestMethod]
        public void InsertAlbum()
        {
            var da = new AlbumDapperDA();
            var nuevoAlbum = da.InsertAlbum(new Album()
            {
                Title = "juan",
                ArtistId = 1,
            });

            Assert.IsTrue(nuevoAlbum > 0);
        }

        [TestMethod]
        public void UpdatetAlbumTest()
        {
            var da = new AlbumDapperDA();
            var updateAlbum = da.UpdateAlbum(new Album()
            {
                AlbumId = 1,
                Title = "otro titulo",
                ArtistId = 4
            });

            Assert.IsTrue(updateAlbum == true);

        }
    }
}
