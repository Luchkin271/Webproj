namespace WebBackend.Core.Models
{
    public class User
    {
        public Guid Id { get;}
        public string Name { get; }
        public string Email { get; }
        public bool IsEmailConfirmed { get; }
        public string PasswordHash { get; }
        public List<Review> Reviews { get; }
        private User(Guid Id, string Name, string Email, bool IsEmailConfirmed, string PasswordHash, List<Review> reviews)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.IsEmailConfirmed = IsEmailConfirmed;
            this.PasswordHash = PasswordHash;
            Reviews = reviews;
        }
        public static (User User, string Error) Create(Guid Id, string Name, string Email, bool IsEmailConfirmed, string PasswordHash, List<Review> reviews)
        {
            var error = string.Empty;

            var user = new User(Id, Name, Email, IsEmailConfirmed, PasswordHash, reviews);

            return (user, error);
        }

    }
}
