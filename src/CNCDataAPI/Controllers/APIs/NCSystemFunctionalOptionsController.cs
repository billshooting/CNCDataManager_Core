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
    public class NCSystemFunctionalOptionsController : Controller
    {
        private CNCMachineData db;

        public NCSystemFunctionalOptionsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/NCSystemFunctionalOptions
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<NCSystemFunctionalOptions> GetNCSystemFunctionalOptions()
        {
            return db.NCSystemFunctionalOptions;
        }

        // GET: api/NCSystemFunctionalOptions/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNCSystemFunctionalOption(string id)
        {
            NCSystemFunctionalOptions nCSystemFunctionalOptions = await db.NCSystemFunctionalOptions.FindAsync(id);
            if (nCSystemFunctionalOptions == null)
            {
                return NotFound();
            }

            return Ok(nCSystemFunctionalOptions);
        }

        // PUT: api/NCSystemFunctionalOptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNCSystemFunctionalOption(string id, [FromBody] NCSystemFunctionalOptions nCSystemFunctionalOptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nCSystemFunctionalOptions.TypeID)
            {
                return BadRequest();
            }

            db.Entry(nCSystemFunctionalOptions).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCSystemFunctionalOptionsExists(id))
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

        // POST: api/NCSystemFunctionalOptions
        [HttpPost]
        public async Task<IActionResult> PostNCSystemFunctionalOption([FromBody] NCSystemFunctionalOptions nCSystemFunctionalOptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NCSystemFunctionalOptions.Add(nCSystemFunctionalOptions);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NCSystemFunctionalOptionsExists(nCSystemFunctionalOptions.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nCSystemFunctionalOptions.TypeID }, nCSystemFunctionalOptions);
        }

        // DELETE: api/NCSystemFunctionalOptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCSystemFunctionalOption(string id)
        {
            NCSystemFunctionalOptions nCSystemFunctionalOptions = await db.NCSystemFunctionalOptions.FindAsync(id);
            if (nCSystemFunctionalOptions == null)
            {
                return NotFound();
            }

            db.NCSystemFunctionalOptions.Remove(nCSystemFunctionalOptions);
            await db.SaveChangesAsync();

            return Ok(nCSystemFunctionalOptions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NCSystemFunctionalOptionsExists(string id)
        {
            return db.NCSystemFunctionalOptions.Count(e => e.TypeID == id) > 0;
        }
    }
}