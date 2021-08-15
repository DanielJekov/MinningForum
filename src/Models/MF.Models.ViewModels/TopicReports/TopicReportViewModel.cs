namespace MF.Models.ViewModels.TopicReports
{
    using System.ComponentModel.DataAnnotations;

    public class TopicReportViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
