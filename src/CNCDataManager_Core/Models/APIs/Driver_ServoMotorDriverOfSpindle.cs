namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("主轴系统伺服电机驱动器数据_TAB")]
    public partial class SpindleSrvMotorDriver
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column(name: "连续电流A")]
        public double? ContinuousCurrent { get; set; }

        [Column(name: "短时最大电流A")]
        public int? PeakCurrent { get; set; }

        [StringLength(50)]
        [Column(name: "电源电压V")]
        public string SupplyVoltage { get; set; }

        [Column(name: "最大适配电机功率kW")]
        public int? MaxAdaptableMotorPower { get; set; }

        [Column(name: "最大制动电流A")]
        public int? MaxBrakingCurrent { get; set; }

        [Column("制动电阻推荐阻值Ω")]
        public int? RecommendedBrakeResistance { get; set; }

        [Column("制动电阻推荐功率W")]
        public int? RecommendedBrakePower { get; set; }

        [Column("制动电阻推荐数量")]
        public int? RecommendedBrakeNumber { get; set; }
    }
}
