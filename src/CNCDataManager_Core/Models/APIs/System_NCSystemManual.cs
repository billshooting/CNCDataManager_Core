namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("数控系统手操盘数据_TAB")]
    public partial class NCSystemManual
    {
        [Key]
        [StringLength(50)]
        [Column("型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column("生产厂家")]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        [Column("备注")]
        public string Comments { get; set; }
    }
}
