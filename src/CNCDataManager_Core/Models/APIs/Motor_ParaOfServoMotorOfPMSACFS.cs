namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "永磁同步交流进给系统伺服电机技术数据_TAB")]
    public partial class PMSrvMotorPara
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column(name: "额定转矩")]
        public double? RatedTorque { get; set; }

        [Column(name: "最大转矩")]
        public double? MaxTorque { get; set; }

        [Column(name: "额定转速")]
        public int? RatedRotationSpeed { get; set; }

        [Column(name: "最大转速")]
        public int? MaxRotationSpeed { get; set; }

        [Column(name: "转动惯量")]
        public double? MomentOfInertia { get; set; }

        [Column(name: "额定功率")]
        public double? RatedPower { get; set; }

        [Column(name: "静转矩")]
        public double? StaticTorque { get; set; }

        [Column(name: "电机磁极对数")]
        public int? PairsOfMotorPole { get; set; }

        [Column(name: "直流母线电压")]
        public double? DCLinkVoltage { get; set; }

        [Column(name: "额定电流")]
        public double? RatedCurrent { get; set; }

        [Column(name: "最大电流")]
        public double? MaxCurrent { get; set; }

        [Column(name: "机械时间常数")]
        public double? MechanicalTimeConstant { get; set; }

        [Column(name: "质量")]
        public double? Mass { get; set; }

        [Column(name: "定子电阻")]
        public double? StatorResistance { get; set; }

        [Column(name: "定子绕组每项漏电感")]
        public double? LeakageInductanceOfEachPhaseOfStatorWinding { get; set; }

        [Column(name: "反电动势")]
        public double? CounterElectromotiveForce { get; set; }

        [Column(name: "额定频率")]
        public int? RatedFrequency { get; set; }

        [Column(name: "电机转子转动惯量")]
        public double? MomentOfInertiaOfMotorRotor { get; set; }

        [Column(name: "相绕组电阻")]
        public double? ResistanceOfPhaseWinding { get; set; }

        [Column(name: "相绕组电感")]
        public double? InductanceOfPhaseWinding { get; set; }

        [StringLength(10)]
        [Column(name: "是否带抱闸")]
        public string IfWithBrake { get; set; }

        [Column(name: "工作电压")]
        public int? WorkVoltage { get; set; }

        [StringLength(50)]
        [Column(name: "安装方式")]
        public string Installment { get; set; }

        [Column(name: "说明", TypeName = "text")]
        public string Description { get; set; }

    }
}
