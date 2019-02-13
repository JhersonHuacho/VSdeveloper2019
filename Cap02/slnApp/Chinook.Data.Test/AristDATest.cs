using System;
using Chinook.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.Data.Test
{
    [TestClass]
    public class ArtistDATest
    {
        [TestMethod]
        public void GetCountTest()
        {
            var da = new ArtistDA();

            Assert.IsTrue(da.GetCount() > 0);

        }

        [TestMethod]
        public void GetArtistTest()
        {
            var da = new ArtistDA();

            Assert.IsTrue(da.GetArtists().Count > 0);

        }

        [TestMethod]
        public void GetArtistByNameTest()
        {
            var da = new ArtistDA();

            Assert.IsTrue(da.GetArtists("a%").Count > 0);

        }

        [TestMethod]
        public void InsertArtistTest()
        {
            var da = new ArtistDA();
            var nuevoArtista = da.InsertArtists(new Artist() {
                Name = $"Nuevo artista {Guid.NewGuid().ToString()}"
            });

            Assert.IsTrue(nuevoArtista > 0);

        }

        [TestMethod]
        public void InsertArtistsWithOutput()
        {
            var da = new ArtistDA();
            var nuevoArtista = da.InsertArtistsWithOutput(new Artist()
            {
                Name = $"Nuevo artista {Guid.NewGuid().ToString()}"
            });

            Assert.IsTrue(nuevoArtista > 0);
        }

        [TestMethod]
        public void InsertArtistsWithTransactionTest()
        {
            ArtistDA da = new ArtistDA();
            int nuevoArtista = da.InsertArtistsWithTransaction(new Artist()
            {
                Name = $"Nuevo artista {Guid.NewGuid().ToString()}"
            });

            Assert.IsTrue(nuevoArtista > 0);
        }

        

    }
}
