using FitnessCenter.Data.Entities;
using FitnessCenter.Web.Resources;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.ViewModels
{
    public class SponsorsManageViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = nameof(Name), ResourceType = typeof(Translations))]
        public string Name { get; set; }

        [Display(Name = nameof(Translations.User), ResourceType = typeof(Translations))]
        public int UserId{ get; set; }
        [Required]
        [Display(Name = nameof(Description), ResourceType = typeof(Translations))]
        public string Description { get; set; }

        [Required]
        [Display(Name = nameof(Translations.Photo), ResourceType = typeof(Translations))]
        public IFormFile Photo { get; set; }

    }
}
