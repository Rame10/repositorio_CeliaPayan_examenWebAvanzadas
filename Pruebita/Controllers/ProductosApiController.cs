using Pruebita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pruebita.Controllers
{
    public class ProductosApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public IHttpActionResult Obtener()
        {
            var Productos = db.Productos.Select(p => new
            {
                p.Id,
                p.Nombre,
                p.Precio,
            }).ToList();

            return Ok(Productos);
        }

        public IHttpActionResult Agregar(Producto p)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(p);
                db.SaveChanges();
                return Ok("Producto Agregado");

            }
            return BadRequest();
        }
    }
}

