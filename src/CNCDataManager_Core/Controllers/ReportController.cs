using System;
using System.Collections.Generic;
using CNCDataManager.Models;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using CNCDataManager.Controllers.Internals;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;

namespace CNCDataManager.Controllers
{
    public class ReportController : Controller
    {
        private string _webRootPath; 

        public ReportController(IHostingEnvironment host)
        {
            _webRootPath = host.WebRootPath;
        }

        // GET: Report
        [HttpPost]
        public ActionResult Index (SelectionResult selectionResult)
        {
            ReportTemplateResult result = ToReportTemplate(selectionResult);
            string shortName = DateTime.Now.ToString("yyyyMMdd-hhmmss");
            string filename = MapPath("temp", shortName + ".docx");
            result.Filename = shortName;
            using (DocxGenerator gen = new DocxGenerator(MapPath("others", @"选型简表结果.docx")))
            {
                gen.AddMachinePicture(MapPath(result.MachinePicture))
                    .AddSimulationPictures(MapPath(result.SimulationPictures.ToArray()))
                    .AddContent(result)
                    .SaveAs(filename);
            }
            return View(result);
        }

        private ReportTemplateResult ToReportTemplate(SelectionResult result)
        {
            ReportTemplateResult res = new ReportTemplateResult()
            {
                MachinePicture = "images/Report/MachineType.png",
                TransmissionMethod = new TransmissionMethod()
                {
                    XAxis = "减速器",
                    YAxis = "联轴器",
                    ZAxis = "带传动"
                },
                Components = new List<Component>(),
                NCSystem = result.NCSystem,
                ServoMotor = new ServoMotor()
                {
                    XAxis = new ServoMotorAxis(),
                    YAxis = new ServoMotorAxis(),
                    ZAxis = new ServoMotorAxis()
                },
                ServoDriver = new ServoDriver()
                {
                    XAxis = new ServoDriverAxis(),
                    YAxis = new ServoDriverAxis(),
                    ZAxis = new ServoDriverAxis()
                },
                Guide = new Guide()
                {
                    XAxis = new GuideAxis(),
                    YAxis = new GuideAxis(),
                    ZAxis = new GuideAxis()
                },
                BallScrew = new BallScrew()
                {
                    XAxis = new BallScrewAxis(),
                    YAxis = new BallScrewAxis(),
                    ZAxis = new BallScrewAxis()
                },
                SimulationPictures = new List<string>()
                {
                    "images/Report/simu-1.png",
                    "images/Report/simu-2.png",
                    "images/Report/simu-3.png"
                }
            };
            res.Components.Add(new Component() { AxisAndName = "X轴滚珠丝杠", TypeID = result.FeedSystemX.Ballscrew.TypeID, Manufacturer = result.FeedSystemX.Ballscrew.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "X轴轴承", TypeID = result.FeedSystemX.Bearings.TypeID, Manufacturer = result.FeedSystemX.Bearings.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "X轴联轴器", TypeID = result.FeedSystemX.Coupling.TypeID, Manufacturer = result.FeedSystemX.Coupling.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "X轴伺服驱动", TypeID = result.FeedSystemX.Driver.TypeID, Manufacturer = result.FeedSystemX.Driver.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "X轴伺服电机", TypeID = result.FeedSystemX.ServoMotor.TypeID, Manufacturer = result.FeedSystemX.ServoMotor.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "X轴导轨", TypeID = result.FeedSystemX.Guide.TypeID, Manufacturer = result.FeedSystemX.Guide.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Y轴滚珠丝杠", TypeID = result.FeedSystemY.Ballscrew.TypeID, Manufacturer = result.FeedSystemY.Ballscrew.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Y轴轴承", TypeID = result.FeedSystemY.Bearings.TypeID, Manufacturer = result.FeedSystemY.Bearings.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Y轴联轴器", TypeID = result.FeedSystemY.Coupling.TypeID, Manufacturer = result.FeedSystemY.Coupling.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Y轴伺服驱动", TypeID = result.FeedSystemY.Driver.TypeID, Manufacturer = result.FeedSystemY.Driver.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Y轴伺服电机", TypeID = result.FeedSystemY.ServoMotor.TypeID, Manufacturer = result.FeedSystemY.ServoMotor.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Y轴导轨", TypeID = result.FeedSystemY.Guide.TypeID, Manufacturer = result.FeedSystemY.Guide.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Z轴滚珠丝杠", TypeID = result.FeedSystemZ.Ballscrew.TypeID, Manufacturer = result.FeedSystemZ.Ballscrew.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Z轴轴承", TypeID = result.FeedSystemZ.Bearings.TypeID, Manufacturer = result.FeedSystemZ.Bearings.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Z轴联轴器", TypeID = result.FeedSystemZ.Coupling.TypeID, Manufacturer = result.FeedSystemZ.Coupling.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Z轴伺服驱动", TypeID = result.FeedSystemZ.Driver.TypeID, Manufacturer = result.FeedSystemZ.Driver.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Z轴伺服电机", TypeID = result.FeedSystemZ.ServoMotor.TypeID, Manufacturer = result.FeedSystemZ.ServoMotor.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Z轴导轨", TypeID = result.FeedSystemZ.Guide.TypeID, Manufacturer = result.FeedSystemZ.Guide.Manufacturer });

            res.Guide.XAxis.SizeOfGuideFixedBolt = result.FeedSystemX.Guide.SizeOfGuideFixedBolt;
            res.Guide.XAxis.RollerType = result.FeedSystemX.Guide.RollerType;
            res.Guide.XAxis.BasicRatedDynamicLoad = result.FeedSystemX.Guide.BasicRatedDynamicLoad_C;
            res.Guide.XAxis.BasicRatedStaticLoad = result.FeedSystemX.Guide.BasicRatedStaticLoad_C0;

            res.Guide.YAxis.SizeOfGuideFixedBolt = result.FeedSystemY.Guide.SizeOfGuideFixedBolt;
            res.Guide.YAxis.RollerType = result.FeedSystemY.Guide.RollerType;
            res.Guide.YAxis.BasicRatedDynamicLoad = result.FeedSystemY.Guide.BasicRatedDynamicLoad_C;
            res.Guide.YAxis.BasicRatedStaticLoad = result.FeedSystemY.Guide.BasicRatedStaticLoad_C0;

            res.Guide.ZAxis.SizeOfGuideFixedBolt = result.FeedSystemZ.Guide.SizeOfGuideFixedBolt;
            res.Guide.ZAxis.RollerType = result.FeedSystemZ.Guide.RollerType;
            res.Guide.ZAxis.BasicRatedDynamicLoad = result.FeedSystemZ.Guide.BasicRatedDynamicLoad_C;
            res.Guide.ZAxis.BasicRatedStaticLoad = result.FeedSystemZ.Guide.BasicRatedStaticLoad_C0;

            res.ServoMotor.XAxis.RatedTorque = result.FeedSystemX.ServoMotor.RatedTorque;
            res.ServoMotor.XAxis.RatedSpeed = result.FeedSystemY.ServoMotor.RatedTorque;
            res.ServoMotor.XAxis.RatedPower = result.FeedSystemX.ServoMotor.RatedPower;
            res.ServoMotor.XAxis.MomentOfInertia = result.FeedSystemX.ServoMotor.MomentOfInertia;

            res.ServoMotor.YAxis.RatedTorque = result.FeedSystemY.ServoMotor.RatedTorque;
            res.ServoMotor.YAxis.RatedSpeed = result.FeedSystemY.ServoMotor.RatedTorque;
            res.ServoMotor.YAxis.RatedPower = result.FeedSystemY.ServoMotor.RatedPower;
            res.ServoMotor.YAxis.MomentOfInertia = result.FeedSystemY.ServoMotor.MomentOfInertia;

            res.ServoMotor.ZAxis.RatedTorque = result.FeedSystemZ.ServoMotor.RatedTorque;
            res.ServoMotor.ZAxis.RatedSpeed = result.FeedSystemZ.ServoMotor.RatedTorque;
            res.ServoMotor.ZAxis.RatedPower = result.FeedSystemZ.ServoMotor.RatedPower;
            res.ServoMotor.ZAxis.MomentOfInertia = result.FeedSystemZ.ServoMotor.MomentOfInertia;

            res.ServoDriver.XAxis.ContinuousCurrent = result.FeedSystemX.Driver.ContinuousCurrent;
            res.ServoDriver.XAxis.PeakCurrent = result.FeedSystemX.Driver.PeakCurrent;
            res.ServoDriver.XAxis.SupplyVoltage = result.FeedSystemX.Driver.SupplyVoltage;
            res.ServoDriver.XAxis.MaxAdaptableMotorPower = result.FeedSystemX.Driver.MaxAdaptableMotorPower;
            res.ServoDriver.XAxis.ExternalBrakingResistance = result.FeedSystemX.Driver.ExternalBrakingResistance;

            res.ServoDriver.YAxis.ContinuousCurrent = result.FeedSystemY.Driver.ContinuousCurrent;
            res.ServoDriver.YAxis.PeakCurrent = result.FeedSystemY.Driver.PeakCurrent;
            res.ServoDriver.YAxis.SupplyVoltage = result.FeedSystemY.Driver.SupplyVoltage;
            res.ServoDriver.YAxis.MaxAdaptableMotorPower = result.FeedSystemY.Driver.MaxAdaptableMotorPower;
            res.ServoDriver.YAxis.ExternalBrakingResistance = result.FeedSystemY.Driver.ExternalBrakingResistance;

            res.ServoDriver.ZAxis.ContinuousCurrent = result.FeedSystemZ.Driver.ContinuousCurrent;
            res.ServoDriver.ZAxis.PeakCurrent = result.FeedSystemZ.Driver.PeakCurrent;
            res.ServoDriver.ZAxis.SupplyVoltage = result.FeedSystemZ.Driver.SupplyVoltage;
            res.ServoDriver.ZAxis.MaxAdaptableMotorPower = result.FeedSystemZ.Driver.MaxAdaptableMotorPower;
            res.ServoDriver.ZAxis.ExternalBrakingResistance = result.FeedSystemZ.Driver.ExternalBrakingResistance;

            res.BallScrew.XAxis.NominalDiameter = result.FeedSystemX.Ballscrew.NominalDiameter_d0;
            res.BallScrew.XAxis.NominalLead = result.FeedSystemX.Ballscrew.NominalLead_Ph0;
            res.BallScrew.XAxis.BasicRatedDynamicLoad = result.FeedSystemX.Ballscrew.BasicRatedDynamicLoad_Ca;

            res.BallScrew.YAxis.NominalDiameter = result.FeedSystemY.Ballscrew.NominalDiameter_d0;
            res.BallScrew.YAxis.NominalLead = result.FeedSystemY.Ballscrew.NominalLead_Ph0;
            res.BallScrew.YAxis.BasicRatedDynamicLoad = result.FeedSystemY.Ballscrew.BasicRatedDynamicLoad_Ca;

            res.BallScrew.ZAxis.NominalDiameter = result.FeedSystemZ.Ballscrew.NominalDiameter_d0;
            res.BallScrew.ZAxis.NominalLead = result.FeedSystemZ.Ballscrew.NominalLead_Ph0;
            res.BallScrew.ZAxis.BasicRatedDynamicLoad = result.FeedSystemZ.Ballscrew.BasicRatedDynamicLoad_Ca;

            return res;
        }

        public IActionResult DownLoad(string shortName)
        {
            string filename = MapPath("temp", shortName + ".docx");
            return File(filename, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "仿真结果");   
        }

        private string MapPath(string relativeUrl)
        {
            return Path.Combine(_webRootPath, relativeUrl);
        }

        private string MapPath(string path1, string path2)
        {
            return Path.Combine(_webRootPath, path1, path2);
        }

        private string[] MapPath(string[] relativeUrls)
        {
            return new string[]
            {
                MapPath(relativeUrls[0]),
                MapPath(relativeUrls[1]),
                MapPath(relativeUrls[2])
            };
        }
    }
}