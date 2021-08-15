namespace MF.Models.ViewModels.ReplyReports
{
    using System.ComponentModel.DataAnnotations;

    public class ReplyReportCreateInputModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? ReplyId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(450)]
        public string Content { get; set; }
    }
}
