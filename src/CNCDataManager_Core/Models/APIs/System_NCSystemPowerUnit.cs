namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("数控系统电源模块数据_TAB")]
    public partial class NCSystemPowerUnit
    {
        [Key]
        [StringLength(50)]
        [Column("型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column("生产厂家")]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        [Column("名称")]
        public string Name { get; set; }

        [StringLength(50)]
        [Column("备注")]
        public string Comments { get; set; }
    }
}
