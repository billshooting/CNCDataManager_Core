namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "直线滚动导轨数据_TAB")]
    public partial class LineRollingGuide
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [StringLength(10)]
        [Column(name: "导轨固定螺栓尺寸")]
        public string SizeOfGuideFixedBolt { get; set; }

        [StringLength(10)]
        [Column(name: "滚子类型")]
        public string RollerType { get; set; }

        [Column(name: "基本动额定负荷C")]
        public double? BasicRatedDynamicLoad_C { get; set; }

        [Column(name: "基本静额定负荷C0")]
        public double? BasicRatedStaticLoad_C0 { get; set; }

        [Column(name: "容许静力矩MR")]
        public double? AllowableStaticMoment_MR { get; set; }

        [Column(name: "容许静力矩Mp")]
        public double? AllowableStaticMoment_Mp { get; set; }

        [Column(name: "容许静力矩M_r")]
        public double? AllowableStaticMoment_M_r { get; set; }

        [Column(name: "滑块质量")]
        public double? MassOfSlider { get; set; }

        [Column(name: "导轨质量")]
        public double? MassOfGuide { get; set; }

        [Column(name: "组件尺寸H")]
        public double? SizeOfComponent_H { get; set; }

        [Column(name: "组件尺寸H1")]
        public double? SizeOfComponent_H1 { get; set; }

        [Column(name: "组件尺寸N")]
        public double? SizeOfComponent_N { get; set; }

        [Column(name: "滑块尺寸W")]
        public double? SizeOfSlider_W { get; set; }

        [Column(name: "滑块尺寸B")]
        public double? SizeOfSlider_B { get; set; }

        [Column(name: "滑块尺寸B1")]
        public double? SizeOfSlider_B1 { get; set; }

        [Column(name: "滑块尺寸C")]
        public double? SizeOfSlider_C { get; set; }

        [Column(name: "滑块尺寸L1")]
        public double? SizeOfSlider_L1 { get; set; }

        [Column(name: "滑块尺寸L")]
        public double? SizeOfSlider_L { get; set; }

        [StringLength(10)]
        [Column(name: "滑块尺寸K")]
        public string SizeOfSlider_K { get; set; }

        [Column(name: "滑块尺寸G")]
        public double? SizeOfSlider_G { get; set; }

        [StringLength(10)]
        [Column(name: "滑块尺寸M")]
        public string SizeOfSlider_M { get; set; }

        [Column(name: "滑块尺寸T")]
        public double? SizeOfSlider_T { get; set; }

        [Column(name: "滑块尺寸T1")]
        public double? SizeOfSlider_T1 { get; set; }

        [StringLength(10)]
        [Column(name: "滑块尺寸T2")]
        public string SizeOfSlider_T2 { get; set; }

        [Column(name: "滑块尺寸H2")]
        public double? SizeOfSlider_H2 { get; set; }

        [Column(name: "滑块尺寸H3")]
        public double? SizeOfSlider_H3 { get; set; }

        [Column(name: "导轨尺寸WR")]
        public double? SizeOfGuide_WR { get; set; }

        [Column(name: "导轨尺寸HR")]
        public double? SizeOfGuide_HR { get; set; }

        [Column(name: "导轨尺寸D")]
        public double? SizeOfGuide_D { get; set; }

        [Column(name: "导轨尺寸h")]
        public double? SizeOfGuide_h { get; set; }

        [Column(name: "导轨尺寸_d")]
        public double? SizeOfGuide__d { get; set; }

        [Column(name: "导轨尺寸P")]
        public double? SizeOfGuide_P { get; set; }

        [Column(name: "导轨尺寸E")]
        public double? SizeOfGuide_E { get; set; }

        [Column(name: "导轨副的摩擦系数")]
        public double? CoefficientOfFrictionGuidPairs { get; set; }

        [Column(name: "粘滞摩擦因子")]
        public double? CoefficientOfViscousFriction { get; set; }

        [Column(name: "说明", TypeName = "text")]
        public string Description { get; set; }
    }
}
