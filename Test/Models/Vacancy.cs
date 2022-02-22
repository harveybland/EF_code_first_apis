using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class Vacancy
    {
        public int Id { get; set; }

        public string JobTitle { get; set; }
        public string InternalTitle { get; set; }
        public string ContractType { get; set; }
        public string Location { get; set; }
        public int Salary { get; set; }
        public string SalaryType { get; set; }
        public string BusinessArea { get; set; }

        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual List<VacancyPet> VacancyPets { get; set; }
    }

    public class VacancyDto
    {
        public int Id { get; set; }

        public string JobTitle { get; set; }
        public string InternalTitle { get; set; }
        public string ContractType { get; set; }
        public string Location { get; set; }
        public int Salary { get; set; }
        public string SalaryType { get; set; }
        public string BusinessArea { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual List<VacancyPet> VacancyPets { get; set; }
    }
}