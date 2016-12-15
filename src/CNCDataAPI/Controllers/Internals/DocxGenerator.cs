using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Novacode;
using System.IO;
using CNCDataManager.Models;

namespace CNCDataManager.Controllers.Internals
{
    internal class DocxGenerator: IDisposable
    {
        private const int machinePictureIndex = 1;
        private const int transmissionMethodIndex = 2;
        private const int componentsTableIndex = 3;
        private const int ncSystemIndex = 4;
        private const int servoMotorIndex = 5;
        private const int servoDriverIndex = 6;
        private const int guideTableIndex = 7;
        private const int ballScrewIndex = 8;
        private const int simuPictureIndex = 9;

        private DocX document;

        public string DocName { get; }
        //public Stream DocStream { get; }

        public DocxGenerator(string filename = @"~/App/docTemplate/选型简表结果.docx")
        {
            DocName = filename;
            //DocStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            document = DocX.Load(filename);
        }


        public DocxGenerator AddMachinePicture(string machineImage)
        {
            Image image = document.AddImage(machineImage);
            Picture pic = image.CreatePicture(250, 350);
            var p = document.Tables[machinePictureIndex].Rows.FirstOrDefault().Paragraphs.FirstOrDefault();
            p.InsertPicture(pic);
            return this;
        }

        public DocxGenerator AddSimulationPictures(params string[] simuImages)
        {
            int index = 0;
            foreach(string simuImage in simuImages)
            {
                Image image = document.AddImage(simuImage);
                Picture pic = image.CreatePicture(250, 350);
                var p = document.Tables[simuPictureIndex].Rows[index++].Paragraphs.FirstOrDefault();
                p.InsertPicture(pic);
            }
            return this;
        }

        public DocxGenerator AddAllPictures(params string[] imageFiles)
        {
            string machinePic = imageFiles[0];
            AddMachinePicture(machinePic).AddSimulationPictures(imageFiles.Skip(1).ToArray());
            return this;
        }

        public DocxGenerator AddContent(ReportTemplateResult result)
        {
            AddTransMissionMethod(result.TransmissionMethod);
            AddComponents(result.Components);
            AddNCSystem(result.NCSystem);
            AddServoMotor(result.ServoMotor);
            AddServoDriver(result.ServoDriver);
            AddGuide(result.Guide);
            AddBallScrew(result.BallScrew);
            return this;
        }

        public void SaveAs(string filename)
        {
            document.SaveAs(filename);
        }

        private void AddTransMissionMethod(TransmissionMethod tm)
        {
            var cellX = document.Tables[transmissionMethodIndex].Rows[1].Cells[1].Paragraphs.FirstOrDefault();
            cellX.Append(tm.XAxis);
            var cellY = document.Tables[transmissionMethodIndex].Rows[2].Cells[1].Paragraphs.FirstOrDefault();
            cellY.Append(tm.YAxis);
            var cellZ = document.Tables[transmissionMethodIndex].Rows[3].Cells[1].Paragraphs.FirstOrDefault();
            cellZ.Append(tm.ZAxis);
        }

        private void AddComponents(IList<Component> comps)
        {
            Paragraph p;
            for (int i = 0; i < Math.Min(comps.Count(), 47); i++)
            {
                p = document.Tables[componentsTableIndex].Rows[i + 1].Cells[1].Paragraphs.FirstOrDefault();
                p.Append(comps[i].AxisAndName);
                p = document.Tables[componentsTableIndex].Rows[i + 1].Cells[2].Paragraphs.FirstOrDefault();
                p.Append(comps[i].Manufacturer);
                p = document.Tables[componentsTableIndex].Rows[i + 1].Cells[3].Paragraphs.FirstOrDefault();
                p.Append(comps[i].TypeID);
            }
        }

