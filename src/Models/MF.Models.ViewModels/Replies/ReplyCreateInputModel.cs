namespace MF.Models.ViewModels.Replies
{
    using System.ComponentModel.DataAnnotations;

    using static MF.Models.Common.ModelValidation.Reply;

    public class ReplyCreateInputModel
    {
        [Required]
        [MinLength(ContentMinLength)]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public int? TopicId { get; set; }

        public int? QuoteReplyId { get; set; }
    }
}
