using System;
using System.Collections.Generic;
using App.EF.CodeFirst.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace App.EF.CodeFirst.Test
{
    [TestClass]
    public class AristDATest
    {
        [TestMethod]
        public void Count()
        {
            var da = new ArtistDA();
            Assert.IsTrue(da.Count() > 0);
        }

        [TestMethod]
        public void Find()
        {
            var da = new ArtistDA();
            var found = da.Get(2);
            Assert.IsNotNull(found);
        }


        [TestMethod]
        public void GetEdgerLoading()
        {
            var da = new ArtistDA();
            var found = da.GetEdgerLoading(2);
            Assert.IsNotNull(found);
        }

        [TestMethod]
        public void Gets()
        {
            var da = new ArtistDA();
            Assert.IsTrue(da.Gets("").Count() > 0);
        }

        [TestMethod]
        public void Insert()
        {
            var da = new ArtistDA();
            var id = da.Insert(
                new Artist() {Name="Artits_" 
                            + Guid.NewGuid().ToString() }
                );

            Assert.IsTrue(id > 0);

        }

        [TestMethod]
        public void DeleteBatch()
        {
            var list = new List<int>();
            list.Add(1283);
            list.Add(1282);
            list.Add(1281);
            var da = new ArtistDA();
            Assert.IsTrue(da.DeleteBatch(list));
        }
    }
}
