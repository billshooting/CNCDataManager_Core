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
    public class RotaryTablesController : Controller
    {
        private CNCMachineData db;

        public RotaryTablesController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/RotaryTables
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<RotaryTable> GetRotaryTables()
        {
            return db.RotaryTables;
        }

        // GET: api/RotaryTables/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRotaryTable(string id)
        {
            RotaryTable rotaryTable = await db.RotaryTables.FindAsync(id);
            if (rotaryTable == null)
            {
                return NotFound();
            }

            return Ok(rotaryTable);
        }

        // PUT: api/RotaryTables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRotaryTable(string id, RotaryTable rotaryTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rotaryTable.TypeID)
            {
                return BadRequest();
            }

            db.Entry(rotaryTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotaryTableExists(id))
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

        // POST: api/RotaryTables
        [HttpPost]
        public async Task<IActionResult> PostRotaryTable(RotaryTable rotaryTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RotaryTables.Add(rotaryTable);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RotaryTableExists(rotaryTable.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rotaryTable.TypeID }, rotaryTable);
        }

        // DELETE: api/RotaryTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRotaryTable(string id)
        {
            RotaryTable rotaryTable = await db.RotaryTables.FindAsync(id);
            if (rotaryTable == null)
            {
                return NotFound();
            }

            db.RotaryTables.Remove(rotaryTable);
            await db.SaveChangesAsync();

            return Ok(rotaryTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RotaryTableExists(string id)
        {
            return db.RotaryTables.Count(e => e.TypeID == id) > 0;
        }
    }
}