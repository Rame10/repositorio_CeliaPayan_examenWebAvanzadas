using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pruebita.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Practica en clase
        public ActionResult Prueba()
        {
            ViewBag.Message = "Mensaje de prueba";

            return View();
        }

        //Practica clase
        public ActionResult Lista()
        {
            ViewBag.Message = "Lista de alumnos";

            return View();
        }

        //Practica en clase
        public ActionResult Dinamica()
        {
            List<string> alumnos = new List<string>()
            {
                 "Ornelas Valdez",
                 "Payan Leyva",
                 "Ramirez Felix",
                 "Olivas Almader",
                 "Ojeda Torres"
            };

            return View(alumnos);
        }
        //Practica en clase
        public ActionResult Bienvenida(string nombre)
        {
            ViewBag.Nombre = nombre;
            return View();
        }
        
        //Tarea
        public ActionResult Tabla()
        {
            ViewBag.Carrera = "Licenciatura en Sistemas Computacionales.";
            ViewBag.Materia = "Aplicaciones Web Avanzadas.";
            ViewBag.Docente = "Fabiola Cristina Beyrouty Zammar.";

            var alumnos = new List<string[]>()
            {
                new string[] {"23030006", "Eleazar",  "Ornelas", "Valdez"},
                new string[] {"23030689", "Celia Guadalupe",   "Payan",   "Leyva"},
                new string[] {"23030007", "Jose Leobardo",  "Ramirez", "Felix"},
                new string[] {"23030008", "José Francisco", "Olivas",  "Almader"},
                new string[] {"23030009", "José Daniel", "Ojeda",   "Torres"},
                new string[] {"23030010", "Mario", "Soto",   "Vea"},
                new string[] {"23030011", "José Joel", "Vega",   "Rojas"},
                new string[] {"23030012", "Gaddiel Alexandro", "Soto",   "Escobar"},
                new string[] {"23030013", "Neftalí Isaías", "Meléndrez",   "Salazar"},
                new string[] {"23030014", "Kevin Daniel", "Martha",   "Acosta"},
                new string[] {"23030015", "Roshet Adriana", "Medina",   "López"},
                new string[] {"23030016", "Ángel de Jesús", "Montoya",   "Hansen"},
                new string[] {"23030017", "Javier Aarel", "Rojas",   "Peñuelas"},
                new string[] {"22031483", "Hasley Keishynn", "Velazquez",   "Graciano"}
            };

            return View(alumnos);
        }

        //En clase parecido a la tarea
        public static List<string[]> alumno = new List<string[]>
        {
            new string[] {"23030006", "Eleazar",  "Ornelas", "Valdez", "LSC"},
            new string[] {"23030689", "Celia Guadalupe",   "Payan",   "Leyva", "LSC"},
            new string[] {"23030007", "Jose Leobardo", "Ramirez", "Felix", "LSC"},
            new string[] {"23030008", "José Francisco", "Olivas","Almader", "LSC"},
            new string[] {"23030009", "José Daniel", "Ojeda",   "Torres", "LSC"},
            new string[] {"23030010", "Mario", "Soto",   "Vea", "LSC"},
            new string[] {"23030011", "José Joel", "Vega",   "Rojas", "LSC"},
            new string[] {"23030012", "Gaddiel Alexandro", "Soto",   "Escobar", "LSC"},
            new string[] {"23030013", "Neftalí Isaías", "Meléndrez",   "Salazar", "LSC"},
            new string[] {"23030014", "Kevin Daniel", "Martha",   "Acosta", "LSC"},
            new string[] {"23030015", "Roshet Adriana", "Medina",   "López", "LSC"},
            new string[] {"23030016", "Ángel de Jesús", "Montoya",   "Hansen", "LSC"},
            new string[] {"23030017", "Javier Aarel", "Rojas","Peñuelas", "LSC"},
            new string[] {"22031483", "Hasley Keishynn", "Velazquez", "Graciano", "LSC"}

        };
        
        public ActionResult ListaT()
        {
            ViewBag.Alumno = alumno;
            return View();
        }

        [HttpPost]
        public ActionResult Agregar (string matricula, string nombre, string paterno, string materno, string carrera)
        {
            alumno.Add(new string[] { matricula, nombre, paterno, materno, carrera });
            return RedirectToAction("ListaT");
        }

        //Tarea
        public ActionResult Login()
        {
            return View();
        }
    }
}