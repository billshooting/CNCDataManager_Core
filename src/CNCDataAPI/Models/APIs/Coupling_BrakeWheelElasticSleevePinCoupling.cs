namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "带制动轮弹性套柱销联轴器数据_TAB")]
    public partial class BWElasticSlvPinCoup
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column(name: "公称转矩")]
        public double? NominalTorque { get; set; }

        [Column(name: "许用转速")]
        public double? AllowableRotationSpeed { get; set; }

        [Column(name: "轴孔直径d1")]
        public double? DiameterOfShaftHole_d1 { get; set; }

        [Column(name: "轴孔直径d2")]
        public double? DiameterOfShaftHole_d2 { get; set; }

        [Column(name: "轴孔直径dz")]
        public double? DiameterOfShaftHole_dz { get; set; }

        [Column(name: "Y型轴孔长度L")]
        public double? LengthOfYTypedShaftHole_L { get; set; }

        [Column(name: "JJ1Z型轴孔长度L")]
        public double? LengthOfJJ1ZTypedShaftHole_L { get; set; }

        [Column(name: "JJ1Z型轴孔长度L1")]
        public double? LengthOfJJ1ZTypedShaftHole_L1 { get; set; }

        [Column(name: "推荐轴孔长度L")]
        public double? RecommendedLengthOfShaftHole_L { get; set; }

        [Column(name: "尺寸D0")]
        public double? Size_D0 { get; set; }

        [Column(name: "尺寸D")]
        public double? Size_D { get; set; }

        [Column(name: "尺寸B")]
        public double? Size_B { get; set; }

        [Column(name: "尺寸A")]
        public double? Size_A { get; set; }

        [Column(name: "质量")]
        public double? Mass { get; set; }

        [Column(name: "转动惯量")]
        public double? MomentOfInertia { get; set; }

        [Column(name: "刚度")]
        public double? Stiffness { get; set; }

        [Column(name: "说明", TypeName = "text")]
        public string Description { get; set; }
    }
}
