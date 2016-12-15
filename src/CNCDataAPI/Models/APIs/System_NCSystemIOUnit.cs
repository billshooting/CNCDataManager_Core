namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("数控系统IO单元数据_TAB")]
    public partial class NCSystemIOUnit
    {
        [Key]
        [StringLength(50)]
        [Column("型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column("生产厂家")]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        [Column("种类")]
        public string Category { get; set; }

        [StringLength(50)]
        [Column("备注")]
        public string Comments { get; set; }
    }
}
