namespace DNSParser.CoreDataEntities
{
    public class BaseItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime LastModifedDate { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
    }
}