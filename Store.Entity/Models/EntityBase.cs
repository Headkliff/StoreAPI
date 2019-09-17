using System;

namespace Store.Entity.Models
{
    public class EntityBase
    {
        
        public long Id { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
    }
}
