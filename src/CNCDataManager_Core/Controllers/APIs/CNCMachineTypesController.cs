using CNCDataManager.Models.APIs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.IO;

namespace CNCDataManager.Controllers.APIs
{
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    public class CNCMachineTypesController : Controller
    {
        private CNCMachineData db;

        public CNCMachineTypesController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/CNCMachineTypes
        [HttpGet]
        public IQueryable<CNCMachineType> GetCNCMachineTypes()
        {
            return db.CNCMachineTypes;
        }

        // GET: api/CNCMachineTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCNCMachineType(int id)
        {
            CNCMachineType cNCMachineType = await db.CNCMachineTypes.FindAsync(id);
            if (cNCMachineType == null)
            {
                return NotFound();
            }

            return Ok(cNCMachineType);
        }

        // PUT: api/CNCMachineTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCNCMachineType(int id, CNCMachineType cNCMachineType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cNCMachineType.ID)
            {
                return BadRequest();
            }

            db.Entry(cNCMachineType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CNCMachineTypeExists(id))
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

        // POST: api/CNCMachineTypes
        //public async Task<IActionResult> PostCNCMachineType()
        //{
        //    string machineType = HttpContext.Current.Request["machineType"];
        //    string mainType = HttpContext.Current.Request["mainType"];
        //    string detailType = HttpContext.Current.Request["detailType"];
        //    var file = HttpContext.Current.Request.Files.Count > 0 ?
        //        HttpContext.Current.Request.Files[0] : null;
        //    if (file == null) return BadRequest("Upload Nothing!");
        //    string filename = machineType + Path.GetExtension(file.FileName);
        //    var fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/App/images/Upload"), filename);
        //    try
        //    {
        //        await Task.Run(() => file.SaveAs(fullPath));
        //        string returnUrl = Path.Combine("../App/images/Upload/", filename);
        //        return await AddToDB(db, machineType, mainType, detailType, returnUrl);
        //    }
        //    catch (IOException ex)
        //    {
        //        UploadResult result = new UploadResult() { IsUploadedSuccessful = false, FileUrl = string.Empty, FailReason = ex.Message };
        //        return Json(result);
        //    }
        //    //return CreatedAtRoute("DefaultApi", new { id = cNCMachineType.ID }, cNCMachineType);
        //}

        private async Task<IActionResult> AddToDB(CNCMachineData db, string machineType, string mainType, string detailType, string url)
        {
            CNCMachineType cmt = new CNCMachineType()
            {               
                MachineType = machineType,
                MainType = mainType,
                DetailType = detailType,
                ThumbNailUrl = url
            };
            db.CNCMachineTypes.Add(cmt);
            await db.SaveChangesAsync();
            int id = db.CNCMachineTypes.Local.Last().ID;
            return CreatedAtRoute("DefaultApi", id, cmt);
        }

        // DELETE: api/CNCMachineTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCNCMachineType(int id)
        {
            CNCMachineType cNCMachineType = await db.CNCMachineTypes.FindAsync(id);
            if (cNCMachineType == null)
            {
                return NotFound();
            }

            db.CNCMachineTypes.Remove(cNCMachineType);
            await db.SaveChangesAsync();

            return Ok(cNCMachineType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CNCMachineTypeExists(int id)
        {
            return db.CNCMachineTypes.Count(e => e.ID == id) > 0;
        }

        private class UploadResult
        {
            public bool IsUploadedSuccessful { get; set; }
            public string FileUrl { get; set; }
            public string FailReason { get; set; }
        }
    }
}