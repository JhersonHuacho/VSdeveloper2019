using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace App.UI.MVC.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        MantenimientoServicesClient.MantenimientoServicesClient client = null;

        public UsuarioController()
        {
            client = new MantenimientoServicesClient.MantenimientoServicesClient();
        }
        // GET: Usuario
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Logueo(string usuario, string clave)
        {
            Usuario modelo = new Usuario()
            {
                Login = usuario,
                Password = clave
            };
            var result = client.LoginUsuario(modelo);

            if (result)
            {
                #region Agregando los claims que se van a necesitar en la aplicación

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, "Javier Tunoque"),
                    new Claim("UsuarioID", "1")
                };

                var identity = new ClaimsIdentity(claims, "ApplicationCookie");

                #endregion

                #region Llama a los componentes de Owin para iniciar el proceso de generación de la cookie de autenticación

                var context = Request.GetOwinContext();
                var authManager = context.Authentication;
                authManager.SignIn(identity); // crear la cookie

                #endregion
                return Redirect("~/Artist/Index");
            }
            else
            {
                return View("~/");
            }
            
        }
    }
}