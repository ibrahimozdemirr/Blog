using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Proxies;

namespace DataAccessLayer.Context
{
    public partial class BlogDBContext : DbContext
    {
        public BlogDBContext()
        {
        }

       

        public virtual DbSet<AboutUs> AboutUs { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
 => optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Data Source=localhost;Initial Catalog=io.Blog2;Integrated Security=True;TrustServerCertificate=true;");
           
        }
           

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.UserId);
            });
            modelBuilder.Entity<AboutUs>(entity =>
            {
                entity.Property(e => e.AboutId);
            });
            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.PostId);

                entity.HasOne(d => d.Users)
                .WithMany(p => p.Posts)
                .HasForeignKey(f=>f.userId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                
                entity.HasOne(p => p.Categories)
                .WithMany(s => s.Posts)
                .HasForeignKey(a => a.categoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                



            });
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.CategoryId);
            });
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.CommentId);
                entity.HasOne(d => d.Users)
                .WithMany(p => p.Comments)
                .HasForeignKey(f => f.userId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Posts)
                .WithMany(p => p.Comments)
                .HasForeignKey(f => f.postId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });
            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.TagId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
