using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarreraWebApp.Models;

namespace CarreraWebApp.Data
{
    public class CarreraWebAppContext : DbContext
    {
        public CarreraWebAppContext (DbContextOptions<CarreraWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<CarreraWebApp.Models.Participante> Participante { get; set; } = default!;
    }
}
