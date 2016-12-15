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
    public class XTaperedRollerBrgsController : Controller
    {
        private CNCMachineData db;

        public XTaperedRollerBrgsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/XTaperedRollerBrgs
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<XTaperedRollerBrg> GetXTaperedRollerBearings()
        {
            return db.XTaperedRollerBearings;
        }

        // GET: api/XTaperedRollerBrgs/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetXTaperedRollerBrg(string id)
        {
            XTaperedRollerBrg xTaperedRollerBrg = await db.XTaperedRollerBearings.FindAsync(id);
            if (xTaperedRollerBrg == null)
            {
                return NotFound();
            }

            return Ok(xTaperedRollerBrg);
        }

        // PUT: api/XTaperedRollerBrgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutXTaperedRollerBrg(string id, [FromBody] XTaperedRollerBrg xTaperedRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != xTaperedRollerBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(xTaperedRollerBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XTaperedRollerBrgExists(id))
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

        // POST: api/XTaperedRollerBrgs
        [HttpPost]
        public async Task<IActionResult> PostXTaperedRollerBrg([FromBody]XTaperedRollerBrg xTaperedRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.XTaperedRollerBearings.Add(xTaperedRollerBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (XTaperedRollerBrgExists(xTaperedRollerBrg.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = xTaperedRollerBrg.TypeID }, xTaperedRollerBrg);
        }

        // DELETE: api/XTaperedRollerBrgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteXTaperedRollerBrg(string id)
        {
            XTaperedRollerBrg xTaperedRollerBrg = await db.XTaperedRollerBearings.FindAsync(id);
            if (xTaperedRollerBrg == null)
            {
                return NotFound();
            }

            db.XTaperedRollerBearings.Remove(xTaperedRollerBrg);
            await db.SaveChangesAsync();

            return Ok(xTaperedRollerBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool XTaperedRollerBrgExists(string id)
        {
            return db.XTaperedRollerBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}