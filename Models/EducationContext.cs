using Microsoft.EntityFrameworkCore;

namespace MVC.Models
{
    public class EducationContext:DbContext
    {
        public EducationContext()
        {

        }
        public EducationContext(DbContextOptions options) : base(options)//inject
        {

        }
        public DbSet <Course> courses { get; set; }
        public DbSet<CrsResult> crsResults { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Trainee> trainees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PHGQ0U7;Database=EducationSystem;Trusted_Connection=True;TrustServerCertificate=true;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
