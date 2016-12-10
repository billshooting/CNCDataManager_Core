namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("普通圆柱蜗轮蜗杆数据_TAB")]
    public partial class CommonCylinWormGear
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column(name: "模数m")]
        public double? Modulus_m { get; set; }

        [Column("齿形角α")]
        public double? ProfileAngle_alphi { get; set; }

        [Column("中心距a")]
        public double? CentralDistance_a { get; set; }

        [Column("蜗杆头数z1")]
        public int? NumberOfWormTeeth_z1 { get; set; }

        [Column("蜗轮齿数z2")]
        public int? NumberOfWormWheelTeeth_z2 { get; set; }

        [Column("传动比i")]
        public double? DriveRatio_i { get; set; }

        [Column("变位系数χ2")]
        public double? ModificationCoefficient_X2 { get; set; }

        [Column("蜗杆分度圆直径d1")]
        public double? DiameterOfPitchCircleOfWorm_d1 { get; set; }

        [Column("蜗杆轴向齿距px")]
        public double? AxialPitchOfWorm_px { get; set; }

        [Column("蜗杆导程pz")]
        public double? LeadOfWorm_pz { get; set; }

        [Column("蜗轮分度圆柱导程角γ")]
        public double? LeadAngleOfPitchCircleOfWormWheel_gama { get; set; }

        [Column("顶隙c")]
        public double? HeadSpace_c { get; set; }

        [Column("蜗杆齿顶高ha1")]
        public double? WormAddendum_ha1 { get; set; }

        [Column("蜗杆齿根高hf1")]
        public double? WormDedendum_hf1 { get; set; }

        [Column("蜗杆齿高h1")]
        public double? TeethHeightOfWorm_h1 { get; set; }

        [Column("蜗杆齿顶圆直径da1")]
        public double? DiameterOfAddendumCircleOfWorm_da1 { get; set; }

        [Column("蜗杆齿根圆直径df1")]
        public double? DiameterOfAddendumCircleOfWorm_df1 { get; set; }

        [Column("蜗杆螺纹部分长度b1")]
        public double? LengthOfScrewThreadOfWorm_b1 { get; set; }

        [Column("蜗杆轴向齿厚Sx1")]
        public double? AxialThicknessOfWorm_Sx1 { get; set; }

        [Column("蜗杆法向齿厚Sn1")]
        public double? NormalThicknessOfWorm_Sn1 { get; set; }

        [Column("蜗轮分度圆直径d2")]
        public double? DiameterOfPitchCircleOfWormWheel_d2 { get; set; }

        [Column("蜗轮齿顶高ha2")]
        public double? AddendumOfWormWheel_ha2 { get; set; }

        [Column("蜗轮齿根高hf2")]
        public double? DedendumOfWormWheel_hf2 { get; set; }

        [Column("蜗轮喉圆直径da2")]
        public double? DiameterOfThroatCircleOfWormWheel_da2 { get; set; }

        [Column("蜗轮齿宽b2")]
        public double? TeethWidthOfWormWheel_b2 { get; set; }

        [Column("蜗轮齿根圆弧半径R1")]
        public double? RadiusOfRootTeethOfWormWheel_R1 { get; set; }

        [Column("蜗轮齿顶圆弧半径R2")]
        public double? RadiusOfRootTeethOfWormWheel_R2 { get; set; }

        [Column("蜗轮顶圆直径de2")]
        public double? DiameterOfAddendumCircleOfWormWheel_de2 { get; set; }

        [Column("蜗轮轮缘宽度B")]
        public double? FlangeWidthOfWormWheel_B { get; set; }

        [Column("齿廓圆弧中心到蜗杆齿厚对称线的距离l1")]
        public double? Length_l1 { get; set; }

        [Column("齿廓圆弧中心到蜗杆齿厚轴线的距离l2")]
        public double? Length_l2 { get; set; }

        [Column("传动效率η")]
        public double? TransmissionEfficiency_ita { get; set; }

        [Column("蜗杆轴粘滞摩擦")]
        public double? ViscousFrictionOfWormShaft { get; set; }

        [Column("蜗轮转动惯量")]
        public double? MomentOfInertiaOfWormWheel { get; set; }

        [Column("蜗杆转动惯量")]
        public double? MomentOfInertiaOFWorm { get; set; }

        [Column("蜗杆轴的扭转刚度")]
        public double? TorsionalStiffnessOfWormShaft { get; set; }

        [StringLength(25)]
        [Column("材料")]
        public string Material { get; set; }

        [StringLength(25)]
        [Column("铸造方法")]
        public string CastingProcess { get; set; }

        [Column(name: "说明", TypeName = "text")]
        public string Description { get; set; }
    }
}
