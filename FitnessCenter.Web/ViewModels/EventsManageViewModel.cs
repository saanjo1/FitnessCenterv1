using FitnessCenter.Web.Resources;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.ViewModels
{
    public class EventsManageViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = nameof(Name), ResourceType = typeof(Translations))]
        public string Name { get; set; }

        [Required]
        [Display(Name = nameof(About), ResourceType = typeof(Translations))]
        public string About { get; set; }

        [Required]
        [Display(Name = nameof(Description), ResourceType = typeof(Translations))]
        public string Description { get; set; }

        [Required]
        [Display(Name = nameof(Rate), ResourceType = typeof(Translations))]
        public int Rate { get; set; }

        [Required]
        [Display(Name = nameof(DateTime), ResourceType = typeof(Translations))]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name = nameof(Location), ResourceType = typeof(Translations))]
        public string Location { get; set; }

        [Required]
        [Display(Name = nameof(Translations.User), ResourceType = typeof(Translations))]
        public int UserId { get; set; }

        [Required]
        [Display(Name = nameof(Translations.Photo), ResourceType = typeof(Translations))]
        public IFormFile Photo { get; set; }
    }
}
