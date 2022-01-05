
namespace FitnessCenter.Data.Entities
{
    public class Photo : BaseEntity
    {
        public byte[] Data { get; set; }

        public ICollection<Supplement> Supplements { get; set; }
        public ICollection<Sponsor> Sponsors { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Equipment> Equipment { get; set; }
        public ICollection<Discount> Discount { get; set; }
        public ICollection<Contact> Contact { get; set; }
    }
}
