namespace CNCDataManager.Models.APIs
{
    using Microsoft.EntityFrameworkCore;

    public partial class CNCMachineData : DbContext
    {
        public CNCMachineData(DbContextOptions<CNCMachineData> options) : base(options) { }

        public virtual DbSet<NCSystem>                      NCSystems                           { get; set; }
        public virtual DbSet<StepMotorSize>                 StepMotorSizes                      { get; set; }
        public virtual DbSet<StepMotorPara>                 StepMotorParas                      { get; set; }
        public virtual DbSet<GearCoup>                      GearCouplings                       { get; set; }
        public virtual DbSet<BWElasticSlvPinCoup>           BWElasticSlvPinCouplings            { get; set; }
        public virtual DbSet<ElasticSlvPinCoup>             ElasticSlvPinCouplings              { get; set; }
        public virtual DbSet<FlexiblePinCoup>               FlexiblePinCouplings                { get; set; }
        public virtual DbSet<Cables>                        Cables                              { get; set; }
        public virtual DbSet<ElecSpindleSize>               ElecSpindleSizes                    { get; set; }
        public virtual DbSet<ElecSpindlePara>               ElecSpindleParas                    { get; set; }
        public virtual DbSet<NeedleRollerThrustRollerBrg>   NeedleRollerThrustRollerBearings    { get; set; }
        public virtual DbSet<BallLeadScrewSptBrg>           BallLeadScrewSptBearings            { get; set; }
        public virtual DbSet<RotaryTable>                   RotaryTables                        { get; set; }
        public virtual DbSet<XTaperedRollerBrg>             XTaperedRollerBearings              { get; set; }
        public virtual DbSet<AngContactBallBrg>             AngContactBallBearings              { get; set; }
        public virtual DbSet<HubShapedCoup>                 HubShapedCouplings                  { get; set; }
        public virtual DbSet<PlumShapedFlexibleCoup>        PlumShapedFlexibleCouplings         { get; set; }
        public virtual DbSet<CommonCylinWormGear>           CommonCylinWormGears                { get; set; }
        public virtual DbSet<DeepGrooveBallBrg>             DeepGrooveBallBearings              { get; set; }
        public virtual DbSet<OldhamCoup>                    OldhamCouplings                     { get; set; }
        public virtual DbSet<SolidBallScrewNutPairs>        SolidBallScrewNutPairs              { get; set; }
        public virtual DbSet<NCSystemIOUnit>                NCSystemIOUnits                     { get; set; }
        public virtual DbSet<NCSystemPowerUnit>             NCSystemPowerUnits                  { get; set; }
        public virtual DbSet<NCSystemFunctionalOptions>     NCSystemFunctionalOptions           { get; set; }
        public virtual DbSet<NCSystemManual>                NCSystemManuals                     { get; set; }
        public virtual DbSet<DoubleRowCylinRollerBrg>       DoubleRowCylinRollerBearings        { get; set; }
        public virtual DbSet<DoubleThrustAngContactBallBrg> DoubleThrustAngContactBallBearings  { get; set; }
        public virtual DbSet<SrvDriverReactor>              SrvDriverReactors                   { get; set; }
        public virtual DbSet<SrvDriverTransformer>          SrvDriverTransformers               { get; set; }
        public virtual DbSet<SrvDriverBrakeResistor>        SrvDriverBrakeResistors             { get; set; }
        public virtual DbSet<AlignRollerBrg>                AlignRollerBearings                 { get; set; }
        public virtual DbSet<AlignBallBrg>                  AlignBallBearings                   { get; set; }
        public virtual DbSet<FlangeCoup>                    FlangeCouplings                     { get; set; }
        public virtual DbSet<HeliCylinGear>                 HeliCylinGears                      { get; set; }
        public virtual DbSet<PMSrvMotorSize>                PMSrvMotorSizes                     { get; set; }
        public virtual DbSet<PMSrvMotorPara>                PMSrvMotorParas                     { get; set; }
        public virtual DbSet<PMSrvMotorDriver>              PMSrvMotorDrivers                   { get; set; }
        public virtual DbSet<ArcCylinWormGear>              ArcCylinWormGears                   { get; set; }
        public virtual DbSet<CylinRollerBrg>                CylinRollerBearings                 { get; set; }
        public virtual DbSet<TaperedRollerBrg>              TaperedRollerBearings               { get; set; }
        public virtual DbSet<SpurGear>                      SpurGears                           { get; set; }
        public virtual DbSet<StraightBevelGear>             StraightBevelGears                  { get; set; }
        public virtual DbSet<LineRollingGuide>              LineRollingGuides                   { get; set; }
        public virtual DbSet<SpindleBeltSize>               SpindleBeltSizes                    { get; set; }
        public virtual DbSet<SpindleBeltLength>             SpindleBeltLengths                  { get; set; }
        public virtual DbSet<SpindleBeltPara>               SpindleBeltParas                    { get; set; }
        public virtual DbSet<SpindleSrvMotorSize>           SpindleSrvMotorSizes                { get; set; }
        public virtual DbSet<SpindleSrvMotorPara>           SpindleSrvMotorParas                { get; set; }
        public virtual DbSet<SpindleSrvMotorDriver>         SpindleSrvMotorDrivers              { get; set; }

