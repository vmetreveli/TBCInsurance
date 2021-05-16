using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace CleanArchitecture.Infrastructure.Data.Context
{
    public class UniDbContext :DbContext
    {

        // public UniDbContext(DbContextOptions options) : base(options)
        // {
        // }
        public UniDbContext(DbContextOptions<UniDbContext> options)
            : base(options)
        {
        }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}