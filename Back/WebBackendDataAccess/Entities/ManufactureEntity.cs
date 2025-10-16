namespace WebBackend.DataAccess.Entities
{
    public class ManufactureEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GoodEntity> Goods { get; set; }
    }
}
