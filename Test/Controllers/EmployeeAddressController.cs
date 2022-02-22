
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Test.Models;

namespace Test.Controllers
{
    public class EmployeeAddressController : ApiController
    {
        private readonly MainModel db = new MainModel();

        // GET: api/EmployeeAddress
        public IQueryable<EmployeeAddress> GetEmployeeAddresses()
        {
            return db.EmployeeAddresses;
        }


        // GET: api/EmployeeAddress/5
        [ResponseType(typeof(EmployeeAddress))]
        public async Task<IHttpActionResult> GetEmployeeAddress(int id)
        {
            EmployeeAddress employeeAddress = await db.EmployeeAddresses.FindAsync(id);
            if (employeeAddress == null)
            {
                return NotFound();
            }

            return Ok(employeeAddress);
        }


        // PUT: api/EmployeeAddress/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployeeAddress(int id, EmployeeAddress employeeAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeAddress.Id)
            {
                return BadRequest();
            }

            db.Entry(employeeAddress).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeAddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EmployeeAddress
        [ResponseType(typeof(EmployeeAddress))]
        public async Task<IHttpActionResult> PostEmployeeAddress(EmployeeAddress employeeAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeAddresses.Add(employeeAddress);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employeeAddress.Id }, employeeAddress);
        }

        // DELETE: api/EmployeeAddress/5
        [ResponseType(typeof(EmployeeAddress))]
        public async Task<IHttpActionResult> DeleteEmployeeAddress(int id)
        {
            EmployeeAddress employeeAddress = await db.EmployeeAddresses.FindAsync(id);
            if (employeeAddress == null)
            {
                return NotFound();
            }

            db.EmployeeAddresses.Remove(employeeAddress);
            await db.SaveChangesAsync();

            return Ok(employeeAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeAddressExists(int id)
        {
            return db.EmployeeAddresses.Count(e => e.Id == id) > 0;
        }
    }
}