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
    public class NCSystemsController : Controller
    {
        private CNCMachineData db;

        public NCSystemsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/NCSystems
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<NCSystem> GetNCSystems()
        {
            return db.NCSystems;
        }

        // GET: api/NCSystems/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNCSystem(int id)
        {
            NCSystem nCSystem = await db.NCSystems.FindAsync(id);
            if (nCSystem == null)
            {
                return NotFound();
            }

            return Ok(nCSystem);
        }

        // PUT: api/NCSystems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNCSystem(int id, [FromBody] NCSystem nCSystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nCSystem.Id)
            {
                return BadRequest();
            }

            db.Entry(nCSystem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCSystemExists(id))
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

        // POST: api/NCSystems
        [HttpPost]
        public async Task<IActionResult> PostNCSystem([FromBody] NCSystem nCSystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NCSystems.Add(nCSystem);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NCSystemExists(nCSystem.Id))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("DefaultApi", new { id = nCSystem.Id }, nCSystem);
        }

        // DELETE: api/NCSystems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCSystem(int id)
        {
            NCSystem nCSystem = await db.NCSystems.FindAsync(id);
            if (nCSystem == null)
            {
                return NotFound();
            }

            db.NCSystems.Remove(nCSystem);
            await db.SaveChangesAsync();

            return Ok(nCSystem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NCSystemExists(int id)
        {
            return db.NCSystems.Count(e => e.Id == id) > 0;
        }
    }
}