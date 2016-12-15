namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("电缆辅件数据_TAB")]
    public partial class Cables
    {
        [Key]
        [StringLength(50)]
        [Column("型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column("类别")]
        public string Category { get; set; }

        [StringLength(50)]
        [Column("说明")]
        public string Description { get; set; }
    }
}
