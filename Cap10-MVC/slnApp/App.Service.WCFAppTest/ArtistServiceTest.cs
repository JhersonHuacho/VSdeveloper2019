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

        [TestMethod]
        public void GetTrackAllTest()
        {
            var client = new ReportesServices.ReporteServicesClient();
            var lista = client.GetTrackAll("a%");

            Assert.IsTrue(lista.Count > 0);
        }

        [TestMethod]
        public void pruebaLogin()
        {
            var client = new MantenimientoServices.MantenimientoServicesClient();
            var lista = client.LoginUsuario("a");

            Assert.IsTrue(lista.Count > 0);
        }
    }
}
