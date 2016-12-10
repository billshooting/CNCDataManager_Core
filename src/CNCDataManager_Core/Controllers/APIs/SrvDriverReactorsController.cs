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
    public class SrvDriverReactorsController : Controller
    {
        private CNCMachineData db;

        public SrvDriverReactorsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/SrvDriverReactors
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<SrvDriverReactor> GetSrvDriverReactors()
        {
            return db.SrvDriverReactors;
        }

        // GET: api/SrvDriverReactors/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSrvDriverReactor(string id)
        {
            SrvDriverReactor srvDriverReactor = await db.SrvDriverReactors.FindAsync(id);
            if (srvDriverReactor == null)
            {
                return NotFound();
            }

            return Ok(srvDriverReactor);
        }

        // PUT: api/SrvDriverReactors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSrvDriverReactor(string id, SrvDriverReactor srvDriverReactor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != srvDriverReactor.TypeID)
            {
                return BadRequest();
            }

            db.Entry(srvDriverReactor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SrvDriverReactorExists(id))
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

        // POST: api/SrvDriverReactors
        [HttpPost]
        public async Task<IActionResult> PostSrvDriverReactor(SrvDriverReactor srvDriverReactor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SrvDriverReactors.Add(srvDriverReactor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SrvDriverReactorExists(srvDriverReactor.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = srvDriverReactor.TypeID }, srvDriverReactor);
        }

        // DELETE: api/SrvDriverReactors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSrvDriverReactor(string id)
        {
            SrvDriverReactor srvDriverReactor = await db.SrvDriverReactors.FindAsync(id);
            if (srvDriverReactor == null)
            {
                return NotFound();
            }

            db.SrvDriverReactors.Remove(srvDriverReactor);
            await db.SaveChangesAsync();

            return Ok(srvDriverReactor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SrvDriverReactorExists(string id)
        {
            return db.SrvDriverReactors.Count(e => e.TypeID == id) > 0;
        }
    }
}