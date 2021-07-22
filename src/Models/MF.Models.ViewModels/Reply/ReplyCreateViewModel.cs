namespace MF.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static MF.Models.Common.ModelValidation.Reply;

    public class ReplyCreateViewModel
    {
        [Required]
        [MinLength(ContentMinLength)]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public int? TopicId { get; set; }
    }
}
