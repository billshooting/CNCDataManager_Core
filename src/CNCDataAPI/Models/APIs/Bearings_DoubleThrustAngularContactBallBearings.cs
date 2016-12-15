namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "双向推力角接触球轴承数据_TAB")]
    public partial class DoubleThrustAngContactBallBrg
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

        [Column(name: "尺寸d1")]
        public double? Size_d1 { get; set; }

        [Column(name: "宽H")]
        public double? Width_H { get; set; }

        [Column(name: "尺寸A")]
        public double? Size_A { get; set; }

        [Column(name: "尺寸r")]
        public double? Size_r { get; set; }

        [Column(name: "尺寸r1min")]
        public double? Size_r1min { get; set; }

        [Column(name: "尺寸W")]
        public double? Size_W { get; set; }

        [Column(name: "尺寸dΦ")]
        public double? Size_d_Phi { get; set; }

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

        [Column(name: "尺寸Ds")]
        public double? Size_Ds { get; set; }

        [Column(name: "尺寸ds1")]
        public double? Size_ds1 { get; set; }

        [Column(name: "尺寸rs")]
        public double? Size_rs { get; set; }

        [Column(name: "尺寸rs1")]
        public double? Size_rs1 { get; set; }

        [Column(name: "轴承轴向刚度")]
        public double? BearingAxialStiffness { get; set; }

        [Column(name: "轴承启动力矩")]
        public double? BearingStartingTorque { get; set; }

        [Column(name: "说明", TypeName = "text")]
        public string Description { get; set; }
    }
}
