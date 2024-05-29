using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructura.Persistemces.Context
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Facturadetalle> Facturadetalle { get; set; }
        public DbSet<Facturaencabezado> Facturaencabezado { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Producto> Producto { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}
