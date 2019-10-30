using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BL.Models
{
    public class ItemViewList
    {
        public ICollection<ItemView> Items { get; set; }
        public long Count { get; set; }
    }
}
