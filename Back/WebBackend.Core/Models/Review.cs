namespace WebBackend.Core.Models
{
    public class Review
    {
        public Guid Id { get; }
        public User User { get; }
        public string Context { get;  }
        private Review(Guid id, User user, string context)
        {
            Id = id;
            User = user;
            Context = context;
        }
        public static (Review Review, string Error) Create(Guid id, User user, string context)
        {
            var error = string.Empty;

            var review = new Review(id, user, context);

            return (review, error);
        }
    }
}
