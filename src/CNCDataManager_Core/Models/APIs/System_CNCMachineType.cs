namespace CNCDataManager.Models.APIs
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CNCMachineType")]
    public partial class CNCMachineType
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MachineType { get; set; }

        [Required]
        [StringLength(25)]
        public string MainType { get; set; }

        [Required]
        [StringLength(25)]
        public string DetailType { get; set; }

        [StringLength(255)]
        public string ThumbNailUrl { get; set; }
    }
}
