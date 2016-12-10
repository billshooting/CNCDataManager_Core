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
    public class SrvDriverTransformersController : Controller
    {
        private CNCMachineData db;

        public SrvDriverTransformersController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/SrvDriverTransformers
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<SrvDriverTransformer> GetSrvDriverTransformers()
        {
            return db.SrvDriverTransformers;
        }

        // GET: api/SrvDriverTransformers/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSrvDriverTransformer(string id)
        {
            SrvDriverTransformer srvDriverTransformer = await db.SrvDriverTransformers.FindAsync(id);
            if (srvDriverTransformer == null)
            {
                return NotFound();
            }

            return Ok(srvDriverTransformer);
        }

        // PUT: api/SrvDriverTransformers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSrvDriverTransformer(string id, SrvDriverTransformer srvDriverTransformer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != srvDriverTransformer.TypeID)
            {
                return BadRequest();
            }

            db.Entry(srvDriverTransformer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SrvDriverTransformerExists(id))
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

        // POST: api/SrvDriverTransformers
        [HttpPost]
        public async Task<IActionResult> PostSrvDriverTransformer(SrvDriverTransformer srvDriverTransformer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SrvDriverTransformers.Add(srvDriverTransformer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SrvDriverTransformerExists(srvDriverTransformer.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = srvDriverTransformer.TypeID }, srvDriverTransformer);
        }

        // DELETE: api/SrvDriverTransformers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSrvDriverTransformer(string id)
        {
            SrvDriverTransformer srvDriverTransformer = await db.SrvDriverTransformers.FindAsync(id);
            if (srvDriverTransformer == null)
            {
                return NotFound();
            }

            db.SrvDriverTransformers.Remove(srvDriverTransformer);
            await db.SaveChangesAsync();

            return Ok(srvDriverTransformer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SrvDriverTransformerExists(string id)
        {
            return db.SrvDriverTransformers.Count(e => e.TypeID == id) > 0;
        }
    }
}