using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.MVC.Controllers
{
    public class TrackController : Controller
    {
        ReporteServicesTrack.ReporteServicesClient WcfClient = null;

        public TrackController()
        {
            WcfClient = new ReporteServicesTrack.ReporteServicesClient();
        }

        public ActionResult GetTrackAll()
        {
            return View();
        }

        public ActionResult BuscarTrack(string filtroByNombre)
        {
            filtroByNombre = filtroByNombre ?? "";

            List<TrackAll> listTrack = WcfClient.GetTrackAll(filtroByNombre);
            return PartialView("GetTrackAllResultado", listTrack);
        }
    }
}
