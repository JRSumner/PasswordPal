namespace Core.Models
{
    public class Password
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public string Website { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
    }
}
