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
        public string series { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "支持机床类型")]
        [Column(name: "MachineType")]
        public string SupportMachineType { get; set; }

        [Display(Name = "支持通道数")]
        [Column(name: "Channels")]
        public int? SupportChannels { get; set; }

        [Display(Name = "进给轴最大控制轴数")]
        [Column(name: "FeedShafts")]
        public int? MaxNumberOfFeedShafts { get; set; }

        [Display(Name = "主轴最大控制轴数")]
        [Column(name: "Spindels")]
        public int? MaxNumberOfSpindels { get; set; }

        [Display(Name = "最大联轴数")]
        [Column(name: "LinkageAxes")]
        public int? MaxNumberOfLinkageAxis { get; set; }

        public bool? IsMask { get; set; }

        [StringLength(500)]
        public string PictureUrl { get; set; }
    }
}
