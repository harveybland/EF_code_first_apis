using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int AddressId { get; set; }
    }

    public class EmployeeView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("EmployeeAddressId")]
        public virtual EmployeeAddress EmployeeAddress { get; set; }
    }

}
