using Microsoft.EntityFrameworkCore;
using TechCareerCodeFirstBook.Models;

namespace TechCareerCodeFirstBook.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<Kitap> Kitap { get; set; }
    }
}
