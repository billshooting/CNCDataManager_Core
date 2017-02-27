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
    public class CablesController : Controller
    {
        private CNCMachineData db;

        public CablesController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/Cables
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<Cables> GetCables()
        {
            return db.Cables;
        }

        // GET: api/Cables/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCables(string id)
        {
            Cables cables = await db.Cables.FindAsync(id);
            if (cables == null)
            {
                return NotFound();
            }

            return Ok(cables);
        }

        // PUT: api/Cables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCables(string id, [FromBody]Cables cables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cables.TypeID)
            {
                return BadRequest();
            }

            db.Entry(cables).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CablesExists(id))
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

        // POST: api/Cables
        [HttpPost]
        public async Task<IActionResult> PostCables([FromBody]Cables cables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cables.Add(cables);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CablesExists(cables.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cables.TypeID }, cables);
        }

        // DELETE: api/Cables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCables(string id)
        {
            Cables cables = await db.Cables.FindAsync(id);
            if (cables == null)
            {
                return NotFound();
            }

            db.Cables.Remove(cables);
            await db.SaveChangesAsync();

            return Ok(cables);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CablesExists(string id)
        {
            return db.Cables.Count(e => e.TypeID == id) > 0;
        }
    }
}