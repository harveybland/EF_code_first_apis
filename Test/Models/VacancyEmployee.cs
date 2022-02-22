using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class VacancyEmployee
    {
        public int VacancyId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Vacancy Vacancy { get; set; }
    }
}