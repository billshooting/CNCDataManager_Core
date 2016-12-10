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
    public class StepMotorParasController : Controller
    {
        private CNCMachineData db;

        public StepMotorParasController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/StepMotorParas
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<StepMotorPara> GetStepMotorParas()
        {
            return db.StepMotorParas;
        }

        // GET: api/StepMotorParas/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStepMotorPara(string id)
        {
            StepMotorPara stepMotorPara = await db.StepMotorParas.FindAsync(id);
            if (stepMotorPara == null)
            {
                return NotFound();
            }

            return Ok(stepMotorPara);
        }

        // PUT: api/StepMotorParas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStepMotorPara(string id, StepMotorPara stepMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stepMotorPara.TypeID)
            {
                return BadRequest();
            }

            db.Entry(stepMotorPara).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepMotorParaExists(id))
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

        // POST: api/StepMotorParas
        [HttpPost]
        public async Task<IActionResult> PostStepMotorPara(StepMotorPara stepMotorPara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StepMotorParas.Add(stepMotorPara);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StepMotorParaExists(stepMotorPara.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = stepMotorPara.TypeID }, stepMotorPara);
        }

        // DELETE: api/StepMotorParas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStepMotorPara(string id)
        {
            StepMotorPara stepMotorPara = await db.StepMotorParas.FindAsync(id);
            if (stepMotorPara == null)
            {
                return NotFound();
            }

            db.StepMotorParas.Remove(stepMotorPara);
            await db.SaveChangesAsync();

            return Ok(stepMotorPara);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StepMotorParaExists(string id)
        {
            return db.StepMotorParas.Count(e => e.TypeID == id) > 0;
        }
    }
}