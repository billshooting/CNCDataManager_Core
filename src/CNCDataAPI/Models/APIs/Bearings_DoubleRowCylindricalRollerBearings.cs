namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "双列圆柱滚子轴承数据_TAB")]
    public partial class DoubleRowCylinRollerBrg
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column(name: "基本额定动负荷")]
        public double? BasicRatedDynamicLoad { get; set; }

        [Column(name: "基本额定静负荷")]
        public double? BasicRatedStaticLoad { get; set; }

        [Column(name: "脂润滑极限转速")]
        public double? SpeedLimitOfGrease { get; set; }

        [Column(name: "油润滑极限转速")]
        public double? SpeedLimitOfOil { get; set; }

        [Column(name: "尺寸d")]
        public double? Size_d { get; set; }

        [Column(name: "尺寸Dd")]
        public double? Size_Dd { get; set; }

        [Column(name: "尺寸B")]
        public double? Size_B { get; set; }

        [Column(name: "尺寸Ew")]
        public double? Size_Ew { get; set; }

        [Column(name: "尺寸r")]
        public double? Size_r { get; set; }

        [Column(name: "尺寸da")]
        public double? Size_da { get; set; }

        [Column(name: "尺寸da1")]
        public double? Size_da1 { get; set; }

        [Column(name: "尺寸Damax")]
        public double? Size_Damax { get; set; }

        [Column(name: "尺寸Damin")]
        public double? Size_Damin { get; set; }

        [Column(name: "尺寸Ra")]
        public double? Size_Ra { get; set; }

        [Column(name: "质量")]
        public double? Mass { get; set; }

        [Column(name: "轴承轴向刚度")]
        public double? BearingAxialStiffness { get; set; }

        [Column(name: "轴承启动力矩")]
        public double? BearingStartingTorque { get; set; }

        [Column(name: "说明", TypeName = "text")]
        public string Description { get; set; }
    }
}
