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
    public class SrvDriverBrakeResistorsController : Controller
    {
        private CNCMachineData db;

        public SrvDriverBrakeResistorsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/SrvDriverBrakeResistors
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<SrvDriverBrakeResistor> GetSrvDriverBrakeResistors()
        {
            return db.SrvDriverBrakeResistors;
        }

        // GET: api/SrvDriverBrakeResistors/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSrvDriverBrakeResistor(string id)
        {
            SrvDriverBrakeResistor srvDriverBrakeResistor = await db.SrvDriverBrakeResistors.FindAsync(id);
            if (srvDriverBrakeResistor == null)
            {
                return NotFound();
            }

            return Ok(srvDriverBrakeResistor);
        }

        // PUT: api/SrvDriverBrakeResistors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSrvDriverBrakeResistor(string id, [FromBody] SrvDriverBrakeResistor srvDriverBrakeResistor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != srvDriverBrakeResistor.TypeID)
            {
                return BadRequest();
            }

            db.Entry(srvDriverBrakeResistor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SrvDriverBrakeResistorExists(id))
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

        // POST: api/SrvDriverBrakeResistors
        [HttpPost]
        public async Task<IActionResult> PostSrvDriverBrakeResistor([FromBody]SrvDriverBrakeResistor srvDriverBrakeResistor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SrvDriverBrakeResistors.Add(srvDriverBrakeResistor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SrvDriverBrakeResistorExists(srvDriverBrakeResistor.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = srvDriverBrakeResistor.TypeID }, srvDriverBrakeResistor);
        }

        // DELETE: api/SrvDriverBrakeResistors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSrvDriverBrakeResistor(string id)
        {
            SrvDriverBrakeResistor srvDriverBrakeResistor = await db.SrvDriverBrakeResistors.FindAsync(id);
            if (srvDriverBrakeResistor == null)
            {
                return NotFound();
            }

            db.SrvDriverBrakeResistors.Remove(srvDriverBrakeResistor);
            await db.SaveChangesAsync();

            return Ok(srvDriverBrakeResistor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SrvDriverBrakeResistorExists(string id)
        {
            return db.SrvDriverBrakeResistors.Count(e => e.TypeID == id) > 0;
        }
    }
}