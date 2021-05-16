using CleanArchitecture.Domain.Identity.Models;
using CleanArchitecture.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CleanArchitecture.Infrastructure.Data.Context
{
    public class UniDbContext : IdentityDbContext<User>
    {

        // public UniDbContext(DbContextOptions options) : base(options)
        // {
        // }
        public UniDbContext(DbContextOptions<UniDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}