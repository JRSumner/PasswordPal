using PasswordPal.Core.Models;

namespace Core.Models.Responses
{
	public class UserResponse
	{
		public User? User { get; set; }
		public string? Response { get; set; }
		public bool Success { get; set; }
	}
}
