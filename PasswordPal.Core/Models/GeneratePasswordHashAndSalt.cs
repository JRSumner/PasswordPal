namespace PasswordPal.Core.Models;

public class HashedPasswordAndSalt
{
	public string Password { get; set; }
	public string Salt { get; set; }
}