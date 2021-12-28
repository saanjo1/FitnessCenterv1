namespace FitnessCenter.Data.Entities
{
    public class UserSupplement : BaseEntity
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public int SupplementId { get; set; }
        public Supplement Supplement { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}
