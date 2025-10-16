using WebBackend.Core.Models;

namespace WebBackend.DataAccess.Entities
{
    public class ReviewEntity
    {
        public Guid Id { get; set; }
        public UserEntity User { get; set; }
        public string Context { get; set; }
        public GoodEntity threadedGood { get; set; }
    }
}
