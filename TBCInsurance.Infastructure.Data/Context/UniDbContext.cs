using Microsoft.EntityFrameworkCore;
using TBCInsurance.Domain.Models;


namespace TBCInsurance.Infastructure.Data.Context
{
    public  class UniDbContext: DbContext
    {
   
        public UniDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
