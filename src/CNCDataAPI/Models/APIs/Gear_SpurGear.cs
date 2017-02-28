namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "直齿圆柱齿轮数据_TAB")]
    public partial class SpurGear
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

        [Column(name: "齿顶高系数")]
        public double? AddendumCoefficient { get; set; }

        [Column(name: "齿根高系数")]
        public double? DedendumCoefficient { get; set; }

        [Column(name: "顶隙系数")]
        public double? HeadspaceCoefficient { get; set; }

        [Column(name: "变位系数χ")]
        public double? ModificationCoefficient_X { get; set; }

        [Column(name: "齿宽b")]
        public double? WidthOfTeeth_b { get; set; }

        [Column(name: "顶隙c")]
        public double? HeadSpace_c { get; set; }

        [Column(name: "分度圆直径d")]
        public double? DiameterOfPitchCircle_d { get; set; }

        [Column(name: "基圆直径db")]
        public double? DiameterOfBaseCircle_db { get; set; }

        [Column(name: "齿高h")]
        public double? HeightOfFullTeeth_h { get; set; }

        [Column(name: "齿顶高ha")]
        public double? Addendum_ha { get; set; }

        [Column(name: "齿根高hf")]
        public double? Dedendum_hf { get; set; }

        [Column(name: "齿距p")]
        public double? PitchOfTeeth_p { get; set; }

        [Column(name: "齿厚s")]
        public double? ThicknessOfTeeth_s { get; set; }

        [Column(name: "齿槽厚e")]
        public double? ThicknessOfTeethNarrow_e { get; set; }

        [Column(name: "齿顶圆直径da")]
        public double? DiameterOfAddendumCircle_da { get; set; }

        [Column(name: "齿根圆直径df")]
        public double? DiameterOfDedendumCircle_df { get; set; }

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
