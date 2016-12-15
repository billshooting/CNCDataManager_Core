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
    public class PMSrvMotorSizesController : Controller
    {
        private CNCMachineData db;

        public PMSrvMotorSizesController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/PMSrvMotorSizes
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<PMSrvMotorSize> GetPMSrvMotorSizes()
        {
            return db.PMSrvMotorSizes;
        }

        // GET: api/PMSrvMotorSizes/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPMSrvMotorSize(string id)
        {
            PMSrvMotorSize pMSrvMotorSize = await db.PMSrvMotorSizes.FindAsync(id);
            if (pMSrvMotorSize == null)
            {
                return NotFound();
            }

            return Ok(pMSrvMotorSize);
        }

        // PUT: api/PMSrvMotorSizes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPMSrvMotorSize(string id, [FromBody] PMSrvMotorSize pMSrvMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pMSrvMotorSize.TypeID)
            {
                return BadRequest();
            }

            db.Entry(pMSrvMotorSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PMSrvMotorSizeExists(id))
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

        // POST: api/PMSrvMotorSizes
        [HttpPost]
        public async Task<IActionResult> PostPMSrvMotorSize([FromBody] PMSrvMotorSize pMSrvMotorSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PMSrvMotorSizes.Add(pMSrvMotorSize);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PMSrvMotorSizeExists(pMSrvMotorSize.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pMSrvMotorSize.TypeID }, pMSrvMotorSize);
        }

        // DELETE: api/PMSrvMotorSizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePMSrvMotorSize(string id)
        {
            PMSrvMotorSize pMSrvMotorSize = await db.PMSrvMotorSizes.FindAsync(id);
            if (pMSrvMotorSize == null)
            {
                return NotFound();
            }

            db.PMSrvMotorSizes.Remove(pMSrvMotorSize);
            await db.SaveChangesAsync();

            return Ok(pMSrvMotorSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PMSrvMotorSizeExists(string id)
        {
            return db.PMSrvMotorSizes.Count(e => e.TypeID == id) > 0;
        }
    }
}