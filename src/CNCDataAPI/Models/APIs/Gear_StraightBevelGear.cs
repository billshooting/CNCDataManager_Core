namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "直齿锥齿轮数据_TAB")]
    public partial class StraightBevelGear
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column(name: "模数m")]
        public double? Modulus_m { get; set; }

        [Column(name: "压力角α")]
        public double? PressureAngle_alphi { get; set; }

        [Column(name: "齿数z")]
        public int? NumberOfTeeth_z { get; set; }

        [Column(name: "当量齿数zv")]
        public double? EquivalentNumberOfTeeth_zv { get; set; }

        [Column(name: "节锥角δ")]
        public double? PitchAngle_delta { get; set; }

        [Column(name: "顶锥角δa")]
        public double? TopBevelAngle_delta_a { get; set; }

        [Column(name: "根锥角δf")]
        public double? RootBevelAngle_delta_f { get; set; }

        [Column(name: "齿顶角θa")]
        public double? AddendumAngle_theta_a { get; set; }

        [Column(name: "齿根角θf")]
        public double? DedendumAngle_theta_f { get; set; }

        [Column(name: "齿顶高系数")]
        public double? AddendumCoefficient { get; set; }

        [Column(name: "顶隙系数")]
        public double? HeadspaceCoefficient { get; set; }

        [Column(name: "顶隙c")]
        public double? HeadSpace_c { get; set; }

        [Column(name: "分度圆直径d")]
        public double? DiameterOfPitchCircle_d { get; set; }

        [Column(name: "齿顶高ha")]
        public double? Addendum_ha { get; set; }

        [Column(name: "齿根高hf")]
        public double? Dedendum_hf { get; set; }

        [Column(name: "齿顶圆直径da")]
        public double? DiameterOfAddendumCircle_da { get; set; }

        [Column(name: "齿根圆直径df")]
        public double? DiameterOfDedendumCircle_df { get; set; }

        [Column(name: "锥距R")]
        public double? ConeDistance_R { get; set; }

        [Column(name: "分度圆齿厚s")]
        public double? ThicknessOfPicthCircleTeeth_s { get; set; }

        [Column(name: "齿面硬度")]
        public double? HardnessOfTeeth { get; set; }

        [StringLength(5)]
        [Column(name: "齿轮精度等级")]
        public string GearAccuracyClass { get; set; }

        [StringLength(25)]
        [Column(name: "材料")]
        public string Material { get; set; }

        [StringLength(25)]
        [Column(name: "热处理方式")]
        public string HeatTreatment { get; set; }

        [Column(name: "齿轮传动效率η")]
        public double? GearTransmissionEfficiency_ita { get; set; }

        [Column(name: "转动惯量")]
        public double? MomentOfInertia { get; set; }

        [Column(name: "说明", TypeName = "text")]
        public string Description { get; set; }
    }
}
