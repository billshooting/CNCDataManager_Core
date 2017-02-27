using CNCDataManager.Controllers.Internals;
using CNCDataManager.Models.Simulation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CNCDataManager.Controllers
{
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]/[action]")]
    public class SimulationController: Controller
    {
        private readonly string _webRootPath;

        public SimulationController(IHostingEnvironment host)
        {
            _webRootPath = host.WebRootPath;
        }

        [HttpPost]
        public async Task StartSimulation([FromQuery]string fileID, [FromBody] SimulationPara para)
        {
            //设置模型路径
            PathSettings path = new PathSettings(_webRootPath, para.AxisID, "bill_shooting", fileID);

            Simulator simulator = new Simulator(path);

            //进行模型替换
            await Task.Run(() => 
            {
                simulator.PrepareSimulationModel(para);

                //进行模型编译求解
                simulator.PreprocessCompiler(para.Setting);
                simulator.CreateCompiler();
                simulator.RunCompiler();

                //进行结果转换
                simulator.MsfToTxt();
            });
        }

        [HttpGet]
        public async Task<IActionResult> PollingSimulation([FromQuery]string fileID, [FromQuery]string userName)
        {
            string file = Path.Combine(_webRootPath, "Users", "bill_shooting", fileID, "data", "pmsm.flange_a.tau.txt");
            if (System.IO.File.Exists(file))
            {
                TryCleanSimulationFiles("bill_shooting", fileID);
                return Ok(fileID);
            }
            await Task.Delay(5000);
            if (System.IO.File.Exists(file))
            {
                TryCleanSimulationFiles("bill_shooting", fileID);
                return Ok(fileID);
            }
            await Task.Delay(5000);
            if (System.IO.File.Exists(file))
            {
                TryCleanSimulationFiles("bill_shooting", fileID);
                return Ok(fileID);
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> SimulationResults([FromQuery]string fileID, [FromQuery] string type)
        {
            if (string.IsNullOrEmpty(fileID) || string.IsNullOrEmpty(type) || fileID == "null" || type == "null")
            {
                return NotFound();
            }
            string dataPath = Path.Combine(_webRootPath, "Users", "bill_shooting", fileID, "data");
            string timeFile = Path.Combine(dataPath, "time.txt");
            string dataFile = Path.Combine(dataPath, "a.txt");
            if (type == "a" || type == "v" || type == "X")
            {
                dataFile = Path.Combine(dataPath, type + ".txt");
            }
            else return NotFound();
            string[] times = null;
            string[] data = null;
            await Task.Run(() =>
            {
                times = System.IO.File.ReadAllLines(timeFile, Encoding.UTF8);
                data = System.IO.File.ReadAllLines(dataFile, Encoding.UTF8);
            });
            return Json(new { data = MinifyData(times, data) });
        }

        /// <summary>
        /// 将数据大小按比例缩小
        /// </summary>
        /// <param name="times">横轴时间</param>
        /// <param name="data">某种类型的仿真数据</param>
        /// <param name="minifier">缩小倍数</param>
        /// <returns>缩小后的数组</returns>
        private List<string[]> MinifyData(string[] times, string[] data)
        {
            int minifier = (times.Length / 500);
            if (minifier <= 0) throw new ArgumentException("minifier must greater than 0");
            List<string[]> result = new List<string[]>(data.Length / minifier + 1);
            for(int i = 0; i < data.Length; i += minifier)
            {
                result.Add(new string[2] { times[i], data[i] });
            }
            return result;
        }

        private bool TryCleanSimulationFiles(string userName, string fileID)
        {
            string workPath = Path.Combine(_webRootPath, "Users", userName, fileID);
            string[] deletingFiles = Directory.GetFiles(workPath);
            string complierPath = Path.Combine(workPath, "compiler");
            try
            {
                Directory.Delete(complierPath, true);
                foreach (var f in deletingFiles) System.IO.File.Delete(f);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
