using System;
using System.Collections.Generic;
using App.EF.CodeFirst.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace App.EF.CodeFirst.Test
{
    [TestClass]
    public class GenreDATest
    {
        [TestMethod]
        public void CountTest()
        {
            var da = new GenreDA();
            Assert.IsTrue(da.Count() > 0);
        }

        [TestMethod]
        public void GetGenresTest()
        {   
            var da = new GenreDA();
            Assert.IsTrue(da.GetGenres("Drama").Count() > 0);
        }

        [TestMethod]
        public void InsertGenreTest()
        {
            var da = new GenreDA();
            var id = da.InsertGenre(new Genre() {
                Name = "Genre Insert " + Guid.NewGuid().ToString()                    
            });
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void UpdateGenreTest()
        {
            var da = new GenreDA();
            var id = da.UpdateGenre(new Genre()
            {
                GenreId = 24,
                Name = "Genero update " + Guid.NewGuid().ToString()
            });
            Assert.IsTrue(id == true);
        }

        [TestMethod]
        public void DeleteBatchgGenresTest()
        {
            var da = new GenreDA();
            var id = da.DeleteBatchGenre(new List<int>() { 27 });
            Assert.IsTrue(id);
        }
    }
}
