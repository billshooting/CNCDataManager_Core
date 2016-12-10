namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "回转工作台数据_TAB")]
    public partial class RotaryTable
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [StringLength(25)]
        [Column("工作台尺寸")]
        public string SizeOfWorkingTable { get; set; }

        [Column("工作台高")]
        public double? HeightOfWorkingTable { get; set; }

        [StringLength(25)]
        [Column("中心定位孔尺寸")]
        public string SizeOfCentrallyLocatedHole { get; set; }

        [Column("工作台T形槽宽度")]
        public double? WidthOfTableTSlot { get; set; }

        [StringLength(25)]
        [Column("总传动比")]
        public string TotalDriveRatio { get; set; }

        [Column("最小分度单位")]
        public double? MiniScaleUnit { get; set; }

        [Column("伺服电机扭矩")]
        public double? TorqueOfServoMotor { get; set; }

        [Column("伺服电机功率")]
        public double? PowerOfServoMotor { get; set; }

        [StringLength(25)]
        [Column("分度精度")]
        public string PitchAccuracy { get; set; }

        [StringLength(25)]
        [Column("重复精度")]
        public string RepeatAccuracy { get; set; }

        [Column("水平承载能力")]
        public double? LevelCarryingCapacity { get; set; }

        [Column(name: "说明", TypeName = "text")]
        public string Description { get; set; }
    }
}
