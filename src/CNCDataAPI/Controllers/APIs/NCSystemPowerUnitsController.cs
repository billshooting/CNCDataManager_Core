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
    //[ApiAuthorize]
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    public class NCSystemPowerUnitsController : Controller
    {
        private CNCMachineData db;

        public NCSystemPowerUnitsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/NCSystemPowerUnits
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<NCSystemPowerUnit> GetNCSystemPowerUnits()
        {
            return db.NCSystemPowerUnits;
        }

        // GET: api/NCSystemPowerUnits/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNCSystemPowerUnit(string id)
        {
            NCSystemPowerUnit nCSystemPowerUnit = await db.NCSystemPowerUnits.FindAsync(id);
            if (nCSystemPowerUnit == null)
            {
                return NotFound();
            }

            return Ok(nCSystemPowerUnit);
        }

        // PUT: api/NCSystemPowerUnits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNCSystemPowerUnit(string id, [FromBody] NCSystemPowerUnit nCSystemPowerUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nCSystemPowerUnit.TypeID)
            {
                return BadRequest();
            }

            db.Entry(nCSystemPowerUnit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCSystemPowerUnitExists(id))
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

        // POST: api/NCSystemPowerUnits
        [HttpPost]
        public async Task<IActionResult> PostNCSystemPowerUnit([FromBody] NCSystemPowerUnit nCSystemPowerUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NCSystemPowerUnits.Add(nCSystemPowerUnit);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NCSystemPowerUnitExists(nCSystemPowerUnit.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nCSystemPowerUnit.TypeID }, nCSystemPowerUnit);
        }

        // DELETE: api/NCSystemPowerUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCSystemPowerUnit(string id)
        {
            NCSystemPowerUnit nCSystemPowerUnit = await db.NCSystemPowerUnits.FindAsync(id);
            if (nCSystemPowerUnit == null)
            {
                return NotFound();
            }

            db.NCSystemPowerUnits.Remove(nCSystemPowerUnit);
            await db.SaveChangesAsync();

            return Ok(nCSystemPowerUnit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NCSystemPowerUnitExists(string id)
        {
            return db.NCSystemPowerUnits.Count(e => e.TypeID == id) > 0;
        }
    }
}