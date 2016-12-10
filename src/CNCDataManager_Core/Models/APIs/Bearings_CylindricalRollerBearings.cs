namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "圆柱滚子轴承数据_TAB")]
    public partial class CylinRollerBrg
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

        [Column(name: "宽B")]
        public double? Width_B { get; set; }

        [Column(name: "尺寸rsmin")]
        public double? Size_rsmin { get; set; }

        [Column(name: "尺寸r1smin")]
        public double? Size_r1smin { get; set; }

        [Column(name: "尺寸D1max")]
        public double? Size_D1max { get; set; }

        [Column(name: "尺寸D2max")]
        public double? Size_D2max { get; set; }

        [Column(name: "尺寸D3max")]
        public double? Size_D3max { get; set; }

        [Column(name: "尺寸D4max")]
        public double? Size_D4max { get; set; }

        [Column(name: "尺寸D5max")]
        public double? Size_D5max { get; set; }

        [Column(name: "尺寸rasmax")]
        public double? Size_rasmax { get; set; }

        [Column(name: "尺寸rbsmax")]
        public double? Size_rbsmax { get; set; }

        [Column(name: "基本额定动负荷")]
        public double? BasicRatedDynamicLoad { get; set; }

        [Column(name: "基本额定静负荷")]
        public double? BasicRatedStaticLoad { get; set; }

        [Column(name: "脂极限转速")]
        public double? SpeedLimitOfGrease { get; set; }

        [Column(name: "油极限转速")]
        public double? SpeedLimitOfOil { get; set; }

        [Column(name: "轴承轴向刚度")]
        public double? BearingAxialStiffness { get; set; }

        [Column(name: "轴承启动力矩")]
        public double? BearingStartingTorque { get; set; }

        [Column(name: "说明", TypeName = "text")]
        public string Description { get; set; }
    }
}
