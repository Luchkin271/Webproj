namespace WebBackendDataAccess.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
    }
}
