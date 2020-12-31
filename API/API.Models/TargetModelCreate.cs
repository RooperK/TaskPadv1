using System;

namespace API.Models
{
    public class TargetModelCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
    }
}