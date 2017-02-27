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
    public class NeedleRollerThrustRollerBrgsController : Controller
    {
        private CNCMachineData db;

        public NeedleRollerThrustRollerBrgsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/NeedleRollerThrustRollerBrgs
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<NeedleRollerThrustRollerBrg> GetNeedleRollerThrustRollerBearings()
        {
            return db.NeedleRollerThrustRollerBearings;
        }

        // GET: api/NeedleRollerThrustRollerBrgs/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNeedleRollerThrustRollerBrg(string id)
        {
            NeedleRollerThrustRollerBrg needleRollerThrustRollerBrg = await db.NeedleRollerThrustRollerBearings.FindAsync(id);
            if (needleRollerThrustRollerBrg == null)
            {
                return NotFound();
            }

            return Ok(needleRollerThrustRollerBrg);
        }

        // PUT: api/NeedleRollerThrustRollerBrgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNeedleRollerThrustRollerBrg(string id, [FromBody] NeedleRollerThrustRollerBrg needleRollerThrustRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != needleRollerThrustRollerBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(needleRollerThrustRollerBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NeedleRollerThrustRollerBrgExists(id))
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

        // POST: api/NeedleRollerThrustRollerBrgs
        [HttpPost]
        public async Task<IActionResult> PostNeedleRollerThrustRollerBrg([FromBody] NeedleRollerThrustRollerBrg needleRollerThrustRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NeedleRollerThrustRollerBearings.Add(needleRollerThrustRollerBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NeedleRollerThrustRollerBrgExists(needleRollerThrustRollerBrg.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = needleRollerThrustRollerBrg.TypeID }, needleRollerThrustRollerBrg);
        }

        // DELETE: api/NeedleRollerThrustRollerBrgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNeedleRollerThrustRollerBrg(string id)
        {
            NeedleRollerThrustRollerBrg needleRollerThrustRollerBrg = await db.NeedleRollerThrustRollerBearings.FindAsync(id);
            if (needleRollerThrustRollerBrg == null)
            {
                return NotFound();
            }

            db.NeedleRollerThrustRollerBearings.Remove(needleRollerThrustRollerBrg);
            await db.SaveChangesAsync();

            return Ok(needleRollerThrustRollerBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NeedleRollerThrustRollerBrgExists(string id)
        {
            return db.NeedleRollerThrustRollerBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}