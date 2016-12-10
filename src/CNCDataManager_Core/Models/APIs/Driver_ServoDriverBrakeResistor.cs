namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("伺服驱动制动电阻数据_TAB")]
    public partial class SrvDriverBrakeResistor
    {
        [Key]
        [StringLength(50)]
        [Column("型号")]
        public string TypeID { get; set; }

        [Column("生产厂家")]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        [Column("种类")]
        [StringLength(50)]
        public string Category { get; set; }

        [Column("额定功率/kW")]
        public double? RatedPower { get; set; }

        [Column("标称阻值")]
        public double? NominalResistance { get; set; }

        [Column("允许偏差")]
        public double? Tolerance { get; set; }
    }
}
