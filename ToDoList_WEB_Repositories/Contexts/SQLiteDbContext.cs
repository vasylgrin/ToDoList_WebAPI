using Microsoft.EntityFrameworkCore;
using ToDoList_WEB_Entity.Models;

namespace ToDoList_WEB_Repositories.Contexts
{
    internal sealed class SQLiteDbContext : DbContext
    {
        public DbSet<ToDo> ToDoes => Set<ToDo>();
        public DbSet<User> Users => Set<User>();

        public SQLiteDbContext() => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ToDo>()
                .HasOne(t => t.User)
                .WithMany(u => u.ToDoes)
                .HasForeignKey(t => t.UserId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source =ToDo.db");
    }
}
