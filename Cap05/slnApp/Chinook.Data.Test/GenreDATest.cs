using Chinook.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data.Test
{
    [TestClass]
    public class GenreDATest
    {
        [TestMethod]
        public void GetGenreTest()
        {
            var da = new GenreDA();

            Assert.IsTrue(da.GetGenreWithSP("a%").Count > 0);
        }

        [TestMethod]
        public void InsertGenreTest()
        {
            var da = new GenreDA();
            var nuevoGenero = da.InsertGenre(new Genre()
            {
                Name = $"Nuevo genero {Guid.NewGuid().ToString()}"
            });

            Assert.IsTrue(nuevoGenero > 0);
        }

        [TestMethod]
        public void UpdateGenreTest()
        {
            var da = new GenreDA();
            var updateGenero = da.UpdateGenre(new Genre()
            {
                GenreId = 25,
                Name = $"Update GENERO {Guid.NewGuid().ToString()}"
            });

            Assert.IsTrue(updateGenero > 0);
        }

    }
}
