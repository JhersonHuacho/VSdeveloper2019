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
    public class SecurityController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string usuario, string clave)
        {
            // Validar en base de datos
            MantenimientoServicesClient.MantenimientoServicesClient client = null;
            client = new MantenimientoServicesClient.MantenimientoServicesClient();

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
                    new Claim(ClaimTypes.Name, "user1"),
                    new Claim("UsuarioID", "3")
                };
                var usuarioID = 3;
                string usuarioFound = usuarioID == 1 ? "usuario" : "supervisor;operador";
                //************************************************************************************
                // configurando los roles para la implementación del mecanismo de autorización
                string[] roles = usuarioFound.Split(';');
                foreach (string rol in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }
                //************************************************************************************
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
                return Redirect("~/");
            }
        }

        public ActionResult SignOut()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}