        private void AddNCSystem(NCSystem system)
        {
            var table = document.Tables[ncSystemIndex];
            Paragraph p = table.Rows[0].Cells[1].Paragraphs.FirstOrDefault();
            p.Append(system.TypeID);
            p = table.Rows[1].Cells[1].Paragraphs.FirstOrDefault();
            p.Append(system.SupportMachineType);
            p = table.Rows[2].Cells[1].Paragraphs.FirstOrDefault();
            p.Append(system.NumberOfSupportChannels.Value.ToString());
            p = table.Rows[3].Cells[1].Paragraphs.FirstOrDefault();
            p.Append(system.MaxNumberOfFeedSystemAxis.Value.ToString());
            p = table.Rows[4].Cells[1].Paragraphs.FirstOrDefault();
            p.Append(system.MaxNumberOfSpindleAxis.Value.ToString());
            p = table.Rows[5].Cells[1].Paragraphs.FirstOrDefault();
            p.Append(system.MaxNumberOfLinkageAxis.Value.ToString());
        }

        private void AddServoMotor(ServoMotor sm)
        {
            var table = document.Tables[servoMotorIndex];
            AddServoMotorAxis(table, sm.XAxis, 3);
            AddServoMotorAxis(table, sm.YAxis, 9);
            AddServoMotorAxis(table, sm.ZAxis, 15);
        }
        private void AddServoMotorAxis(Table table, ServoMotorAxis sma, int rowIndex)
        {
            Paragraph p = table.Rows[rowIndex].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(sma.RatedTorque.Value.ToString());
            p = table.Rows[rowIndex + 1].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(sma.RatedSpeed.Value.ToString());
            p = table.Rows[rowIndex + 2].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(sma.MomentOfInertia.Value.ToString());
            p = table.Rows[rowIndex + 3].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(sma.RatedPower.Value.ToString());
        }

        private void AddServoDriver(ServoDriver sd)
        {
            var table = document.Tables[servoDriverIndex];
            AddServoDriverAxis(table, sd.XAxis, 3);
            AddServoDriverAxis(table, sd.YAxis, 10);
            AddServoDriverAxis(table, sd.ZAxis, 17);
        }
        private void AddServoDriverAxis(Table table, ServoDriverAxis sda, int rowIndex)
        {
            Paragraph p = table.Rows[rowIndex].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(sda.ContinuousCurrent.Value.ToString());
            p = table.Rows[rowIndex + 1].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(sda.PeakCurrent.Value.ToString());
            p = table.Rows[rowIndex + 2].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(sda.SupplyVoltage);
            p = table.Rows[rowIndex + 3].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(sda.MaxAdaptableMotorPower.Value.ToString());
            p = table.Rows[rowIndex + 4].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(sda.ExternalBrakingResistance);
        }

        private void AddGuide(Guide guide)
        {
            var table = document.Tables[guideTableIndex];
            AddGuideAxis(table, guide.XAxis, 3);
            AddGuideAxis(table, guide.YAxis, 9);
            AddGuideAxis(table, guide.ZAxis, 15);
        }
        private void AddGuideAxis(Table table, GuideAxis ga, int rowIndex)
        {
            Paragraph p = table.Rows[rowIndex].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(ga.SizeOfGuideFixedBolt);
            p = table.Rows[rowIndex + 1].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(ga.RollerType);
            p = table.Rows[rowIndex + 2].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(ga.BasicRatedDynamicLoad.Value.ToString());
            p = table.Rows[rowIndex + 3].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(ga.BasicRatedStaticLoad.Value.ToString());
        }

        private void AddBallScrew(BallScrew bs)
        {
            var table = document.Tables[ballScrewIndex];
            AddBallScrewAxis(table, bs.XAxis, 3);
            AddBallScrewAxis(table, bs.YAxis, 8);
            AddBallScrewAxis(table, bs.ZAxis, 13);
        }
        private void AddBallScrewAxis(Table table, BallScrewAxis bsa, int rowIndex)
        {
            Paragraph p = table.Rows[rowIndex].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(bsa.NominalDiameter.Value.ToString());
            p = table.Rows[rowIndex + 1].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(bsa.NominalLead.Value.ToString());
            p = table.Rows[rowIndex + 2].Cells[2].Paragraphs.FirstOrDefault();
            p.Append(bsa.BasicRatedDynamicLoad.Value.ToString());
        }

        public void Dispose()
        {
            //((IDisposable)DocStream).Dispose();
            ((IDisposable)document).Dispose();
        }
    }
}