namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("主轴同步带尺寸数据_TAB")]
    public partial class SpindleBeltSize
    {
        [Key]
        [StringLength(50)]
        [Column("带型")]
        public string TypeID { get; set; }

        [Column("齿距")]
        public double? Pitch { get; set; }

        [Column("2F")]
        [StringLength(50)]
        public string C2F { get; set; }

        public double? Lr { get; set; }

        [Column("小h")]
        public double? Small_h { get; set; }

        [Column("大H")]
        public double? Big_H { get; set; }

        public double? Rr { get; set; }

        public double? Ra { get; set; }

        [Column("单位重量g/m")]
        public double? Density { get; set; }
    }
}
