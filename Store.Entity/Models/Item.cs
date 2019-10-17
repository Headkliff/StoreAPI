namespace Store.Entity.Models
{
    public class Item : EntityBase
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public float Cost { get; set; }
    }
}
