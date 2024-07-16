using Microsoft.EntityFrameworkCore;
using TinTuc.Domain.Model;

namespace TinTuc.Infrastructure.MyDB
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Articledetail> Articledetails { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .Property(a => a.Content)
                .HasColumnType("text");

            modelBuilder.Entity<Articledetail>()
                .Property(a => a.Content)
                .HasColumnType("text");

            modelBuilder.Entity<Comment>()
                .Property(a => a.Content)
                .HasColumnType("text");
        }

        internal object Skip(int v)
        {
            throw new NotImplementedException();
        }
    }
}
