namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("实心滚珠丝杠螺母副数据_TAB")]
    public partial class SolidBallScrewNutPairs
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column("基本额定动载荷Ca")]
        public double? BasicRatedDynamicLoad_Ca { get; set; }

        [Column("基本额定静载荷Coa")]
        public double? BasicRatedStaticLoad_Coa { get; set; }

        [Column("刚度")]
        public double? Stiffness { get; set; }

        [Column("公称直径d0")]
        public double? NominalDiameter_d0 { get; set; }

        [Column("公称导程Ph0")]
        public double? NominalLead_Ph0 { get; set; }

        [Column("丝杠外径d1")]
        public double? OuterDiameterOfScrew_d1 { get; set; }

        [Column("钢球直径DW")]
        public double? DiameterOfSteelBall_DW { get; set; }

        [Column("丝杠底径d2")]
        public double? BottomDiameterOfScrew_d2 { get; set; }

        [Column("轴承内径配合直径")]
        public double? AdaptableDiameterWithBearing { get; set; }

        [Column("联轴器轴孔配合直径")]
        public double? AdaptableDiameterWithCouplingShaftHole { get; set; }

        [Column("极限转速")]
        public int? LimitRotationSpeed { get; set; }

        [Column("两双推轴承之间的距离")]
        public double? DistanceBetweenTwoPushBearings { get; set; }

        [Column("丝杠总长L")]
        public double? LengthOfScrew_L { get; set; }

        [Column("循环总圈数n")]
        public int? TotalCycleTurns_n { get; set; }

        [Column("尺寸D3")]
        public double? Size_D3 { get; set; }

        [Column("尺寸D4")]
        public double? Size_D4 { get; set; }

        [Column("尺寸D5")]
        public double? Size_D5 { get; set; }

        [Column("尺寸D6")]
        public double? Size_D6 { get; set; }

        [Column("尺寸D7")]
        public double? Size_D7 { get; set; }

        [Column("尺寸L1")]
        public double? Size_L1 { get; set; }

        [Column("螺钉孔个数m")]
        public int? NumberOfScrewHoles_m { get; set; }

        [Column("密度")]
        public double? Density { get; set; }

        [Column("弹性模量")]
        public double? ElasticModulus { get; set; }

        [Column("剪切弹性模量")]
        public double? ShearElasticModulus { get; set; }

        [Column("丝杠与螺母结合面径向阻尼系数")]
        public double? RadialDampingCoefficient { get; set; }

        [Column("滚珠丝杠副处的粘滞摩擦因素")]
        public double? ViscousFrictionFactor { get; set; }

        [Column("滚珠丝杠预紧效率")]
        public double? EfficiencyOfBallScrewPreload { get; set; }

        [Column(name: "说明",TypeName = "text")]
        public string Description { get; set; }
    }
}
