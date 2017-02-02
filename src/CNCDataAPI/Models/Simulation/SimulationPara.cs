using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCDataManager.Models.Simulation
{
    public class SimulationPara
    {
        public string AxisID { get; set; }
        public Motor Motor { get; set; }
        public Driver Driver { get; set; }
        public Ballscrew Ballscrew { get; set; }
        public Guide Guide { get; set; }
        public Bearings Bearings { get; set; }
        public Coupling Coupling { get; set; }
        public Worktable Worktable { get; set; }
        public Setting Setting { get; set; }
    }

    public class Motor
    {
        public double? RotorMomentInertia { get; set; }
        public double? PolePairs { get; set; }
        public double? StatorResistance { get; set; }
        public double? StatorStrayInductance { get; set; }
        public double? MainFieldInductanceDaxis { get; set; }
        public double? MainFieldInductanceQaxis { get; set; }
        public double? OpposingElectromotiveForce { get; set; }
    }

    public class Driver
    {
        public double? NominalVoltage { get; set; }
        public double? PWMCircle { get; set; }
        public double? KS { get; set; }
        public double? KV { get; set; }
        public double? PolePairs { get; set; }
        public double? CellVoltage { get; set; }
        public double? KD { get; set; }
        public double? TD { get; set; }
        public double? TV { get; set; }
    }

    public class Ballscrew
    {
        public double? Diameter { get; set; }
        public double? ModulusofElasticty { get; set; }
        public double? ShaftDistance { get; set; }
        public double? Pitch { get; set; }
        public double? Length { get; set; }
        public double? Density { get; set; }
        public double? ShearModulusofElasticty { get; set; }
        public double? CampingCoefficient { get; set; }
    }

    public class Guide
    {
        public double? FrictionFactor { get; set; }
        public double? ViscosityFriction { get; set; }
    }

    public class Bearings
    {
        public double? AxisalStiffness { get; set; }
        public double? StartingMoment { get; set; }
    }

    public class Coupling
    {
        public double? Stiffness { get; set; }
        public double? MomentInertia { get; set; }
    }

    public class Worktable
    {
        public double? Mass { get; set; }
        public double? TighteningEfficiency { get; set; }
        public double? ContactStiffness { get; set; }
        public double? DynamicLoadRating { get; set; }
    }

    public class Setting
    {
        public string Signal { get; set; }
        public double? StartTime { get; set; }
        public double? EndTime { get; set; }
        public double? StepSize { get; set; }
        public double? StepNum { get; set; }
        public string Alg { get; set; }
        public double? Precision { get; set; }
    }
}
