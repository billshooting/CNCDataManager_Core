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
    public class ElasticSlvPinCoupsController : Controller
    {
        private CNCMachineData db;

        public ElasticSlvPinCoupsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/ElasticSlvPinCoups
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<ElasticSlvPinCoup> GetElasticSlvPinCouplings()
        {
            return db.ElasticSlvPinCouplings;
        }

        // GET: api/ElasticSlvPinCoups/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetElasticSlvPinCoup(string id)
        {
            ElasticSlvPinCoup elasticSlvPinCoup = await db.ElasticSlvPinCouplings.FindAsync(id);
            if (elasticSlvPinCoup == null)
            {
                return NotFound();
            }

            return Ok(elasticSlvPinCoup);
        }

        // PUT: api/ElasticSlvPinCoups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElasticSlvPinCoup(string id, [FromBody] ElasticSlvPinCoup elasticSlvPinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elasticSlvPinCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(elasticSlvPinCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElasticSlvPinCoupExists(id))
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

        // POST: api/ElasticSlvPinCoups
        [HttpPost]
        public async Task<IActionResult> PostElasticSlvPinCoup([FromBody] ElasticSlvPinCoup elasticSlvPinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ElasticSlvPinCouplings.Add(elasticSlvPinCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ElasticSlvPinCoupExists(elasticSlvPinCoup.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = elasticSlvPinCoup.TypeID }, elasticSlvPinCoup);
        }

        // DELETE: api/ElasticSlvPinCoups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElasticSlvPinCoup(string id)
        {
            ElasticSlvPinCoup elasticSlvPinCoup = await db.ElasticSlvPinCouplings.FindAsync(id);
            if (elasticSlvPinCoup == null)
            {
                return NotFound();
            }

            db.ElasticSlvPinCouplings.Remove(elasticSlvPinCoup);
            await db.SaveChangesAsync();

            return Ok(elasticSlvPinCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElasticSlvPinCoupExists(string id)
        {
            return db.ElasticSlvPinCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}