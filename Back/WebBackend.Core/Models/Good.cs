namespace WebBackend.Core.Models
{
    public class Good
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Price { get; }
        public string Description { get; }
        public string IconURL { get; }
        public Manufacture Manufacturer { get; }
        public List<Review> Reviews { get; }
        public List<Specification> Specifications{ get; }
        private Good(Guid id, string name, string price, string description, string iconURL, Manufacture manufacturer, List<Review> reviews, List<Specification> specifications)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            IconURL = iconURL;
            Manufacturer = manufacturer;
            Reviews = reviews;
            Specifications = specifications;
        }
        public static (Good Good, string Error) Create(Guid id, string name, string price, string description, string iconURL, Manufacture manufacturer, List<Review> reviews, List<Specification> specifications)
        {
            var error = string.Empty;

            var good = new Good(id, name, price, description, iconURL, manufacturer, reviews, specifications);

            return (good, error);
        }
    }
}
