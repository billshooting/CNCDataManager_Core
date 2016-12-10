namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "步进电机技术数据_TAB")]
    public partial class StepMotorPara
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column("电机类型")]
        public double? TypeOfMotor { get; set; }

        [Column("步距角")]
        public double? AngleOfStep { get; set; }

        [Column("相数")]
        public int? NumberOfPhase { get; set; }

        [Column("拍数")]
        public int? Pace { get; set; }

        [Column("定位转矩")]
        public double? PositionTorque { get; set; }

        [Column("保持转矩")]
        public double? HoldingTorque { get; set; }

        [StringLength(25)]
        [Column("步距角精度")]
        public string StepAngleAccuracy { get; set; }

        [Column("感应系数")]
        public double? InductanceCoefficient { get; set; }

        [Column("额定电压")]
        public double? RatedVoltage { get; set; }

        [Column("额定电流")]
        public double? RatedCurrency { get; set; }

        [Column("绕线电阻")]
        public double? WindingResistance { get; set; }

        [Column("工作允许温度")]
        public double? AllowableWorkingTemperature { get; set; }

        [Column("引线数")]
        public int? NumberOfLeads { get; set; }

        [Column("转动惯量")]
        public double? MomentOfInertia { get; set; }

        [Column("质量")]
        public double? Mass { get; set; }

        [Column(name:"说明",TypeName = "text")]
        public string Description { get; set; }


    }
}
