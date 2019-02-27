using System;
using Chinook.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.Data.Test
{
    [TestClass]
    public class ArtistDapperDATest
    {
        [TestMethod]
        public void GetCountTest()
        {
            var da = new ArtistDapperDA();

            Assert.IsTrue(da.GetCount() > 0);

        }

        [TestMethod]
        public void GetArtistTest()
        {
            var da = new ArtistDapperDA();

            Assert.IsTrue(da.GetArtists().Count > 0);

        }

        [TestMethod]
        public void GetArtistWithSPTest()
        {
            var da = new ArtistDapperDA();

            Assert.IsTrue(da.GetArtistsWithSP("a%").Count > 0);

        }

        [TestMethod]
        public void GetArtistByNameTest()
        {
            var da = new ArtistDapperDA();

            Assert.IsTrue(da.GetArtists("a%").Count > 0);

        }

        [TestMethod]
        public void InsertArtistTest()
        {
            var da = new ArtistDapperDA();
            var nuevoArtista = da.InsertArtists(new Artist() {
                Name = $"Nuevo artista {Guid.NewGuid().ToString()}"
            });

            Assert.IsTrue(nuevoArtista > 0);

        }

        [TestMethod]
        public void InsertArtistsWithOutput()
        {
            var da = new ArtistDapperDA();
            var nuevoArtista = da.InsertArtistsWithOutput(new Artist()
            {
                Name = $"Nuevo artista {Guid.NewGuid().ToString()}"
            });

            Assert.IsTrue(nuevoArtista > 0);
        }

        [TestMethod]
        public void InsertArtistsWithTransactionTest()
        {
            ArtistDapperDA da = new ArtistDapperDA();
            int nuevoArtista = da.InsertArtistsWithTransaction(new Artist()
            {
                Name = $"Nuevo artista {Guid.NewGuid().ToString()}"
            });

            Assert.IsTrue(nuevoArtista > 0);
        }

        [TestMethod]
        public void InsertArtistsWithTransactionDistribuidaTest()
        {
            ArtistDapperDA da = new ArtistDapperDA();
            int nuevoArtista = da.InsertArtistsWithTransactionDistribuida(new Artist()
            {
                Name = $"Nuevo artista {Guid.NewGuid().ToString()}"
            });

            Assert.IsTrue(nuevoArtista > 0);
        }

        [TestMethod]
        public void UpdatetArtistTest()
        {
            var da = new ArtistDA();
            var updateArtista = da.UpdateArtists(new Artist()
            { 
                ArtistId = 286,
                Name = $"Update artista {Guid.NewGuid().ToString()}"
            });

            Assert.IsTrue(updateArtista > 0);

        }


    }
}
