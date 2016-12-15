namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "滚针轴承和推力滚子组合轴承数据_TAB")]
    public partial class NeedleRollerThrustRollerBrg
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column(name: "内径d")]
        public double? InnerDiameter_d { get; set; }

        [Column(name: "直径D")]
        public double? Diameter_D { get; set; }

        [Column(name: "宽T")]
        public double? Width_T { get; set; }

        [Column(name: "尺寸T1")]
        public double? Size_T1 { get; set; }

        [Column(name: "尺寸C")]
        public double? Size_C { get; set; }

        [Column(name: "尺寸D1")]
        public double? Size_D1 { get; set; }

        [Column(name: "尺寸T2")]
        public double? Size_T2 { get; set; }

        [Column(name: "尺寸d11")]
        public double? Size_d11 { get; set; }

        [Column(name: "油孔d1")]
        public double? OilHole_d1 { get; set; }

        [Column(name: "油孔数量")]
        public double? NumberOfOilHole { get; set; }

        [Column(name: "尺寸rsmin")]
        public double? Size_rsmin { get; set; }

        [Column(name: "尺寸r1min")]
        public double? Size_r1min { get; set; }

        [Column(name: "预紧力力矩")]
        public double? PreloadTorque { get; set; }

        [Column(name: "基本额定动负荷")]
        public double? BasicRatedDynamicLoad { get; set; }

        [Column(name: "基本额定静负荷")]
        public double? BasicRatedStaticLoad { get; set; }

        [Column(name: "脂极限转速")]
        public double? SpeedLimitOfGrease { get; set; }

        [Column(name: "油极限转速")]
        public double? SpeedLimitOfOil { get; set; }

        [Column(name: "质量")]
        public double? Mass { get; set; }

        [Column(name: "轴承轴向刚度")]
        public double? BearingAxialStiffness { get; set; }

        [Column(name: "轴承启动力矩")]
        public double? BearingStartingTorque { get; set; }

        [Column(name: "说明",TypeName = "text")]
        public string Description { get; set; }
    }
}
