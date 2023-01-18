using Microsoft.EntityFrameworkCore;
using Pronia_Task_.Models;

namespace Pronia_Task_.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
    }
}
