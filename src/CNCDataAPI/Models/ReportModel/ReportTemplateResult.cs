using System.Collections.Generic;

namespace CNCDataManager.Models
{
    public class TransmissionMethod
    {
        public string XAxis { get; set; }
        public string YAxis { get; set; }
        public string ZAxis { get; set; }
    }

    public class Component
    {
        public string TypeID { get; set; }
        public string Manufacturer { get; set; }
        public string AxisAndName { get; set; }
    }

    public class NCSystem
    {
        public string TypeID { get; set; }
        public string SupportMachineType { get; set; }
        public int? NumberOfSupportChannels { get; set; }
        public int? MaxNumberOfFeedSystemAxis { get; set; }
        public int? MaxNumberOfSpindleAxis { get; set; }
        public int? MaxNumberOfLinkageAxis { get; set; }
    }
    public class ServoMotorAxis
    {
        public double? RatedTorque { get; set; }
        public double? RatedSpeed { get; set; }
        public double? RatedPower { get; set; }
        public double? MomentOfInertia { get; set; }
    }
    public class ServoMotor
    {
        public ServoMotorAxis XAxis { get; set; }
        public ServoMotorAxis YAxis { get; set; }
        public ServoMotorAxis ZAxis { get; set; }
    }

    public class ServoDriverAxis
    {
        public double? ContinuousCurrent { get; set; }
        public double? PeakCurrent { get; set; }
        public string SupplyVoltage { get; set; }
        public double? MaxAdaptableMotorPower { get; set; }
        public string ExternalBrakingResistance { get; set; }
    }
    public class ServoDriver
    {
        public ServoDriverAxis XAxis { get; set; }
        public ServoDriverAxis YAxis { get; set; }
        public ServoDriverAxis ZAxis { get; set; }
    }

    public class GuideAxis
    {
        public string SizeOfGuideFixedBolt { get; set; }
        public string RollerType { get; set; }
        public double? BasicRatedDynamicLoad { get; set; }
        public double? BasicRatedStaticLoad { get; set; }
    }
    public class Guide
    {
        public GuideAxis XAxis { get; set; }
        public GuideAxis YAxis { get; set; }
        public GuideAxis ZAxis { get; set; }
    }

    public class BallScrewAxis
    {
        public double? NominalDiameter { get; set; }
        public double? NominalLead { get; set; }
        public double? BasicRatedDynamicLoad { get; set; }
    }
    public class BallScrew
    {
        public BallScrewAxis XAxis { get; set; }
        public BallScrewAxis YAxis { get; set; }
        public BallScrewAxis ZAxis { get; set; }
    }
    //选型结果
    public class ReportTemplateResult
    {
        public string Filename { get; set; }
        public string MachinePicture { get; set; }
        public TransmissionMethod TransmissionMethod { get; set; }
        public List<Component> Components { get; set; }
        public NCSystem NCSystem { get; set; }
        public ServoMotor ServoMotor { get; set; }
        public ServoDriver ServoDriver { get; set; }
        public Guide Guide { get; set; }
        public BallScrew BallScrew { get; set; }
        public List<string> SimulationPictures { get; set; }
    }
}