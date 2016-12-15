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
    public class NCSystemIOUnitsController : Controller
    {
        private CNCMachineData db;

        public NCSystemIOUnitsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/NCSystemIOUnits
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<NCSystemIOUnit> GetNCSystemIOUnits()
        {
            return db.NCSystemIOUnits;
        }

        // GET: api/NCSystemIOUnits/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNCSystemIOUnit(string id)
        {
            NCSystemIOUnit nCSystemIOUnit = await db.NCSystemIOUnits.FindAsync(id);
            if (nCSystemIOUnit == null)
            {
                return NotFound();
            }

            return Ok(nCSystemIOUnit);
        }

        // PUT: api/NCSystemIOUnits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNCSystemIOUnit(string id, [FromBody] NCSystemIOUnit nCSystemIOUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nCSystemIOUnit.TypeID)
            {
                return BadRequest();
            }

            db.Entry(nCSystemIOUnit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCSystemIOUnitExists(id))
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

        // POST: api/NCSystemIOUnits
        [HttpPost]
        public async Task<IActionResult> PostNCSystemIOUnit([FromBody] NCSystemIOUnit nCSystemIOUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NCSystemIOUnits.Add(nCSystemIOUnit);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NCSystemIOUnitExists(nCSystemIOUnit.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nCSystemIOUnit.TypeID }, nCSystemIOUnit);
        }

        // DELETE: api/NCSystemIOUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCSystemIOUnit(string id)
        {
            NCSystemIOUnit nCSystemIOUnit = await db.NCSystemIOUnits.FindAsync(id);
            if (nCSystemIOUnit == null)
            {
                return NotFound();
            }

            db.NCSystemIOUnits.Remove(nCSystemIOUnit);
            await db.SaveChangesAsync();

            return Ok(nCSystemIOUnit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NCSystemIOUnitExists(string id)
        {
            return db.NCSystemIOUnits.Count(e => e.TypeID == id) > 0;
        }
    }
}