﻿namespace FitnessCenter.Data.Entities
{
    public class Announcement : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
