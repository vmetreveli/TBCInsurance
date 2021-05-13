using CleanArchitecture.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CleanArchitecture.Infra.Data.Context
{
    public class UniDbContext : IdentityDbContext
    {

        // public UniDbContext(DbContextOptions options) : base(options)
        // {
        // }
        public UniDbContext(DbContextOptions<UniDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
