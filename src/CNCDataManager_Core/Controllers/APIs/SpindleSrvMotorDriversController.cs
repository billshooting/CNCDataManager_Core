using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using CNCDataManager.Models.APIs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CNCDataManager.Controllers.APIs
{
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    public class SpindleSrvMotorDriversController : Controller
    {
        private CNCMachineData db;

        public SpindleSrvMotorDriversController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/SpindleSrvMotorDrivers
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<SpindleSrvMotorDriver> GetSpindleSrvMotorDrivers()
        {
            return db.SpindleSrvMotorDrivers;
        }

        // GET: api/SpindleSrvMotorDrivers/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpindleSrvMotorDriver(string id)
        {
            SpindleSrvMotorDriver spindleSrvMotorDriver = await db.SpindleSrvMotorDrivers.FindAsync(id);
            if (spindleSrvMotorDriver == null)
            {
                return NotFound();
            }

            return Ok(spindleSrvMotorDriver);
        }

        // PUT: api/SpindleSrvMotorDrivers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpindleSrvMotorDriver(string id, SpindleSrvMotorDriver spindleSrvMotorDriver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spindleSrvMotorDriver.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spindleSrvMotorDriver).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpindleSrvMotorDriverExists(id))
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

        // POST: api/SpindleSrvMotorDrivers
        [HttpPost]
        public async Task<IActionResult> PostSpindleSrvMotorDriver(SpindleSrvMotorDriver spindleSrvMotorDriver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpindleSrvMotorDrivers.Add(spindleSrvMotorDriver);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpindleSrvMotorDriverExists(spindleSrvMotorDriver.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spindleSrvMotorDriver.TypeID }, spindleSrvMotorDriver);
        }

        // DELETE: api/SpindleSrvMotorDrivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpindleSrvMotorDriver(string id)
        {
            SpindleSrvMotorDriver spindleSrvMotorDriver = await db.SpindleSrvMotorDrivers.FindAsync(id);
            if (spindleSrvMotorDriver == null)
            {
                return NotFound();
            }

            db.SpindleSrvMotorDrivers.Remove(spindleSrvMotorDriver);
            await db.SaveChangesAsync();

            return Ok(spindleSrvMotorDriver);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpindleSrvMotorDriverExists(string id)
        {
            return db.SpindleSrvMotorDrivers.Count(e => e.TypeID == id) > 0;
        }
    }
}