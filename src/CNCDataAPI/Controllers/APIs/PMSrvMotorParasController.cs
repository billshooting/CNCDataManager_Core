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
    public class PMSrvMotorParasController : Controller
    {
        private CNCMachineData db;

        public PMSrvMotorParasController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/PMSrvMotorParas
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<PMSrvMotorPara> GetPMSrvMotorParas()
        {
            return db.PMSrvMotorParas;
        }

        // GET: api/PMSrvMotorParas/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPMSrvMotorPara(string id)
        {
            PMSrvMotorPara pMSrvMotorPara = await db.PMSrvMotorParas.FindAsync(id);
            if (pMSrvMotorPara == null)
            {
                return NotFound();
            }

            return Ok(pMSrvMotorPara);
        }

        // PUT: api/PMSrvMotorParas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPMSrvMotorPara(string id, [FromBody] PMSrvMotorPara pMSrvMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pMSrvMotorPara.TypeID)
            {
                return BadRequest();
            }

            db.Entry(pMSrvMotorPara).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PMSrvMotorParaExists(id))
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

        // POST: api/PMSrvMotorParas
        [HttpPost]
        public async Task<IActionResult> PostPMSrvMotorPara([FromBody]PMSrvMotorPara pMSrvMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PMSrvMotorParas.Add(pMSrvMotorPara);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PMSrvMotorParaExists(pMSrvMotorPara.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pMSrvMotorPara.TypeID }, pMSrvMotorPara);
        }

        // DELETE: api/PMSrvMotorParas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePMSrvMotorPara(string id)
        {
            PMSrvMotorPara pMSrvMotorPara = await db.PMSrvMotorParas.FindAsync(id);
            if (pMSrvMotorPara == null)
            {
                return NotFound();
            }

            db.PMSrvMotorParas.Remove(pMSrvMotorPara);
            await db.SaveChangesAsync();

            return Ok(pMSrvMotorPara);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PMSrvMotorParaExists(string id)
        {
            return db.PMSrvMotorParas.Count(e => e.TypeID == id) > 0;
        }
    }
}