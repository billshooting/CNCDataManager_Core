using CNCDataManager.Controllers.Internals;
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
    [ApiAuthorize(Policy = nameof(AuthorizationLevel.ResourceOwner))]
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    public class PMSrvMotorDriversController : Controller
    {
        private CNCMachineData db;

        public PMSrvMotorDriversController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/PMSrvMotorDrivers
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<PMSrvMotorDriver> GetPMSrvMotorDrivers()
        {
            return db.PMSrvMotorDrivers;
        }

        // GET: api/PMSrvMotorDrivers/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPMSrvMotorDriver(string id)
        {
            PMSrvMotorDriver pMSrvMotorDriver = await db.PMSrvMotorDrivers.FindAsync(id);
            if (pMSrvMotorDriver == null)
            {
                return NotFound();
            }

            return Ok(pMSrvMotorDriver);
        }

        // PUT: api/PMSrvMotorDrivers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPMSrvMotorDriver(string id, [FromBody] PMSrvMotorDriver pMSrvMotorDriver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pMSrvMotorDriver.TypeID)
            {
                return BadRequest();
            }

            db.Entry(pMSrvMotorDriver).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PMSrvMotorDriverExists(id))
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

        // POST: api/PMSrvMotorDrivers
        [HttpPost]
        public async Task<IActionResult> PostPMSrvMotorDriver([FromBody] PMSrvMotorDriver pMSrvMotorDriver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PMSrvMotorDrivers.Add(pMSrvMotorDriver);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PMSrvMotorDriverExists(pMSrvMotorDriver.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pMSrvMotorDriver.TypeID }, pMSrvMotorDriver);
        }

        // DELETE: api/PMSrvMotorDrivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePMSrvMotorDriver(string id)
        {
            PMSrvMotorDriver pMSrvMotorDriver = await db.PMSrvMotorDrivers.FindAsync(id);
            if (pMSrvMotorDriver == null)
            {
                return NotFound();
            }

            db.PMSrvMotorDrivers.Remove(pMSrvMotorDriver);
            await db.SaveChangesAsync();

            return Ok(pMSrvMotorDriver);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PMSrvMotorDriverExists(string id)
        {
            return db.PMSrvMotorDrivers.Count(e => e.TypeID == id) > 0;
        }
    }
}