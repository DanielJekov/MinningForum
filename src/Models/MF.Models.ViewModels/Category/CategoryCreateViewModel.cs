namespace MF.Models.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;

    using static MF.Models.Common.ModelValidation.Category;

    public class CategoryCreateViewModel
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
    }
}
