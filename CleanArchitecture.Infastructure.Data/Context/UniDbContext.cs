using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Models.Entities;
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
    }
}
