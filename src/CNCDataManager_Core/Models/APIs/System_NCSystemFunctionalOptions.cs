namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("数控系统功能选项_TAB")]
    public partial class NCSystemFunctionalOptions
    {
        [Key]
        [StringLength(50)]
        [Column("型号")]
        public string TypeID { get; set; }

        [StringLength(100)]
        [Column("功能选项")]
        public string FunctionalOptions { get; set; }
    }
}
