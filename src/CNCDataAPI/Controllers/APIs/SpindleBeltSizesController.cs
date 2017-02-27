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
    [Route("api/cncdata/[controller]")]
    public class SpindleBeltSizesController : Controller
    {
        private CNCMachineData db;

        public SpindleBeltSizesController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/SpindleBeltSizes
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<SpindleBeltSize> GetSpindleBeltSizes()
        {
            return db.SpindleBeltSizes;
        }

        // GET: api/SpindleBeltSizes/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpindleBeltSize(string id)
        {
            SpindleBeltSize spindleBeltSize = await db.SpindleBeltSizes.FindAsync(id);
            if (spindleBeltSize == null)
            {
                return NotFound();
            }

            return Ok(spindleBeltSize);
        }

        // PUT: api/SpindleBeltSizes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpindleBeltSize(string id, [FromBody] SpindleBeltSize spindleBeltSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spindleBeltSize.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spindleBeltSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpindleBeltSizeExists(id))
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

        // POST: api/SpindleBeltSizes
        [HttpPost]
        public async Task<IActionResult> PostSpindleBeltSize([FromBody] SpindleBeltSize spindleBeltSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpindleBeltSizes.Add(spindleBeltSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpindleBeltSizeExists(spindleBeltSize.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spindleBeltSize.TypeID }, spindleBeltSize);
        }

        // DELETE: api/SpindleBeltSizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpindleBeltSize(string id)
        {
            SpindleBeltSize spindleBeltSize = await db.SpindleBeltSizes.FindAsync(id);
            if (spindleBeltSize == null)
            {
                return NotFound();
            }

            db.SpindleBeltSizes.Remove(spindleBeltSize);
            await db.SaveChangesAsync();

            return Ok(spindleBeltSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpindleBeltSizeExists(string id)
        {
            return db.SpindleBeltSizes.Count(e => e.TypeID == id) > 0;
        }
    }
}