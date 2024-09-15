using Microsoft.EntityFrameworkCore;
using pet2.Models.Entities;

namespace pet2.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Note> Notes { get; set; }
    }
}
