using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using CNCDataManager.Models.APIs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using CNCDataManager.Controllers.Internals;

namespace CNCDataManager.Controllers.APIs
{
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    [ApiAuthorize(Policy = nameof(AuthorizationLevel.ResourceOwner))]
    public class UploadFilesController : Controller
    {
        private CNCMachineData db;

        public UploadFilesController(CNCMachineData data)
        {
            db = data;
        }
        // GET: api/UploadFile
        [HttpGet]
        public void Get()
        {
        }

        // POST: api/UploadFile
        [HttpPost]
        //public async Task<IActionResult> Post()
        //{
        //    string name = HttpContext.Current.Request["name"];
        //    string description = HttpContext.Current.Request["description"];
        //    var file = HttpContext.Current.Request.Files.Count > 0 ?
        //        HttpContext.Current.Request.Files[0] : null;
        //    if (file == null) return Json(new UploadResult() { IsUploadedSuccessful = false, FileUrl = string.Empty, FailReason = "Uploaded Nothing!" });
        //    string filename = name + Path.GetExtension(file.FileName);
        //    var fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/App/images/Upload"), filename);
        //    try
        //    {
        //        await Task.Run(() => file.SaveAs(fullPath));
        //        string returnUrl = Path.Combine("../App/images/Upload/", filename);
        //        await AddToDB(db, name, description, returnUrl);
        //        UploadResult result = new UploadResult() { IsUploadedSuccessful = true, FileUrl = returnUrl };
        //        return Json(result);
        //    }
        //    catch (IOException ex)
        //    {
        //        UploadResult result = new UploadResult() { IsUploadedSuccessful = false, FileUrl = string.Empty, FailReason = ex.Message };
        //        return Json(result);
        //    }
        //}

        private async Task AddToDB(CNCMachineData db, string name, string desc, string url)
        {
            CNCMachineType tt = new CNCMachineType() { MachineType = name, MainType = desc, ThumbNailUrl = url };
            db.CNCMachineTypes.Add(tt);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
            }
        }

        // PUT: api/UploadFile/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UploadFile/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private class UploadResult
        {
            public bool IsUploadedSuccessful { get; set; }
            public string FileUrl { get; set; }
            public string FailReason { get; set; }
        }
    }
}
