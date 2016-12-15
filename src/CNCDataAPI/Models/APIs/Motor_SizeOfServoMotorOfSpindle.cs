namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("主轴系统伺服电机尺寸数据_TAB")]
    public partial class SpindleSrvMotorSize
    {
        [Key]
        [StringLength(50)]
        [Column("型号")]
        public string TypeID { get; set; }

        [Column("生产厂家")]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        [Column("尺寸Bmm")]
        public double? Size_B { get; set; }

        [Column("尺寸Cmm")]
        public double? Size_C { get; set; }

        [Column("尺寸Kmm")]
        public double? Size_K { get; set; }

        [Column("尺寸Fmm")]
        public double? Size_F { get; set; }

        [Column("尺寸Gmm")]
        public double? Size_G { get; set; }

        [Column("尺寸Dmm")]
        public double? Size_D { get; set; }

        [Column("尺寸E1mm")]
        public double? Size_E1 { get; set; }

        [Column("尺寸E2mm")]
        public double? Size_E2 { get; set; }

        [Column("尺寸E3mm")]
        public double? Size_E3 { get; set; }
    }
}
