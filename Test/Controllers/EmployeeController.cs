using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;
using Test.Models;

namespace Test.Controllers
{
    public class EmployeeController : ApiController

    {
        private readonly MainModel db = new MainModel();

        // GET api/Employee
        public async Task<List<Employee>> GetEmployees() 
        {
            return await db.Employees.ToListAsync();
        }



        // GET api/Employee/5
        public async Task<Employee> GetEmployee(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            return employee;
        }


        // POST api/Employee
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}