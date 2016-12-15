namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "轮毂型联轴器数据_TAB")]
    public partial class HubShapedCoup
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column(name: "公称扭矩")]
        public double? NominalTorque { get; set; }

        [Column(name: "许用转速")]
        public double? AllowableRotationSpeed { get; set; }

        [StringLength(10)]
        [Column(name: "轴孔直径d1")]
        public string DiameterOfShaftHole_d1 { get; set; }

        [StringLength(10)]
        [Column(name: "轴孔直径d2")]
        public string DiameterOfShaftHole_d2 { get; set; }

        [Column(name: "轴孔长度L1")]
        public double? LengthOfShaftHole_L1 { get; set; }

        [Column(name: "轴孔长度L2")]
        public double? LengthOfShaftHole_L2 { get; set; }

        [Column(name: "尺寸L0")]
        public double? Size_L0 { get; set; }

        [Column(name: "尺寸D")]
        public double? Size_D { get; set; }

        [Column(name: "尺寸D1")]
        public double? Size_D1 { get; set; }

        [Column(name: "尺寸D2")]
        public double? Size_D2 { get; set; }

        [Column(name: "尺寸E")]
        public double? Size_E { get; set; }

        [Column(name: "尺寸S")]
        public double? Size_S { get; set; }

        [Column(name: "转动惯量")]
        public double? MomentOfInertia { get; set; }

        [Column(name: "重量")]
        public double? Mass { get; set; }

        [Column(name: "刚度")]
        public double? Stiffness { get; set; }

        [Column(name: "说明", TypeName = "text")]
        public string Description { get; set; }
    }
}
