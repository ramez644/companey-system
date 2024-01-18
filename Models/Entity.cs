using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace test.Models
{
    public class Entity:IdentityDbContext<ApplicationUser>
    {
        public Entity():base() { 



        }
        public Entity(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-6EP3OR2\\SQLEXPRESS;Initial Catalog=.nettest;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }





    }
}
