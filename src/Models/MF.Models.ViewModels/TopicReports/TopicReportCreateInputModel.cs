namespace MF.Models.ViewModels.TopicReports
{
    using System.ComponentModel.DataAnnotations;

    public class TopicReportCreateInputModel
    {
        [Required]
        public int? TopicId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(450)]
        public string Content { get; set; }
    }
}
