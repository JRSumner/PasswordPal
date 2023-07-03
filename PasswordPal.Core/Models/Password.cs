namespace PasswordPal.Core.Models
{
    public class Password
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public string Website { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public int UserId { get; set; }
    }
}
