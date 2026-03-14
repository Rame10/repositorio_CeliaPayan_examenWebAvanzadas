using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pruebita.Controllers
{
    public class ProductosController : Controller
    {  
        //Practica en clase
        public static List<string[]> productos = new List<string[]>()
        {
           new string[] { "001", "Laptop", "Electronica", "16 GB Ram, Ryzen 07, 512 GBSSD","10.000"},
           new string[] { "002", "Mouse", "Electronica", "Inalambrico", "500.000"},
           new string[] { "003", "Teclado", "Electronica", "Mecanico gris", "1000.000"},
           new string[] { "004", "USB", "Electronica", "512 GB", "450.000"},
           new string[] { "005", "Desktop", "Electronica", "32 GB Ram, Ryzen 07, 1 TB SSD","15.000"},
        };
        //ViewBag.Productos = productos;
        //return View();
        
        public static List<string[]> carrito = new List<string[]>();
        public ActionResult ListaP()
        {
            ViewBag.Productos = productos;
            return View();
        }

        [HttpPost]
        public ActionResult AgregarP(string id, string producto, string categoria, string descripcion, string precio)
        {
            productos.Add(new string[] { id, producto, categoria, descripcion, precio });
            return RedirectToAction("ListaP");
        }

        //Tarea
        [HttpPost]
        public ActionResult EliminarP(string id)
        {
            var producto = productos.FirstOrDefault(p => p[0] == id);
            if (producto != null)
            {
                productos.Remove(producto);
            }
            return RedirectToAction("ListaP");
        }

        //Parte del examen hecho en clase
        [HttpPost]
        public ActionResult AgregarAlCarrito(string id)
        {
            var producto = productos.FirstOrDefault(p => p[0] == id);
            if (producto != null)
            {
                carrito.Add(producto);
            }
            return RedirectToAction("ListaP");
        }   

        //Maestra, lo que hacía que no cargara la vista del carrito cuando agregaba un producto al carrito era que en el Layout no hacía referencia a ListaCarrito, sino que solo estaba escrito "carrito".
        public ActionResult ListaCarrito()
        {
            ViewBag.Carrito = carrito;
            return View();
        }

        
    }
}
