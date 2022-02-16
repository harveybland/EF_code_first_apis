using System.Data.Entity;
using Test.Models;

namespace Test
{
    public partial class MainModel : DbContext
    {
        public MainModel()
            : base("name=MainModel")
        {
        }
         
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }

        public virtual DbSet<EmployeeAddress> EmployeeAddresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {}

    }
}
