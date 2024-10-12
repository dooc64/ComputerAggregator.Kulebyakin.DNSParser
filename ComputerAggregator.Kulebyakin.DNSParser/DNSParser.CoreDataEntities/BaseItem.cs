using System.Text.Json.Serialization;

namespace DNSParser.CoreDataEntities
{
    public class BaseItem
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public DateTime LastModifedDate { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public string ImageUrl { get; set; }
        public string Uri { get; set; }
    }
}