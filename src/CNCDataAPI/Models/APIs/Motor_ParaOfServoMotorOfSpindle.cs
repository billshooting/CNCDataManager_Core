namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "主轴系统伺服电机技术数据_TAB")]
    public partial class SpindleSrvMotorPara
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column("额定功率Kw")]
        public double? RatedPower_Kw { get; set; }

        [Column("额定电流A")]
        public double? RatedCurrent_A { get; set; }

        [Column("额定转矩Nm")]
        public double? RatedTorque_Nm { get; set; }

        [StringLength(50)]
        [Column("额定电压V")]
        public string RatedVoltage_V { get; set; }

        [Column("级数P")]
        public int? Poles_P { get; set; }

        [Column("额定频率Hz")]
        public double? RatedFrequency { get; set; }

        [Column("额定转速r/min")]
        public int? RatedRotationSpeed { get; set; }

        [Column("最大转速r/min")]
        [StringLength(50)]
        public string MaxRotationSpeed { get; set; }

        [Column("转动惯量Kgm2")]
        public double? MomentOfInertia { get; set; }

        [Column("重量Kg")]
        public double? Mass { get; set; }

        [Column("定子电阻Ω")]
        public double? StatorResistance { get; set; }

        [Column("定子自感H")]
        public double? StatorInductance { get; set; }

        [Column("转子电阻Ω")]
        public double? RotorResistance { get; set; }

        [Column("转子自感H")]
        public double? RotorInductance { get; set; }

        [Column("定转子间互感H")]
        public double? SRInductance { get; set; }

        [Column(name: "说明", TypeName = "text")]
        public string Description { get; set; }
    }
}
