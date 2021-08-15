namespace MF.Models.ViewModels.Topics
{
    using System.ComponentModel.DataAnnotations;

    using static MF.Models.Common.ModelValidation.Topic;

    public class TopicCreateInputModel
    {
        [Required(ErrorMessage = "NAME E ZADYLJITELEN IDIOT")]
        [MinLength(NameMinLength, ErrorMessage = "NEMOJE PO MALKO OT 2 SIMVOLA")]
        [MaxLength(NameMaxLength, ErrorMessage = "MAX LENGHT 300 KONQ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "NEMOJE BEZ KATEGORIQ ID")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "NEMOJE BEZ CONTENT!!")]
        [MinLength(ContentMinLength, ErrorMessage = "NEMOJE BEZ po-malko simvoli!!")]
        [MaxLength(ContentMaxLength, ErrorMessage = "NEMOJE mnogo simvoli!")]
        public string Content { get; set; }
    }
}
