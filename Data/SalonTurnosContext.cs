using Microsoft.EntityFrameworkCore;
using SalonTurnos.Models;

namespace SalonTurnos.Data
{
    public class SalonTurnosContext : DbContext
    {
        public SalonTurnosContext(DbContextOptions<SalonTurnosContext> options) 
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Turno> Turnos { get; set; }
    }
}
