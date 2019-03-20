using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Service.WCFAppTest
{
    [TestClass]
    public class ArtistServiceTest
    {
        [TestMethod]
        public void GetArtistAllTest()
        {
            var client = new MantenimientoServices.MantenimientoServicesClient();
            var lista = client.GetArtistAll("a");

            Assert.IsTrue(lista.Count > 0);
        }
    }
}
