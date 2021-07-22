namespace MF.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static MF.Models.Common.ModelValidation.Category;

    public class CategoryCreateViewModel
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Title { get; set; }
    }
}
