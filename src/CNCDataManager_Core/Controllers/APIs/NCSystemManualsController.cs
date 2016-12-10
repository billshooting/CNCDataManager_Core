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
    public class NCSystemManualsController : Controller
    {
        private CNCMachineData db;

        public NCSystemManualsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/NCSystemManuals
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<NCSystemManual> GetNCSystemManuals()
        {
            return db.NCSystemManuals;
        }

        // GET: api/NCSystemManuals/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNCSystemManual(string id)
        {
            NCSystemManual nCSystemManual = await db.NCSystemManuals.FindAsync(id);
            if (nCSystemManual == null)
            {
                return NotFound();
            }

            return Ok(nCSystemManual);
        }

        // PUT: api/NCSystemManuals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNCSystemManual(string id, NCSystemManual nCSystemManual)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nCSystemManual.TypeID)
            {
                return BadRequest();
            }

            db.Entry(nCSystemManual).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCSystemManualExists(id))
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

        // POST: api/NCSystemManuals
        [HttpPost]
        public async Task<IActionResult> PostNCSystemManual(NCSystemManual nCSystemManual)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NCSystemManuals.Add(nCSystemManual);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NCSystemManualExists(nCSystemManual.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nCSystemManual.TypeID }, nCSystemManual);
        }

        // DELETE: api/NCSystemManuals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCSystemManual(string id)
        {
            NCSystemManual nCSystemManual = await db.NCSystemManuals.FindAsync(id);
            if (nCSystemManual == null)
            {
                return NotFound();
            }

            db.NCSystemManuals.Remove(nCSystemManual);
            await db.SaveChangesAsync();

            return Ok(nCSystemManual);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NCSystemManualExists(string id)
        {
            return db.NCSystemManuals.Count(e => e.TypeID == id) > 0;
        }
    }
}