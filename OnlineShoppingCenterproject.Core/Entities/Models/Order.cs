using OnlineShoppingCenterproject.Core.Interfaces;

namespace OnlineShoppingCenterproject.Core.Entities
{
    public class Order : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Time { get; set; }
        public DateTime OrderDate { get; set; }
        public double total { get; set; }
        public Status status { get; set; }
        public Guid CastomerId { get; set; }
        public Castomer Castomer { get; set; }
    }
}