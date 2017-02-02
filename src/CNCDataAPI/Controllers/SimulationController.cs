using System;
using System.Collections.Generic;
using CNCDataManager.Models;
using CNCDataManager.Models.Simulation;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using CNCDataManager.Controllers.Internals;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Cors;
using System.Threading.Tasks;

namespace CNCDataManager.Controllers
{
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]/[action]")]
    public class SimulationController
    {
        private readonly string _webRootPath;

        public SimulationController(IHostingEnvironment host)
        {
            _webRootPath = host.WebRootPath;
        }

        [HttpGet]
        public string Index()
        {
            return "test";
        }

        [HttpPost]
        public string startSimulation([FromBody] SimulationPara para)
        {
            //设置模型路径
            PathSettings path = new PathSettings(_webRootPath, para.AxisID);

            Simulator simulator = new Simulator(path);

            //进行模型替换
            //await Task.Run(() => 
            //{
                simulator.PrepareSimulationModel(para);

                //进行模型编译求解
                simulator.PreprocessCompiler(para.Setting);
                simulator.CreateCompiler();
                simulator.RunCompiler();

                //进行结果转换
                simulator.MsfToTxt();
            //});


            //返回独一无二的个人信息标识，后序通过此标识获取仿真结果
            return path.TempId;
        }
    }
}
