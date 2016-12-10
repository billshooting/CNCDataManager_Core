using CNCDataManager.Models.APIs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CNCDataManager.Controllers.APIs
{
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    public class StepMotorSizesController : Controller
    {
        private CNCMachineData db;

        public StepMotorSizesController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/StepMotorSizes
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<StepMotorSize> GetStepMotorSizes()
        {
            return db.StepMotorSizes;
        }

        // GET: api/StepMotorSizes/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStepMotorSize(string id)
        {
            StepMotorSize stepMotorSize = await db.StepMotorSizes.FindAsync(id);
            if (stepMotorSize == null)
            {
                return NotFound();
            }

            return Ok(stepMotorSize);
        }

        // PUT: api/StepMotorSizes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStepMotorSize(string id, StepMotorSize stepMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stepMotorSize.TypeID)
            {
                return BadRequest();
            }

            db.Entry(stepMotorSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepMotorSizeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode((int)HttpStatusCode.NoContent);
        }

        // POST: api/StepMotorSizes
        [HttpPost]
        public async Task<IActionResult> PostStepMotorSize(StepMotorSize stepMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StepMotorSizes.Add(stepMotorSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StepMotorSizeExists(stepMotorSize.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = stepMotorSize.TypeID }, stepMotorSize);
        }

        // DELETE: api/StepMotorSizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStepMotorSize(string id)
        {
            StepMotorSize stepMotorSize = await db.StepMotorSizes.FindAsync(id);
            if (stepMotorSize == null)
            {
                return NotFound();
            }

            db.StepMotorSizes.Remove(stepMotorSize);
            await db.SaveChangesAsync();

            return Ok(stepMotorSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StepMotorSizeExists(string id)
        {
            return db.StepMotorSizes.Count(e => e.TypeID == id) > 0;
        }
    }
}