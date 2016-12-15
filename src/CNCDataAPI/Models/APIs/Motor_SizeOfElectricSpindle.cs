namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "电主轴尺寸数据_TAB")]
    public partial class ElecSpindleSize
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column("尺寸C(mm)")]
        public double? Size_C { get; set; }

        [Column("尺寸D1(mm)")]
        public double? Size_D1 { get; set; }

        [Column("尺寸D2(mm)")]
        public double? Size_D2 { get; set; }

        [Column("尺寸J(mm)")]
        public double? Size_J { get; set; }

        [Column("尺寸K(mm)")]
        public double? Size_K { get; set; }

        [Column("尺寸L(mm)")]
        public double? Size_L { get; set; }

        [Column("尺寸M(mm)")]
        public double? Size_M { get; set; }

        [Column("尺寸N(mm)")]
        public double? Size_N { get; set; }

    }
}
