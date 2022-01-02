namespace FitnessCenter.Data.Entities
{
    public class Discount : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int PhotoId { get; set; }
        public Photo Photo { get; set; }

        public ICollection<UserSupplement> UserSupplements { get; set; }
    }
}
