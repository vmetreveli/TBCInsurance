using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace CleanArchitecture.Infra.Data.Context
{
    public class UniDbContext : DbContext
    {

        public UniDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
