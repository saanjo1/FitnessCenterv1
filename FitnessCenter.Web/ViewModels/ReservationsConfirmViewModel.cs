using FitnessCenter.Web.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.ViewModels
{
    public class ReservationsConfirmViewModel
    {
        public int Id { get; set; }
        public bool Confirmed { get; set; }

    }
}
