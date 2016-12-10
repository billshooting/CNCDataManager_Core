namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "永磁同步交流进给系统伺服电机驱动器数据_TAB")]
    public partial class PMSrvMotorDriver
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column(name: "连续电流")]
        public double? ContinuousCurrent { get; set; }

        [Column(name: "短时最大电流")]
        public double? PeakCurrent { get; set; }

        [StringLength(50)]
        [Column(name: "电源电压")]
        public string SupplyVoltage { get; set; }

        [Column(name: "最大适配电机功率")]
        public double? MaxAdaptableMotorPower { get; set; }

        [Column(name: "最大制动电流")]
        public double? MaxBrakingCurrent { get; set; }

        [StringLength(50)]
        [Column(name: "外接制动电阻")]
        public string ExternalBrakingResistance { get; set; }

        [Column(name: "PWM周期")]
        public double? CycleOfPWM { get; set; }

        [StringLength(50)]
        [Column(name: "直流供电电压")]
        public string SupplyVoltageOfDC { get; set; }

        [Column(name: "位置环增益")]
        public double? PositionLoopGain { get; set; }

        [Column(name: "速度环增益")]
        public double? SpeedLoopGain { get; set; }

        [Column(name: "速度环积分常数")]
        public double? IntegralConstantOfSpeedLoop { get; set; }

        [Column(name: "d轴电流增益值")]
        public double? DaxisCurrentGain { get; set; }

        [Column(name: "d轴电流积分常数")]
        public double? IntegralConstantOfDaxisCurrent { get; set; }

        [Column(name: "说明", TypeName = "text")]
        public string Description { get; set; }
    }
}
