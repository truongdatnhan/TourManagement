using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class TourContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public TourContext(DbContextOptions<TourContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //apply tất cả mà không phải thêm từng cái config
        }

        public DbSet<TourDuLich> TourDuLiches { get; set; }
    }
}