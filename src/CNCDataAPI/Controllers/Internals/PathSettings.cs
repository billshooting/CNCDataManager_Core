using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CNCDataManager.Controllers.Internals
{
    public class PathSettings
    {
        public PathSettings(string webRootPath, string axis, string userName, string fileID)
        {
            MWorksPath = Path.Combine(webRootPath, "Mworks");

            Library = Path.Combine(MWorksPath, "Library", "Modelica 2.2.2");

            //生成独一无二的临时文件夹
            //TempId = Guid.NewGuid().ToString();

            //确定使用的模板文件
            string axisName = axis + "_axis";
            TemplateFile = Path.Combine(MWorksPath, "Template", axisName, "package.txt");
            VarNameFile = Path.Combine(MWorksPath, "Template", axisName, "VarName.txt");
            if (axis != "X" && axis != "Y" && axis != "Z") throw new ArgumentException("Wrong Axis Name!");
            ModelName = axis + "_axis." + axis + "_axis_model";

            WorkingPath = Path.Combine(webRootPath, "Users", userName, fileID); //工作目录
            CompilerPath = Path.Combine(WorkingPath, "compiler");
            DataPath = Path.Combine(WorkingPath, "data", " ").TrimEnd(); //msfReaderDll.dll似有bug

            MsfFile = Path.Combine(WorkingPath, "data.msf");
            ModelFile = Path.Combine(WorkingPath, "realpackage.mo");
            CompilerFile = Path.Combine(CompilerPath, "MWSolver.exe");
            SettingFile = Path.Combine(CompilerPath, "Setting.txt");
        }

        public readonly string MWorksPath;   //Morks组件根目录

        public readonly string Library;   //Modelica库文件目录

        public readonly string TempId;   //Temp文件夹id

        public readonly string TemplateFile;   //模板文件

        public readonly string WorkingPath;    //模型文件所在目录

        public readonly string ModelFile;   //模型文件

        public readonly string CompilerPath;   //编译器路径

        public readonly string CompilerFile;   //编译器文件

        public readonly string ModelName;   //模型名

        public readonly string SettingFile;   //设置文件

        public readonly string MsfFile;   //结果文件

        public readonly string VarNameFile;   //变量名文件

        public readonly string DataPath;   //数据结果文件路径
    }
}
