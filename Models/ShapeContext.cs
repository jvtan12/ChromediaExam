using Microsoft.EntityFrameworkCore;

namespace ShapeCommander.Models
{
    public class ShapeContext : DbContext
    {
        public ShapeContext(DbContextOptions<ShapeContext> options)
        : base (options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Shape> Shapes { get; set; }
    }
}