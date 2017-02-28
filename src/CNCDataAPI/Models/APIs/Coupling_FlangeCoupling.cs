namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "凸缘联轴器数据_TAB")]
    public partial class FlangeCoup
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

        [Column(name: "许用转速_钢")]
        public double? AllowableRotationSpeed_Steel { get; set; }

        [Column(name: "许用转速_铁")]
        public double? AllowableRotationSpeed_Iron { get; set; }

        [Column(name: "轴孔直径d")]
        public double? DiameterOfShaftHole_d { get; set; }

        [Column(name: "Y型轴孔长度L")]
        public double? LengthOfYTypedShaftHole_L { get; set; }

        [Column(name: "J_J1型轴孔长度L")]
        public double? LengthOfJ_J1TypedShaftHole_L { get; set; }

        [Column(name: "尺寸D")]
        public double? Size_D { get; set; }

        [Column(name: "尺寸D1")]
        public double? Size_D1 { get; set; }

        [Column(name: "螺栓数量")]
        public int? NumberOfBolts { get; set; }

        [StringLength(10)]
        [Column(name: "螺栓直径")]
        public string DiameterOfBolts { get; set; }

        [Column(name: "Y型尺寸L0")]
        public double? SizeOfYTyped_L0 { get; set; }

        [Column(name: "J_J1型尺寸L0")]
        public double? SizeOfJ_J1Typed_L0 { get; set; }

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
