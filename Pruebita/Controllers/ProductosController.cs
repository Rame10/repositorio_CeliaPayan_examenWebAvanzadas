using Pruebita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Pruebita.Controllers
{
    public class ProductosController : Controller
    {
        private ProductoDAL dal = new ProductoDAL();
        private ApplicationDbContext db = new ApplicationDbContext();
        public static List<Producto> carrito = new List<Producto>(); // El carrito se actualiza a tipo Producto

        public ActionResult ListaP()
        {
            ViewBag.Categorias = new SelectList(db.Categorias.ToList(), "IdCategoria", "Nombre");

            var productos = db.Productos.Include("Categoria").ToList(); // Carga los productos con su categoría para mostrar el nombre de la categoría en la vista
            return View(productos);
        }

        public ActionResult ProductosAPI() 
        { 
            return View(); 
        }

        [HttpPost]
        // Suponiendo que el Id es int, si lo dejaste como string en el modelo, cámbialo aquí a string
        public ActionResult AgregarP(string nombre, int idcategoria, string descripcion, decimal precio)
        {
            Producto nuevo = new Producto
            {
                Nombre = nombre,
                IdCategoria = idcategoria,
                Descripcion = descripcion,
                Precio = precio
            };
            dal.InsertarProducto(nuevo);
            return RedirectToAction("ListaP");
        }
        [HttpPost]
        public ActionResult EliminarP(int id)
        {
            dal.EliminarProducto(id); // Elimina de la BD
            return RedirectToAction("ListaP");
        }

        [HttpPost]
        public ActionResult AgregarAlCarrito(int id)
        {
            // Busca el producto en la base de datos
            var producto = dal.ObtenerProductos().FirstOrDefault(p => p.Id == Convert.ToInt32(id));
            if (producto != null)
            {
                carrito.Add(producto);
            }
            return RedirectToAction("ListaP");
        }

        public ActionResult ListaCarrito()
        {
            ViewBag.Carrito = carrito;
            return View();
        }

        ////Practica en clase
        //public static List<string[]> productos = new List<string[]>()
        //{
        //   new string[] { "001", "Laptop", "Electronica", "16 GB Ram, Ryzen 07, 512 GBSSD","10.000"},
        //   new string[] { "002", "Mouse", "Electronica", "Inalambrico", "500.000"},
        //   new string[] { "003", "Teclado", "Electronica", "Mecanico gris", "1000.000"},
        //   new string[] { "004", "USB", "Electronica", "512 GB", "450.000"},
        //   new string[] { "005", "Desktop", "Electronica", "32 GB Ram, Ryzen 07, 1 TB SSD","15.000"},
        //};
        ////ViewBag.Productos = productos;
        ////return View();

        //public static List<string[]> carrito = new List<string[]>();
        //public ActionResult ListaP()
        //{
        //    ViewBag.Productos = productos;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AgregarP(string id, string producto, string categoria, string descripcion, string precio)
        //{
        //    productos.Add(new string[] { id, producto, categoria, descripcion, precio });
        //    return RedirectToAction("ListaP");
        //}

        ////Tarea
        //[HttpPost]
        //public ActionResult EliminarP(string id)
        //{
        //    var producto = productos.FirstOrDefault(p => p[0] == id);
        //    if (producto != null)
        //    {
        //        productos.Remove(producto);
        //    }
        //    return RedirectToAction("ListaP");
        //}

        ////Parte del examen hecho en clase
        //[HttpPost]
        //public ActionResult AgregarAlCarrito(string id)
        //{
        //    var producto = productos.FirstOrDefault(p => p[0] == id);
        //    if (producto != null)
        //    {
        //        carrito.Add(producto);
        //    }
        //    return RedirectToAction("ListaP");
        //}   

        ////Maestra, lo que hacía que no cargara la vista del carrito cuando agregaba un producto al carrito era que en el Layout no hacía referencia a ListaCarrito, sino que solo estaba escrito "carrito".
        //public ActionResult ListaCarrito()
        //{
        //    ViewBag.Carrito = carrito;
        //    return View();
        //}


    }
}
