using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlazorAuth.Areas.Identity.Data;

namespace BlazorAuth.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PostMesssage> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}