        public virtual DbSet<CNCMachineType>                CNCMachineTypes                     { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StepMotorPara>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<GearCoup>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<BWElasticSlvPinCoup>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<ElasticSlvPinCoup>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<FlexiblePinCoup>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<ElecSpindlePara>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<NeedleRollerThrustRollerBrg>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<NeedleRollerThrustRollerBrg>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<NeedleRollerThrustRollerBrg>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<BallLeadScrewSptBrg>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<BallLeadScrewSptBrg>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<BallLeadScrewSptBrg>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.SizeOfWorkingTable)
                .IsUnicode(true);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.SizeOfCentrallyLocatedHole)
                .IsUnicode(true);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.TotalDriveRatio)
                .IsUnicode(true);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.PitchAccuracy)
                .IsUnicode(true);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.RepeatAccuracy)
                .IsUnicode(true);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XTaperedRollerBrg>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<XTaperedRollerBrg>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<XTaperedRollerBrg>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<AngContactBallBrg>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<AngContactBallBrg>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<AngContactBallBrg>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<HubShapedCoup>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<HubShapedCoup>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<HubShapedCoup>()
                .Property(e => e.DiameterOfShaftHole_d1)
                .IsUnicode(true);

            modelBuilder.Entity<HubShapedCoup>()
                .Property(e => e.DiameterOfShaftHole_d2)
                .IsUnicode(true);

            modelBuilder.Entity<HubShapedCoup>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<PlumShapedFlexibleCoup>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<CommonCylinWormGear>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<DeepGrooveBallBrg>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<DeepGrooveBallBrg>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<DeepGrooveBallBrg>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<OldhamCoup>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<SolidBallScrewNutPairs>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<SolidBallScrewNutPairs>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<SolidBallScrewNutPairs>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<DoubleRowCylinRollerBrg>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<DoubleRowCylinRollerBrg>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<DoubleRowCylinRollerBrg>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<DoubleThrustAngContactBallBrg>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<DoubleThrustAngContactBallBrg>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<DoubleThrustAngContactBallBrg>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<AlignRollerBrg>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<AlignRollerBrg>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<AlignRollerBrg>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<AlignBallBrg>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<AlignBallBrg>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<AlignBallBrg>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<FlangeCoup>()
                .Property(e => e.DiameterOfBolts)
                .IsUnicode(true);

            modelBuilder.Entity<FlangeCoup>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<HeliCylinGear>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<HeliCylinGear>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<HeliCylinGear>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<PMSrvMotorSize>()
                .Property(e => e.Size_F)
                .IsUnicode(true);

            modelBuilder.Entity<PMSrvMotorSize>()
                .Property(e => e.Size_D)
                .IsUnicode(true);

            modelBuilder.Entity<PMSrvMotorPara>()
                .Property(e => e.IfWithBrake)
                .IsUnicode(true);

            modelBuilder.Entity<PMSrvMotorPara>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<PMSrvMotorDriver>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<ArcCylinWormGear>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<CylinRollerBrg>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<CylinRollerBrg>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<CylinRollerBrg>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<TaperedRollerBrg>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<TaperedRollerBrg>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<TaperedRollerBrg>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<SpurGear>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<StraightBevelGear>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.Manufacturer)
                .IsUnicode(true);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.SizeOfGuideFixedBolt)
                .IsUnicode(true);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.RollerType)
                .IsUnicode(true);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.SizeOfSlider_K)
                .IsUnicode(true);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.SizeOfSlider_M)
                .IsUnicode(true);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.SizeOfSlider_T2)
                .IsUnicode(true);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<SpindleBeltSize>()
                .Property(e => e.TypeID)
                .IsUnicode(true);

            modelBuilder.Entity<SpindleBeltSize>()
                .Property(e => e.C2F)
                .IsUnicode(true);

            modelBuilder.Entity<SpindleBeltPara>()
                .Property(e => e.BeltType)
                .IsUnicode(true);

            modelBuilder.Entity<SpindleBeltPara>()
                .Property(e => e.BeltWidth)
                .IsUnicode(true);

            modelBuilder.Entity<SpindleSrvMotorPara>()
                .Property(e => e.MaxRotationSpeed)
                .IsUnicode(true);

            modelBuilder.Entity<SpindleSrvMotorPara>()
                .Property(e => e.Description)
                .IsUnicode(true);

        }
    }
}
