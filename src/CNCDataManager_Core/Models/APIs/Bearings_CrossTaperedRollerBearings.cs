namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "交叉圆锥滚子轴承数据_TAB")]
    public partial class XTaperedRollerBrg
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Display(Name = "生产厂家")]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "基本额定动载荷")]
        [Column(name: "基本额定动负荷")]
        public double? BasicRatedDynamicLoad { get; set; }

        [Display(Name = "基本额定静载荷")]
        [Column(name: "基本额定静负荷")]
        public double? BasicRatedStaticLoad { get; set; }

        [Display(Name = "脂润滑极限转速")]
        [Column(name: "脂润滑极限转速")]
        public double? SpeedLimitOfGrease { get; set; }

        [Display(Name = "油润滑极限转速")]
        [Column(name: "油润滑极限转速")]
        public double? SpeedLimitOfOil { get; set; }

        [Display(Name = "内径d")]
        [Column(name: "内径d")]
        public double? InnerDiameter_d { get; set; }

        [Display(Name = "直径D")]
        [Column(name: "直径D")]
        public double? Diameter_D { get; set; }

        [Display(Name = "宽度T")]
        [Column(name: "宽T")]
        public double? Width_T { get; set; }

        [Display(Name = "尺寸c")]
        [Column(name: "尺寸c")]
        public double? Size_c { get; set; }

        [Display(Name = "尺寸r")]
        [Column(name: "尺寸r")]
        public double? Size_r { get; set; }

        [Display(Name = "尺寸dl")]
        [Column(name: "尺寸d1")]
        public double? Size_d1 { get; set; }

        [Display(Name = "尺寸Dd1")]
        [Column(name: "尺寸Dd1")]
        public double? Size_Dd1 { get; set; }

        [Display(Name = "尺寸ra")]
        [Column(name: "尺寸ra")]
        public double? Size_ra { get; set; }

        [Display(Name = "质量")]
        [Column(name: "质量")]
        public double? Mass { get; set; }

        [Display(Name = "轴承轴向刚度")]
        [Column(name: "轴承轴向刚度")]
        public double? BearingAxialStiffness { get; set; }

        [Display(Name = "轴承启动转矩")]
        [Column(name: "轴承启动力矩")]
        public double? BearingStartingTorque { get; set; }

        [Column(name: "说明", TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }
    }
}
