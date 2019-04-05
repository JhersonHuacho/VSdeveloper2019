using System;
using System.Collections.Generic;
using App.EF.CodeFirst.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace App.EF.CodeFirst.Test
{
    [TestClass]
    public class TrackDATest
    {
        [TestMethod]
        public void GetTracksByName()
        {
            var da = new TrackDA();
            Assert.IsTrue(da.GetTrackByName("Aero").Count() > 0);
        }

        [TestMethod]
        public void GetTracksByNameLINQ()
        {
            var da = new TrackDA();
            var lista = da.GetTrackByNameLinQ("Aero");
            Assert.IsTrue(lista.Count() > 0);
        }

    }
}
