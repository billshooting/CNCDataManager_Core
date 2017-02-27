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
    public class LineRollingGuidesController : Controller
    {
        private CNCMachineData db;

        public LineRollingGuidesController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/LineRollingGuides
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<LineRollingGuide> GetLineRollingGuides()
        {
            return db.LineRollingGuides;
        }

        // GET: api/LineRollingGuides/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLineRollingGuide(string id)
        {
            LineRollingGuide lineRollingGuide = await db.LineRollingGuides.FindAsync(id);
            if (lineRollingGuide == null)
            {
                return NotFound();
            }

            return Ok(lineRollingGuide);
        }

        // PUT: api/LineRollingGuides/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLineRollingGuide(string id, [FromBody] LineRollingGuide lineRollingGuide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineRollingGuide.TypeID)
            {
                return BadRequest();
            }

            db.Entry(lineRollingGuide).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineRollingGuideExists(id))
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

        // POST: api/LineRollingGuides
        [HttpPost]
        public async Task<IActionResult> PostLineRollingGuide([FromBody] LineRollingGuide lineRollingGuide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LineRollingGuides.Add(lineRollingGuide);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LineRollingGuideExists(lineRollingGuide.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lineRollingGuide.TypeID }, lineRollingGuide);
        }

        // DELETE: api/LineRollingGuides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLineRollingGuide(string id)
        {
            LineRollingGuide lineRollingGuide = await db.LineRollingGuides.FindAsync(id);
            if (lineRollingGuide == null)
            {
                return NotFound();
            }

            db.LineRollingGuides.Remove(lineRollingGuide);
            await db.SaveChangesAsync();

            return Ok(lineRollingGuide);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineRollingGuideExists(string id)
        {
            return db.LineRollingGuides.Count(e => e.TypeID == id) > 0;
        }
    }
}