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
    //[ApiAuthorize]
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    [ApiAuthorize(Policy = nameof(AuthorizationLevel.ResourceOwner))]
    public class AlignRollerBrgsController : Controller
    {
        private CNCMachineData db;

        public AlignRollerBrgsController(CNCMachineData database)
        {
            db = database;
        }

        // GET: api/AlignRollerBrgs
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<AlignRollerBrg> GetAlignRollerBearings()
        {
            return db.AlignRollerBearings;
        }

        // GET: api/AlignRollerBrgs/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlignRollerBrg(string id)
        {
            AlignRollerBrg alignRollerBrg = await db.AlignRollerBearings.FindAsync(id);
            if (alignRollerBrg == null)
            {
                return NotFound();
            }

            return Ok(alignRollerBrg);
        }

        // PUT: api/AlignRollerBrgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlignRollerBrg(string id, [FromBody]AlignRollerBrg alignRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alignRollerBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(alignRollerBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlignRollerBrgExists(id))
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

        // POST: api/AlignRollerBrgs
        [HttpPost]
        public async Task<IActionResult> PostAlignRollerBrg([FromBody]AlignRollerBrg alignRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AlignRollerBearings.Add(alignRollerBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlignRollerBrgExists(alignRollerBrg.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = alignRollerBrg.TypeID }, alignRollerBrg);
        }

        // DELETE: api/AlignRollerBrgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlignRollerBrg(string id)
        {
            AlignRollerBrg alignRollerBrg = await db.AlignRollerBearings.FindAsync(id);
            if (alignRollerBrg == null)
            {
                return NotFound();
            }

            db.AlignRollerBearings.Remove(alignRollerBrg);
            await db.SaveChangesAsync();

            return Ok(alignRollerBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlignRollerBrgExists(string id)
        {
            return db.AlignRollerBearings.Count(e => e.TypeID == id) > 0;
        }

        public void SaveChanges()
        {
             db.SaveChanges();
        }
    }
}