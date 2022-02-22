using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;
using Test.Models;
using System.Web.Http.Description;
//using AutoMapper;

namespace Test.Controllers
{
    public class EmployeeController : ApiController

    {
        private readonly MainModel db = new MainModel();

        // GET api/Employee
        public async Task<List<EmployeeDto>> GetEmployees() 
        {

            var employees = await db.Employees
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Gender = x.Gender
                })
                .ToListAsync();
            return employees;
        }

        // GET api/Employee/5
//         public async Task<Employee> GetEmployee(int id)
//         {
//             Employee employee = await db.Employees.FindAsync(id);
//             return employee;
//         }

        // GET api/Employee/5
        [ResponseType(typeof(EmployeeView))]
        public async Task<IHttpActionResult> GetEmployee(int Id)
        {
            var x = await db.Employees
                .Include(xx => xx.EmployeeAddress)
                .Where(xx => xx.Id == Id).FirstOrDefaultAsync();
                
            var employee2 = new EmployeeView
                {
                    Id = x.Id ,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmployeeAddress = new EmployeeAddress
                    {
                        Country = x.EmployeeAddress.Country,
                        County = x.EmployeeAddress.County,
                        Postcode = x.EmployeeAddress.Postcode,
                        Street = x.EmployeeAddress.Street,
                    }
                };

            return Ok(employee2);
        }


        // POST api/Employee
        public async Task<IHttpActionResult> PostEmployee(Employee model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(model);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }
    }

        // PUT api/<controller>/5
//         public void Put(int id, [FromBody] string value)
//         {
//         }
// 
//         // DELETE api/<controller>/5
//         public void Delete(int id)
//         {
//         }
    
}