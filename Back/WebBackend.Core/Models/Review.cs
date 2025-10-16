namespace WebBackend.Core.Models
{
    public class Review
    {
        public Guid Id { get; }
        public Good ThreadedGood { get; }
        public User User { get; }
        public string Context { get;  }
        private Review(Guid id, User user, string context, Good threadedGood)
        {
            Id = id;
            User = user;
            Context = context;
            ThreadedGood = threadedGood;
        }
        public static (Review Review, string Error) Create(Guid id, User user, string context, Good threadedGood)
        {
            var error = string.Empty;

            var review = new Review(id, user, context, threadedGood);

            return (review, error);
        }
    }
}
