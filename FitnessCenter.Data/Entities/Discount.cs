namespace FitnessCenter.Data.Entities
{
    public class Discount : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public ICollection<UserSupplement> UserSupplements { get; set; }
    }
}
