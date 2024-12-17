using Microsoft.EntityFrameworkCore;

namespace StorageWebApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } // DbSet<User> megfelelő hivatkozás

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.\\Data\\SQlLiteDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Biztosítsd, hogy a User osztály megfelelően legyen hozzárendelve a táblához
            modelBuilder.Entity<User>().ToTable("Users");
        }

        public async Task AddUserAsync(User user)
        {
            using (var context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("Data Source=.\\Data\\SQlLiteDatabase.db")
                .Options))
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
