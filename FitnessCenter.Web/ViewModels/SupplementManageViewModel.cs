using FitnessCenter.Web.Resources;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.ViewModels
{
    public class SupplementManageViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = nameof(Price), ResourceType = typeof(Translations))]
        public double Price { get; set; }

        [Required]
        [Display(Name = nameof(Name), ResourceType = typeof(Translations))]
        public string Name { get; set; }

        [Required]
        [Display(Name = nameof(Description), ResourceType = typeof(Translations))]
        public string Description { get; set; }

        [Required]
        [Display(Name = nameof(Translations.Sponsor), ResourceType = typeof(Translations))]
        public int SponsorId { get; set; }
    }
}
