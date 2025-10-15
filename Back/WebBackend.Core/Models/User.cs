namespace WebBackend.Core.Models
{
    public class User
    {
        public Guid Id { get;}
        public string Name { get; }
        public string Email { get; }
        public bool IsEmailConfirmed { get; }
        public string PasswordHash { get; }
        private User(Guid Id, string Name, string Email, bool IsEmailConfirmed, string PasswordHash)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.IsEmailConfirmed = IsEmailConfirmed;
            this.PasswordHash = PasswordHash;
        }
        public static (User User, string Error) Create(Guid Id, string Name, string Email, bool IsEmailConfirmed, string PasswordHash)
        {
            var error = string.Empty;

            var user = new User(Id, Name, Email, IsEmailConfirmed, PasswordHash);

            return (user, error);
        }

    }
}
