using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.ViewModels
{
    public class UserSupplementsManageViewModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public int SupplementId { get; set; }
        public int UserId { get; set; }
        public int? DiscountId { get; set; }
    }
}
