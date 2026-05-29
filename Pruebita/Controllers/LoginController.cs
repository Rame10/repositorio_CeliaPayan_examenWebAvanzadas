using Pruebita.Models;
using System.Web.Mvc;

namespace Pruebita.Controllers
{
    public class LoginController : Controller
    {
        UsuarioDAL dal = new UsuarioDAL();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string usuario, string contraseña)
        {
            var user = dal.ValidarUsuario(usuario, contraseña);
            if (user != null)
            {
                Session["Usuario"] = user.UsuarioNombre;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        //Registro
        public ActionResult Registro()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registro (Usuario user, string RepetirContraseña)
        {
            //Validaciones
            if(user.Contraseña != RepetirContraseña)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }

            //Registrar
            if (dal.RegistrarUsuario(user))
            {
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Error = "Error al registrar el usuario";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}