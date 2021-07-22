namespace MF.Models.ViewModels
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
    }
}
