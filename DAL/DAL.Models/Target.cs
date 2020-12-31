using System;

namespace DAL.Models
{
    public class Target : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
    }
}