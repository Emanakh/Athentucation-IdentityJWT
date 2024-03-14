namespace Athentucation_IdentityJWT.Models.DTOs
{
	public class RegisterReqDTO
	{
		//مش لازم اعمل ريسبونس
		public string UserName { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
	}
}
