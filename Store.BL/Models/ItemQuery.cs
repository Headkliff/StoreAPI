using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BL.Models
{
    public class ItemQuery
    {
        public string Name { get; set; }
        public string SelectedSort { get; set; }
        public int PageNumber { get; set; }
    }
}
