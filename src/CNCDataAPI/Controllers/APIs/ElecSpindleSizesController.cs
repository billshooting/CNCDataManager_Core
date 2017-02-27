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
    public class ElecSpindleSizesController : Controller
    {
        private CNCMachineData db;

        public ElecSpindleSizesController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/ElecSpindleSizes
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<ElecSpindleSize> GetElecSpindleSizes()
        {
            return db.ElecSpindleSizes;
        }

        // GET: api/ElecSpindleSizes/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetElecSpindleSize(string id)
        {
            ElecSpindleSize elecSpindleSize = await db.ElecSpindleSizes.FindAsync(id);
            if (elecSpindleSize == null)
            {
                return NotFound();
            }

            return Ok(elecSpindleSize);
        }

        // PUT: api/ElecSpindleSizes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElecSpindleSize(string id, [FromBody] ElecSpindleSize elecSpindleSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elecSpindleSize.TypeID)
            {
                return BadRequest();
            }

            db.Entry(elecSpindleSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElecSpindleSizeExists(id))
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

        // POST: api/ElecSpindleSizes
        [HttpPost]
        public async Task<IActionResult> PostElecSpindleSize([FromBody] ElecSpindleSize elecSpindleSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ElecSpindleSizes.Add(elecSpindleSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ElecSpindleSizeExists(elecSpindleSize.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = elecSpindleSize.TypeID }, elecSpindleSize);
        }

        // DELETE: api/ElecSpindleSizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElecSpindleSize(string id)
        {
            ElecSpindleSize elecSpindleSize = await db.ElecSpindleSizes.FindAsync(id);
            if (elecSpindleSize == null)
            {
                return NotFound();
            }

            db.ElecSpindleSizes.Remove(elecSpindleSize);
            await db.SaveChangesAsync();

            return Ok(elecSpindleSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElecSpindleSizeExists(string id)
        {
            return db.ElecSpindleSizes.Count(e => e.TypeID == id) > 0;
        }
    }
}