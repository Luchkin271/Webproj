using WebBackend.Core.Models;

namespace WebBackend.DataAccess.Entities
{
    public class ReviewEntity
    {
        public Guid Id { get; set; }
        public UserEntity User { get; set; }
        public Guid UserId { get; set; }
        public string Context { get; set; }
        public GoodEntity ThreadedGood { get; set; }
        public Guid ThreadedGoodId { get; set; }
    }
}
