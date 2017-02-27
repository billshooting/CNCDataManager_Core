using CNCDataManager.Models.Simulation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CNCDataManager.Controllers.Internals
{
    internal class Simulator
    {
        /// <summary>
        /// 根据参数指定的路径创建一个求解器
        /// </summary>
        /// <param name="ModelFile">模型库文件路径</param>
        /// <param name="LoadFile">模型realpackage.mo文件路径</param>
        /// <param name="CodePath">输出求解器的路径</param>
        /// <param name="ModelName">模型名称xml文件</param>
        [DllImport("compilerDoublewrapper.dll", EntryPoint = "modelCompiler", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void modelCompiler(string ModelFile, string LoadFile, string CodePath, string ModelName);

        /// <summary>
        /// 将msf结果文件转化为所需的数据并存放进txt文件中
        /// </summary>
        /// <param name="msfPath">msf结果文件路径</param>
        /// <param name="txtfilename">提取所需变量的设置文件</param>
        /// <param name="resultPath">结果文件路径</param>
        [DllImport("msfReaderDll.dll", EntryPoint = "msfToTxt", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void msfToTxt(string msfPath, string txtfilename, string resultPath);

        private readonly PathSettings _pathSettings;
        private StringBuilder _content;

        public Simulator(PathSettings pathSettings)
        {
            _pathSettings = pathSettings;
        }

        /// <summary>
        /// 创捷求解器
        /// </summary>
        public void CreateCompiler()
        {
            if (!Directory.Exists(_pathSettings.CompilerPath))
            {
                Directory.CreateDirectory(_pathSettings.CompilerPath);
            }
            /** modelica dll的限制，不能多线程同时调用**/
            modelCompiler(_pathSettings.Library, _pathSettings.ModelFile, _pathSettings.CompilerPath, _pathSettings.ModelName);
        }

        /// <summary>
        /// 生成求解所需的setting.txt文件
        /// </summary>
        /// <param name="setting">前端传入的设置数据</param>
        public void PreprocessCompiler(Setting setting)
        {
            string[] lines = new string[9];
            lines[0] = "[Simulation Interval]";
            lines[1] = "start_time=" + setting.StartTime;
            lines[2] = "stop_time=" + setting.EndTime;

            lines[3] = "[Output Step]";
            lines[4] = "step_len=" + setting.StepSize;
            lines[5] = "step_num=" + setting.StepNum;

            lines[6] = "[Integration]";
            lines[7] = "dae_algo=" + setting.Alg;
            lines[8] = "tol=" + setting.Precision;

            if (!Directory.Exists(_pathSettings.CompilerPath))
            {
                Directory.CreateDirectory(_pathSettings.CompilerPath);
            }

            File.WriteAllLines(_pathSettings.SettingFile, lines, Encoding.GetEncoding("UTF-8"));
        }

        /// <summary>
        /// 执行求解器
        /// </summary>
        public void RunCompiler()
        {
            Process process = new Process();

            process.StartInfo.FileName = getCmdArguments(_pathSettings.CompilerFile);
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Arguments = "-s " + getCmdArguments(_pathSettings.SettingFile) + " -r " + getCmdArguments(_pathSettings.MsfFile);

            //开启一个进程运行求解器并等待其运行结束
            process.Start();
            process.WaitForExit();
        }

        /// <summary>
        /// 生成realpackage.mo文件
        /// </summary>
        /// <param name="para">前端传入的数据</param>
        public void PrepareSimulationModel(SimulationPara para)
        {
            ReadTemplateFile();//读取 Mworks/Template/X_axis/package.txt 这是一个模板文件

            ReplaceInput(para.Setting); //替换模板中的输入信号和干扰
            ReplaceMotor(para.Motor);
            ReplaceDriver(para.Driver);
            ReplaceBallscrew(para.Ballscrew, para.Worktable);
            ReplaceGuide(para.Guide, para.Worktable);
            ReplaceBearings(para.Bearings);
            ReplaceCoupling(para.Coupling);
            ReplaceWorktable(para.Worktable, para.Ballscrew);

            WriteModelFile();//生成realpackage.mo
        }

        //路径中有空格需要用引号
        private string getCmdArguments(string path)
        {
            return "\"" + path + "\"";
        }

        private void ReadTemplateFile()
        {
            //判断模板文件是否存在
            if (!File.Exists(_pathSettings.TemplateFile))
            {
                throw new Exception("TemplateFile is not found");
            }
            //打开文件流，读入模型文件
            using (FileStream fs = new FileStream(_pathSettings.TemplateFile, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("UTF-8")))
                {
                    _content = new StringBuilder(sr.ReadToEnd());
                }
            }
        }

        //写出模板文件
        private void WriteModelFile()
        {
            //判断模板文件目录是否存在
            if (!Directory.Exists(_pathSettings.WorkingPath))
            {
                Directory.CreateDirectory(_pathSettings.WorkingPath);
            }
            //打开文件流，写入模型文件
            using (FileStream cs = new FileStream(_pathSettings.ModelFile, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(cs, Encoding.GetEncoding("UTF-8")))
                {
                    sw.WriteLine(_content);
                }
            }
        }

        //替换输入信号类型
        private void ReplaceInput(Setting setting)
        {
            //判断信号类型，决定模板替换元素
            string singal, inputInterface;
            switch (setting.Signal)
            {
                case "Sine":
                    singal = "Modelica.Blocks.Sources.Sine sine";
                    inputInterface = "connect(sine.y, servo.phi_ref)";
                    break;
                case "Step":
                    singal = "Modelica.Blocks.Sources.Step step";
                    inputInterface = "connect(step.y, servo.phi_ref)";
                    break;
                case "Constant":
                    singal = "Modelica.Blocks.Sources.Constant const";
                    inputInterface = "connect(const.y, servo.phi_ref)";
                    break;
                default:
                    throw new Exception("signalType error");
            }

            //进行模型替换
            _content = _content.Replace("<Input>SignalType</Input>", singal);
            _content = _content.Replace("<Connect>InputInterface</Connect>", inputInterface);
        }

        //替换模板电机部分参数
        private void ReplaceMotor(Motor motor)
        {
            _content = _content.Replace("<param>PMSMRotorMomentInertia</param>", motor.RotorMomentInertia.ToString());
            _content = _content.Replace("<param>PMSMNumberPolePairs</param>", motor.PolePairs.ToString());
            _content = _content.Replace("<param>PMSMStatorResistance</param>", motor.StatorResistance.ToString());
            _content = _content.Replace("<param>PMSMStatorStrayInductance</param>", motor.StatorStrayInductance.ToString());
            _content = _content.Replace("<param>PMSMMainFieldInductanceDaxis</param>", motor.MainFieldInductanceDaxis.ToString());
            _content = _content.Replace("<param>PMSMMainFieldInductanceQaxis</param>", motor.MainFieldInductanceQaxis.ToString());
            _content = _content.Replace("<param>PMSMOpposingElectromotiveForce</param>", motor.OpposingElectromotiveForce.ToString());
        }

        //替换模板驱动部分参数
        private void ReplaceDriver(Driver driver)
        {
            _content = _content.Replace("<param>DriversNominalVoltage</param>", driver.NominalVoltage.ToString());
            _content = _content.Replace("<param>DriversPWMCircle</param>", driver.PWMCircle.ToString());
            _content = _content.Replace("<param>DriversPolePairs</param>", driver.PolePairs.ToString());
            _content = _content.Replace("<param>DriversCellVoltage</param>", driver.CellVoltage.ToString());
            _content = _content.Replace("<param>DriversKS</param>", driver.KS.ToString());
            _content = _content.Replace("<param>DriversKV</param>", driver.KV.ToString());
            _content = _content.Replace("<param>DriversTV</param>", driver.TV.ToString());
            _content = _content.Replace("<param>DriversKD</param>", driver.KD.ToString());
            _content = _content.Replace("<param>DriversTD</param>", driver.TD.ToString());
        }

        //替换模板滚珠丝杠部分参数
        private void ReplaceBallscrew(Ballscrew ballscrew, Worktable worktable)
        {
            _content = _content.Replace("<param>ScrewDiameter</param>", ballscrew.Diameter.ToString());
            _content = _content.Replace("<param>ScrewModulusofElasticty</param>", ballscrew.ModulusofElasticty.ToString());
            _content = _content.Replace("<param>ScrewShaftDistance</param>", ballscrew.ShaftDistance.ToString());
            _content = _content.Replace("<param>ScrewPitch</param>", ballscrew.Pitch.ToString());
            _content = _content.Replace("<param>ScrewLength</param>", ballscrew.Length.ToString());
            _content = _content.Replace("<param>ScrewDensity</param>", ballscrew.Density.ToString());
            _content = _content.Replace("<param>ScrewShearModulusofElasticty</param>", ballscrew.ShearModulusofElasticty.ToString());
            _content = _content.Replace("<param>ScrewCampingCoefficient</param>", ballscrew.CampingCoefficient.ToString());
            _content = _content.Replace("<param>ScrewWorktableQuality</param>", worktable.Mass.ToString());
        }

        //替换模板导轨部分参数
        private void ReplaceGuide(Guide guide, Worktable worktable)
        {
            _content = _content.Replace("<param>RollingGuideWorktableQuality</param>", worktable.Mass.ToString());
            _content = _content.Replace("<param>RollingGuideFrictionFactor</param>", guide.FrictionFactor.ToString());
            _content = _content.Replace("<param>RollingGuideViscosityFriction</param>", guide.ViscosityFriction.ToString());
        }

        //替换模板轴承部分参数
        private void ReplaceBearings(Bearings bearings)
        {
            _content = _content.Replace("<param>BearingAxialStiffness</param>", bearings.AxisalStiffness.ToString());
            _content = _content.Replace("<param>BearingStartingMoment</param>", bearings.StartingMoment.ToString());
        }

        //替换模板联轴器部分参数
        private void ReplaceCoupling(Coupling coupling)
        {
            _content = _content.Replace("<param>CouplingStiffness</param>", coupling.Stiffness.ToString());
            _content = _content.Replace("<param>CouplingMomentInertia</param>", coupling.MomentInertia.ToString());
        }

        //替换模板工作台部分参数
        private void ReplaceWorktable(Worktable worktable, Ballscrew ballscrew)
        {
            _content = _content.Replace("<param>WorktableQuality</param>", worktable.Mass.ToString());
            _content = _content.Replace("<param>WorktableScrewPitch</param>", ballscrew.Pitch.ToString());
            _content = _content.Replace("<param>WorktableNutDymanicload</param>", worktable.DynamicLoadRating.ToString());
            _content = _content.Replace("<param>WorktableContactStiffness</param>", worktable.ContactStiffness.ToString());
            _content = _content.Replace("<param>WorktableScrewPretighteningEfficience</param>", worktable.TighteningEfficiency.ToString());
        }

        public void MsfToTxt()
        {
            if (!Directory.Exists(_pathSettings.DataPath))
            {
                Directory.CreateDirectory(_pathSettings.DataPath);
            }
            msfToTxt(_pathSettings.MsfFile, _pathSettings.VarNameFile, _pathSettings.DataPath);
        }
    }
}
