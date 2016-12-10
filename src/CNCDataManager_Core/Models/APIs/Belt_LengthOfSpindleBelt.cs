namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("主轴同步带带长数据_TAB")]
    public partial class SpindleBeltLength
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("长度代号")]
        public int LengthID { get; set; }

        [Column("带长")]
        public double LengthOfBelt { get; set; }

        [Column("MXL齿数")]
        public int? MXL_TeethNumber { get; set; }

        [Column("XXL齿数")]
        public int? XXL_TeethNumber { get; set; }

        [Column("XL齿数")]
        public int? XL_TeethNumber { get; set; }

        [Column("L齿数")]
        public int? L_TeethNumber { get; set; }

        [Column("H齿数")]
        public int? H_TeethNumber { get; set; }

        [Column("XH齿数")]
        public int? XH_TeethNumber { get; set; }

        [Column("XXH齿数")]
        public int? XXH_TeethNumber { get; set; }
    }
}
