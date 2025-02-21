using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace L01_2022VF650_2022MV652.Models
{
    public class blogDBContext : DbContext
    {
        public blogDBContext(DbContextOptions<blogDBContext> options) : base(options)
        {
        }
        public DbSet<usuarios> usuarios { get; set; }

        public DbSet<calificaciones> calificaciones { get; set; }

        public DbSet<comentarios> comentarios { get; set; }
    }
}
