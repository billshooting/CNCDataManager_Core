namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("主轴同步带技术数据_TAB")]
    public partial class SpindleBeltPara
    {
        [Key]
        [StringLength(50)]
        [Column("型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column("生产厂家")]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        [Column("材料")]
        public string Material { get; set; }

        [StringLength(50)]
        [Column("带型")]
        public string BeltType { get; set; }

        [StringLength(10)]
        [Column("带宽mm")]
        public string BeltWidth { get; set; }

        [Column("带长mm")]
        public double? BeltLength { get; set; }

        [Column("齿数")]
        public int? TeethNumber { get; set; }

        [Column("节距mm")]
        public double? Pitch { get; set; }

        [Column("截面面积m^2")]
        public double? SectionalArea { get; set; }

        [Column("弹性模量Pa")]
        public double? ElasticModulus { get; set; }

        [Column("紧边长度mm")]
        public double? TightSideLength { get; set; }

        [StringLength(50)]
        [Column("传动力矩")]
        public string DriveTorque { get; set; }
    }
}
