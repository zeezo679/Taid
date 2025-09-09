using Demo.Models.Entities;
using Demo.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CrsResult> crsResults { get; set; }

        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connection = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("constr");

            optionsBuilder.UseSqlServer(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisterViewModel>(m => m.HasNoKey());
            modelBuilder.Entity<LoginViewModel>(m => m.HasNoKey());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Demo.ViewModel.RegisterViewModel> RegisterViewModel { get; set; } = default!;
        public DbSet<Demo.ViewModel.LoginViewModel> LoginViewModel { get; set; } = default!;
    }
}
