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
    public class CommonCylinWormGearsController : Controller
    {
        private CNCMachineData db;

        public CommonCylinWormGearsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/CommonCylinWormGears
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<CommonCylinWormGear> GetCommonCylinWormGears()
        {
            return db.CommonCylinWormGears;
        }

        // GET: api/CommonCylinWormGears/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommonCylinWormGear(string id)
        {
            CommonCylinWormGear commonCylinWormGear = await db.CommonCylinWormGears.FindAsync(id);
            if (commonCylinWormGear == null)
            {
                return NotFound();
            }

            return Ok(commonCylinWormGear);
        }

        // PUT: api/CommonCylinWormGears/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommonCylinWormGear(string id, [FromBody]CommonCylinWormGear commonCylinWormGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commonCylinWormGear.TypeID)
            {
                return BadRequest();
            }

            db.Entry(commonCylinWormGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommonCylinWormGearExists(id))
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

        // POST: api/CommonCylinWormGears
        [HttpPost]
        public async Task<IActionResult> PostCommonCylinWormGear([FromBody]CommonCylinWormGear commonCylinWormGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommonCylinWormGears.Add(commonCylinWormGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommonCylinWormGearExists(commonCylinWormGear.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = commonCylinWormGear.TypeID }, commonCylinWormGear);
        }

        // DELETE: api/CommonCylinWormGears/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommonCylinWormGear(string id)
        {
            CommonCylinWormGear commonCylinWormGear = await db.CommonCylinWormGears.FindAsync(id);
            if (commonCylinWormGear == null)
            {
                return NotFound();
            }

            db.CommonCylinWormGears.Remove(commonCylinWormGear);
            await db.SaveChangesAsync();

            return Ok(commonCylinWormGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommonCylinWormGearExists(string id)
        {
            return db.CommonCylinWormGears.Count(e => e.TypeID == id) > 0;
        }
    }
}