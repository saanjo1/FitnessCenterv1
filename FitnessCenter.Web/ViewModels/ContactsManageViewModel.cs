using FitnessCenter.Data.Entities;
using FitnessCenter.Web.Resources;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.ViewModels
{
    public class ContactsManageViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = nameof(Name), ResourceType = typeof(Translations))]
        public string Name { get; set; }

        [Required]
        [Display(Name = nameof(Value), ResourceType = typeof(Translations))]
        public string Value { get; set; }

        [Required]
        [Display(Name = nameof(Translations.User), ResourceType = typeof(Translations))]
        public int UserId { get; set; }

        [Required]
        [Display(Name = nameof(Translations.Photo), ResourceType = typeof(Translations))]
        public IFormFile Photo { get; set; }
    }
}
