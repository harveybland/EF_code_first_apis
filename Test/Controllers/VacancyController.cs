using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Test.Models;

namespace Test.Controllers
{
    public class VacancyController : ApiController
    {
        private readonly MainModel db = new MainModel();

        // GET: api/Vacancy
        public async Task<List<Vacancy>> GetVacancies()
        {
            return await db.Vacancies.ToListAsync();
        }


        // GET: api/Vacancy/5
        public async Task<IHttpActionResult> GetVacancy(int Id)
        {
            var x = await db.Vacancies
                .Where(xx => xx.Id == Id).FirstOrDefaultAsync();

            var vacancy = new VacancyDto
            {
                Id = x.Id,
                JobTitle = x.JobTitle,
                InternalTitle = x.InternalTitle,
                ContractType = x.ContractType,
                Location = x.Location,
                Salary = x.Salary,
                SalaryType = x.SalaryType,
                BusinessArea = x.BusinessArea,
                Employee = new Employee
                {
                    Id = x.Employee.Id,
                    FirstName = x.Employee.FirstName,
                    LastName = x.Employee.LastName,
                    Gender = x.Employee.Gender
                },
                VacancyPets = x.VacancyPets.Select(vp => new VacancyPet {
                    Title = vp.Title,
                }).ToList()

            };

            return Ok(vacancy);
        }

        // POST: api/Vacancy
        public async Task<IHttpActionResult> PostVacancyModel(Vacancy vacancyModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vacancies.Add(vacancyModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vacancyModel.Id }, vacancyModel);
        }

        // PUT: api/Vacancy/5
        [HttpPut]
        public async Task<IHttpActionResult> PutVacancy(int id, Vacancy Model)
        {
            if (Model == null)
            {
                return NotFound();
            }
            var vacancy = await db.Vacancies.FirstOrDefaultAsync(x => x.Id == id);
            vacancy.JobTitle = Model.JobTitle;
            vacancy.InternalTitle = Model.InternalTitle;
            vacancy.Location = Model.Location;
            vacancy.Salary = Model.Salary;
            vacancy.SalaryType = Model.SalaryType;
            vacancy.BusinessArea = Model.BusinessArea;
            vacancy.ContractType = Model.ContractType;
            vacancy.EmployeeId = Model.EmployeeId;
            db.Entry(vacancy).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(vacancy);
            }

        // Add an employee to a vacancy
        // PUT: api/Vacancy
        [HttpPut]
        [Route("api/AddEmployee")]
        public async Task<IHttpActionResult> PutVacancyEmployee(int id, Vacancy Model)
        {
            if (Model == null)
            {
                return NotFound();
            }
            var vacancy = await db.Vacancies.FirstOrDefaultAsync(x => x.Id == id);
            vacancy.EmployeeId = Model.EmployeeId;
            db.Entry(vacancy).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(vacancy);
        }


        // DELETE: api/Vacancy/5
        public async Task<IHttpActionResult> DeleteVacancy(int id)
        {
            Vacancy vacancyModel = await db.Vacancies.FindAsync(id);
            if (vacancyModel == null)
            {
                return NotFound();
            }

            db.Vacancies.Remove(vacancyModel);
            await db.SaveChangesAsync();

            return Ok(vacancyModel);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

//         private bool VacancyExists(int id)
//         {
//             return db.Vacancies.Count(e => e.Id == id) > 0;
//         }
    }
}