namespace WebBackend.Core.Models
{
    public class Manufacture
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public List<Good> Goods { get; }
        private Manufacture(Guid Id, string Name, string Description, List<Good> Goods)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Goods = Goods;
        }
        public static (Manufacture Manufacture, string Error) Create(Guid Id, string Name, string Description, List<Good> Goods)
        {
            var error = string.Empty;

            var manufacture = new Manufacture(Id, Name, Description, Goods);

            return (manufacture, error);
        }
    }
}
