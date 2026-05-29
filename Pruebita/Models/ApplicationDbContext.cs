using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pruebita.Models
{
    public class ApplicationDbContext : System.Data.Entity.DbContext
    {
        public ApplicationDbContext():base("ConexionDB") 
        { 
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}