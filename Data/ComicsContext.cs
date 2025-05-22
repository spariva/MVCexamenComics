using Microsoft.EntityFrameworkCore;
using MVCexamenComics.Models;

namespace MVCexamenComics.Data
{
    public class ComicsContext: DbContext
    {
        public ComicsContext(DbContextOptions<ComicsContext> options) : base(options)
        {
        }

        public DbSet<Comic> Comics { get; set; }
    }
}
