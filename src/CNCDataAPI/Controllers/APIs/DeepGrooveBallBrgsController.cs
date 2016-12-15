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
    public class DeepGrooveBallBrgsController : Controller
    {
        private CNCMachineData db;

        public DeepGrooveBallBrgsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/DeepGrooveBallBrgs
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<DeepGrooveBallBrg> GetDeepGrooveBallBearings()
        {
            return db.DeepGrooveBallBearings;
        }

        // GET: api/DeepGrooveBallBrgs/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeepGrooveBallBrg(string id)
        {
            DeepGrooveBallBrg deepGrooveBallBrg = await db.DeepGrooveBallBearings.FindAsync(id);
            if (deepGrooveBallBrg == null)
            {
                return NotFound();
            }

            return Ok(deepGrooveBallBrg);
        }

        // PUT: api/DeepGrooveBallBrgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeepGrooveBallBrg(string id, [FromBody] DeepGrooveBallBrg deepGrooveBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deepGrooveBallBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(deepGrooveBallBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeepGrooveBallBrgExists(id))
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

        // POST: api/DeepGrooveBallBrgs
        [HttpPost]
        public async Task<IActionResult> PostDeepGrooveBallBrg([FromBody] DeepGrooveBallBrg deepGrooveBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeepGrooveBallBearings.Add(deepGrooveBallBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeepGrooveBallBrgExists(deepGrooveBallBrg.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = deepGrooveBallBrg.TypeID }, deepGrooveBallBrg);
        }

        // DELETE: api/DeepGrooveBallBrgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeepGrooveBallBrg(string id)
        {
            DeepGrooveBallBrg deepGrooveBallBrg = await db.DeepGrooveBallBearings.FindAsync(id);
            if (deepGrooveBallBrg == null)
            {
                return NotFound();
            }

            db.DeepGrooveBallBearings.Remove(deepGrooveBallBrg);
            await db.SaveChangesAsync();

            return Ok(deepGrooveBallBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeepGrooveBallBrgExists(string id)
        {
            return db.DeepGrooveBallBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}