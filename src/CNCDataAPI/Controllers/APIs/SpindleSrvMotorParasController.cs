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
    [Route("api/cncdata/[controller]")]
    public class SpindleSrvMotorParasController : Controller
    {
        private CNCMachineData db;

        public SpindleSrvMotorParasController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/SpindleSrvMotorParas
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<SpindleSrvMotorPara> GetSpindleSrvMotorParas()
        {
            return db.SpindleSrvMotorParas;
        }

        // GET: api/SpindleSrvMotorParas/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpindleSrvMotorPara(string id)
        {
            SpindleSrvMotorPara spindleSrvMotorPara = await db.SpindleSrvMotorParas.FindAsync(id);
            if (spindleSrvMotorPara == null)
            {
                return NotFound();
            }

            return Ok(spindleSrvMotorPara);
        }

        // PUT: api/SpindleSrvMotorParas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpindleSrvMotorPara(string id, [FromBody] SpindleSrvMotorPara spindleSrvMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spindleSrvMotorPara.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spindleSrvMotorPara).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpindleSrvMotorParaExists(id))
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

        // POST: api/SpindleSrvMotorParas
        [HttpPost]
        public async Task<IActionResult> PostSpindleSrvMotorPara([FromBody]SpindleSrvMotorPara spindleSrvMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpindleSrvMotorParas.Add(spindleSrvMotorPara);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpindleSrvMotorParaExists(spindleSrvMotorPara.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spindleSrvMotorPara.TypeID }, spindleSrvMotorPara);
        }

        // DELETE: api/SpindleSrvMotorParas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpindleSrvMotorPara(string id)
        {
            SpindleSrvMotorPara spindleSrvMotorPara = await db.SpindleSrvMotorParas.FindAsync(id);
            if (spindleSrvMotorPara == null)
            {
                return NotFound();
            }

            db.SpindleSrvMotorParas.Remove(spindleSrvMotorPara);
            await db.SaveChangesAsync();

            return Ok(spindleSrvMotorPara);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpindleSrvMotorParaExists(string id)
        {
            return db.SpindleSrvMotorParas.Count(e => e.TypeID == id) > 0;
        }
    }
}