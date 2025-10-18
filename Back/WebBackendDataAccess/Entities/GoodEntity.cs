
namespace WebBackend.DataAccess.Entities
{
    public class GoodEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string IconURL { get; set; }
        public ManufactureEntity Manufacturer { get; set; }
        public List<ReviewEntity> Reviews { get; set; }
        public string Specifications { get; set; }
        public Guid ManufacturerId { get; set; }
    }
}
