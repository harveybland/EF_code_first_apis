using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class EmployeeAddress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
    }
}