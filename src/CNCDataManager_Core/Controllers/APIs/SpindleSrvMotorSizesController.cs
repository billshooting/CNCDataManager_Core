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
    public class SpindleSrvMotorSizesController : Controller
    {
        private CNCMachineData db;

        public SpindleSrvMotorSizesController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/SpindleSrvMotorSizes
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<SpindleSrvMotorSize> GetSpindleSrvMotorSizes()
        {
            return db.SpindleSrvMotorSizes;
        }

        // GET: api/SpindleSrvMotorSizes/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpindleSrvMotorSize(string id)
        {
            SpindleSrvMotorSize spindleSrvMotorSize = await db.SpindleSrvMotorSizes.FindAsync(id);
            if (spindleSrvMotorSize == null)
            {
                return NotFound();
            }

            return Ok(spindleSrvMotorSize);
        }

        // PUT: api/SpindleSrvMotorSizes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpindleSrvMotorSize(string id, SpindleSrvMotorSize spindleSrvMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spindleSrvMotorSize.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spindleSrvMotorSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpindleSrvMotorSizeExists(id))
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

        // POST: api/SpindleSrvMotorSizes
        [HttpPost]
        public async Task<IActionResult> PostSpindleSrvMotorSize(SpindleSrvMotorSize spindleSrvMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpindleSrvMotorSizes.Add(spindleSrvMotorSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpindleSrvMotorSizeExists(spindleSrvMotorSize.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spindleSrvMotorSize.TypeID }, spindleSrvMotorSize);
        }

        // DELETE: api/SpindleSrvMotorSizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpindleSrvMotorSize(string id)
        {
            SpindleSrvMotorSize spindleSrvMotorSize = await db.SpindleSrvMotorSizes.FindAsync(id);
            if (spindleSrvMotorSize == null)
            {
                return NotFound();
            }

            db.SpindleSrvMotorSizes.Remove(spindleSrvMotorSize);
            await db.SaveChangesAsync();

            return Ok(spindleSrvMotorSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpindleSrvMotorSizeExists(string id)
        {
            return db.SpindleSrvMotorSizes.Count(e => e.TypeID == id) > 0;
        }
    }
}