using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Test.Models;

namespace Test.Controllers
{
    public class VacancyEmployeeController : ApiController
    {
        private readonly MainModel db = new MainModel();

        // Get vacancy employees 
        // GET: api/VacancyEmployees/{id}
        public async Task<IHttpActionResult> GetVacancyEmployees(int Id)
        {
            var x = await db.Vacancies
                .Where(xx => xx.Id == Id).FirstOrDefaultAsync();

            var vacancyEmployee = new VacancyEmployee
            {
                Vacancy = new Vacancy
                {

                },
                Employee = new Employee
                {
                    Id = x.Employee.Id,
                    FirstName = x.Employee.FirstName,
                    LastName = x.Employee.LastName,
                    Gender = x.Employee.Gender
                },
            };


            return Ok(vacancyEmployee);
        }
    }
}
