using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace FullStackMon.Models
{
    public class ITIContext:DbContext
    {
        public ITIContext():base()
        {
            
        }
        //parameter construct
        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {

        }


        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //build dbcontextOptions
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ICCMonf2025;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);//Empty no defualt implementation
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //insert Employe ,Departme
            modelBuilder.Entity<Department>().HasData(new Department() { Id=1,Name="SD",ManagerName="Ahmed"});
            modelBuilder.Entity<Department>().HasData(new Department() { Id = 2, Name = "OS", ManagerName = "Mohamed" });

            modelBuilder.Entity<Employee>()
                .HasData(new Employee () { Id = 1, Name = "AbdElRahman",Salary=50000,Address="Alex",ImageUrl="m.png",DepartmentId=1 });

            modelBuilder.Entity<Employee>()
                .HasData(new Employee() { Id = 2, Name = "Amany", Salary = 50000, Address = "Alex", ImageUrl = "2.jpg", DepartmentId = 2 });

            modelBuilder.Entity<Employee>()
                .HasData(new Employee() { Id = 3, Name = "Marwa", Salary = 50000, Address = "Cairo", ImageUrl = "2.jpg", DepartmentId = 1 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
