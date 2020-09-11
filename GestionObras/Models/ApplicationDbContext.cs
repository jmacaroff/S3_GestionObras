using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionObras.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        { 

        }

        public DbSet<Productos> Productos { get; set; }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Proveedores> Proveedores { get; set; }
    }
}

