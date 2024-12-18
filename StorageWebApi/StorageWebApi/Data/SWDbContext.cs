using Microsoft.EntityFrameworkCore;
using StorageWebApi.Data.Models;

namespace StorageWebApi.Data
{
    public class SWDbContext : DbContext
    {
        public SWDbContext(DbContextOptions<SWDbContext> options) : base(options) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageDB");
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
    }
}
