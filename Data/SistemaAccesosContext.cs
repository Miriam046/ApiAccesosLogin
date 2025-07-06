using System.Collections.Generic;
using ApiVigilancia.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiVigilancia.Data
{
    public class SistemaAccesosContext : DbContext
    {
        public SistemaAccesosContext(DbContextOptions<SistemaAccesosContext> options)
            : base(options)
        {
        }

        public DbSet<UsuariosResidentes> UsuariosResidentes { get; set; }
    }
}
