namespace CNCDataManager.Models.APIs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CNCSystem")]
    public partial class NCSystem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "型号")]
        [Column(name: "ModelNum")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        [Display(Name = "系列")]
        public string Series { get; set; }

        [Required]
        [StringLength(50)]
        [Column(name: "MachineType")]
        public string SupportMachineType { get; set; }

        [Column(name: "Channels")]
        public int? SupportChannels { get; set; }

        [Column(name: "FeedShafts")]
        public int? MaxNumberOfFeedShafts { get; set; }

        [Column(name: "Spindels")]
        public int? MaxNumberOfSpindels { get; set; }

        [Column(name: "LinkageAxes")]
        public int? MaxNumberOfLinkageAxis { get; set; }

        public bool? IsMask { get; set; }

        [StringLength(500)]
        public string PictureUrl { get; set; }
    }
}
