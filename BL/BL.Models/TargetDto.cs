using System;

namespace BL.Models
{
    public class TargetDto : BaseDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
    }
}