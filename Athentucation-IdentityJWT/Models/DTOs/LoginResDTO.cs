namespace Athentucation_IdentityJWT.Models.DTOs
{
	public class LoginResDTO
	{
		public UserDTO User { get; set; }
		public string Role { get; set; }
		public string Token { get; set; }
	}
}
