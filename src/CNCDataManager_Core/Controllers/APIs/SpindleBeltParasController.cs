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
    public class SpindleBeltParasController : Controller
    {
        private CNCMachineData db;

        public SpindleBeltParasController(CNCMachineData data)
        {
            db = data;
        }
        // GET: api/SpindleBeltParas
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<SpindleBeltPara> GetSpindleBeltParas()
        {
            return db.SpindleBeltParas;
        }

        // GET: api/SpindleBeltParas/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpindleBeltPara(string id)
        {
            SpindleBeltPara spindleBeltPara = await db.SpindleBeltParas.FindAsync(id);
            if (spindleBeltPara == null)
            {
                return NotFound();
            }

            return Ok(spindleBeltPara);
        }

        // PUT: api/SpindleBeltParas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpindleBeltPara(string id, SpindleBeltPara spindleBeltPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spindleBeltPara.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spindleBeltPara).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpindleBeltParaExists(id))
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

        // POST: api/SpindleBeltParas
        [HttpPost]
        public async Task<IActionResult> PostSpindleBeltPara(SpindleBeltPara spindleBeltPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpindleBeltParas.Add(spindleBeltPara);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpindleBeltParaExists(spindleBeltPara.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spindleBeltPara.TypeID }, spindleBeltPara);
        }

        // DELETE: api/SpindleBeltParas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpindleBeltPara(string id)
        {
            SpindleBeltPara spindleBeltPara = await db.SpindleBeltParas.FindAsync(id);
            if (spindleBeltPara == null)
            {
                return NotFound();
            }

            db.SpindleBeltParas.Remove(spindleBeltPara);
            await db.SaveChangesAsync();

            return Ok(spindleBeltPara);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpindleBeltParaExists(string id)
        {
            return db.SpindleBeltParas.Count(e => e.TypeID == id) > 0;
        }
    }
}