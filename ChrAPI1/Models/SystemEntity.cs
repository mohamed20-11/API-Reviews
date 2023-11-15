using Microsoft.EntityFrameworkCore;

namespace ChrAPI1.Models
{
    public class SystemEntity:DbContext
    {
        public SystemEntity()
        {
            
        }
        public SystemEntity (DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\MSSQLSERVER02;Initial Catalog=ChrAPI;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
