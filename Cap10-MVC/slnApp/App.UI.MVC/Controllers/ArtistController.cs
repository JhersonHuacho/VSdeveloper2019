using App.Entities.Base;
using App.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.MVC.Controllers
{
    [Authorize]
    //[Authorize]
    public class ArtistController : Controller
    {
        MantenimientoServicesClient.MantenimientoServicesClient client = null;

        public ArtistController()
        {
            client = new MantenimientoServicesClient.MantenimientoServicesClient();
        }

        public ActionResult Index()
        {
            List<string> artist = new List<string>();
            artist.Add("Aerosmith");
            artist.Add("Robbin Williams");
            artist.Add("Soda Stereo");

            ViewBag.ArtistList = artist;

            return View();
        }

        [Authorize(Roles = "supervisor,admin")]
        public ActionResult Listado(string filtroByNombre)
        { 
            var listado = new List<Artist>();

            if (string.IsNullOrWhiteSpace(filtroByNombre))
            {
                listado = client.GetArtistAll("%%");
            }
            else
            {
                listado = client.GetArtistAll(filtroByNombre);
            }

            //listado = new List<Artist>()
            //{
            //    new Artist()
            //    {
            //        ArtistId = 1,
            //        Name = "Aerosmith"
            //    },
            //    new Artist()
            //    {
            //        ArtistId = 2,
            //        Name = "Soda Stereo"
            //    },
            //    new Artist()
            //    {
            //        ArtistId = 3,
            //        Name = "Mana"
            //    }
            //};
            // vistas fuertemente tipadas o strong-types
            return View(listado);
        }

        public ActionResult Edit(int id)
        {
            Artist artist = client.GetArtist(id);
            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(Artist modelo)
        {
            bool artist = client.SaveArtist(modelo);
            // Redireccionamos a la acción que muestra el listado de artistas
            return RedirectToAction("Listado");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist modelo)
        {
            bool artist = client.SaveArtist(modelo);
            return RedirectToAction("Listado");
        }

        [HttpPost]
        public ActionResult Buscar(string filtroByNombre)
        {
            var listado = client.GetArtistAll(filtroByNombre);
            System.Threading.Thread.Sleep(5000);
            return PartialView("ListadoResultado", listado);
        }
        //// GET: Artist/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Artist/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Artist/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Artist/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Artist/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Artist/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Artist/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
