namespace MF.Models.ViewModels.Topic
{
    using System.ComponentModel.DataAnnotations;

    using static MF.Models.Common.ModelValidation.Topic;

    public class TopicCreateViewModel
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Title { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(1000)]
        public string Content { get; set; }
    }
}
