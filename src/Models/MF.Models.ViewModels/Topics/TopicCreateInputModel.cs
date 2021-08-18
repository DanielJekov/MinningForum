namespace MF.Models.ViewModels.Topics
{
    using System.ComponentModel.DataAnnotations;

    using static MF.Models.Common.ModelValidation.Topic;

    public class TopicCreateInputModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Content { get; set; }
    }
}
