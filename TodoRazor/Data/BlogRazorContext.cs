using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogRazor.Models;
using Microsoft.EntityFrameworkCore;


namespace BlogRazor.Data
{
    public class BlogRazorContext : DbContext
    {
        public BlogRazorContext (DbContextOptions<BlogRazorContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blog { get; set; } = default!;
        public DbSet<Comment> Comment { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Blog)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.BlogId);
        }
    }
}
