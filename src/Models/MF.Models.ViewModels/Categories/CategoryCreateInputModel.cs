namespace MF.Models.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using static MF.Models.Common.ModelValidation.Category;

    public class CategoryCreateInputModel
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
    }
}
