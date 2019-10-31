namespace Store.BL.Models
{
    public class ItemQuery
    {
        public string Name { get; set; }
        public string SelectedSort { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public int Cost { get; set; }
    }
}
