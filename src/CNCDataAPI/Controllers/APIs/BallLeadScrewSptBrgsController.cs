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
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    [ApiAuthorize(Policy = nameof(AuthorizationLevel.ResourceOwner))]
    public class BallLeadScrewSptBrgsController : Controller
    {
        private CNCMachineData db;

        public BallLeadScrewSptBrgsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/BallLeadScrewSptBrgs
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<BallLeadScrewSptBrg> GetBallLeadScrewSptBearings()
        {
            return db.BallLeadScrewSptBearings;
        }

        // GET: api/BallLeadScrewSptBrgs/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBallLeadScrewSptBrg(string id)
        {
            BallLeadScrewSptBrg ballLeadScrewSptBrg = await db.BallLeadScrewSptBearings.FindAsync(id);
            if (ballLeadScrewSptBrg == null)
            {
                return NotFound();
            }

            return Ok(ballLeadScrewSptBrg);
        }

        // PUT: api/BallLeadScrewSptBrgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBallLeadScrewSptBrg(string id, [FromBody]BallLeadScrewSptBrg ballLeadScrewSptBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ballLeadScrewSptBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(ballLeadScrewSptBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BallLeadScrewSptBrgExists(id))
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

        // POST: api/BallLeadScrewSptBrgs
        [HttpPost]
        public async Task<IActionResult> PostBallLeadScrewSptBrg([FromBody]BallLeadScrewSptBrg ballLeadScrewSptBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BallLeadScrewSptBearings.Add(ballLeadScrewSptBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BallLeadScrewSptBrgExists(ballLeadScrewSptBrg.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ballLeadScrewSptBrg.TypeID }, ballLeadScrewSptBrg);
        }

        // DELETE: api/BallLeadScrewSptBrgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBallLeadScrewSptBrg(string id)
        {
            BallLeadScrewSptBrg ballLeadScrewSptBrg = await db.BallLeadScrewSptBearings.FindAsync(id);
            if (ballLeadScrewSptBrg == null)
            {
                return NotFound();
            }

            db.BallLeadScrewSptBearings.Remove(ballLeadScrewSptBrg);
            await db.SaveChangesAsync();

            return Ok(ballLeadScrewSptBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BallLeadScrewSptBrgExists(string id)
        {
            return db.BallLeadScrewSptBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}