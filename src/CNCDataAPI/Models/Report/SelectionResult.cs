using CNCDataManager.Models.APIs;

namespace CNCDataManager.Models
{
    public class RollingGuide: LineRollingGuide
    {
        public string RollType { get; set; }
    }

    public class Bearings
    {
        public string TypeID { get; set; }
        public string Manufacturer { get; set; }
        public double? InnerDiameter_d { get; set; }
        public double? Diameter_D { get; set; }
        public double? Width_B { get; set; }
        public double? BasicRatedDynamicLoad { get; set; }
        public double? BasicRatedStaticLoad { get; set; }
        public double? SpeedLimitOfGrease { get; set; }
        public double? SpeedLimitOfOil { get; set; }
        public double? BearingAxialStiffness { get; set; }
        public double? BearingStartingTorque { get; set; }
    }

    public class Coupling
    {
        public string TypeID { get; set; }
        public string Manufacturer { get; set; }
        public double? NominalTorque { get; set; }
        public double? AllowableRotationSpeed { get; set; }
        public double? Mass { get; set; }
        public double? MomentOfInertia { get; set; }
        public double? Stiffness { get; set; }
    }

    public class CNCType
    {
        public string Type { get; set; }
        public string Support { get; set; }
        public string Img { get; set; }
    }

    public class FeedSystem
    {
        public RollingGuide Guide { get; set; }
        public SolidBallScrewNutPairs Ballscrew { get; set; }
        public Bearings Bearings { get; set; }
        public Coupling Coupling { get; set; }
        public PMSrvMotorPara ServoMotor { get; set; }
        public PMSrvMotorDriver Driver { get; set; }
    }

    public class SelectionResult
    {
        public CNCType CNCType { get; set; }
        public NCSystem NCSystem { get; set; }
        public FeedSystem FeedSystemX { get; set; }
        public FeedSystem FeedSystemY { get; set; }
        public FeedSystem FeedSystemZ { get; set; }
    }
}