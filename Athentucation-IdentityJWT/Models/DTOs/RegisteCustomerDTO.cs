using static Athentucation_IdentityJWT.Models.DTOs.staticDetails;

namespace Athentucation_IdentityJWT.Models.DTOs
{
	public class RegisteCustomerDTO
	{

		public string fname { get; set; }
		public string lname { get; set; }
		public Gender gender { get; set; }
		public string Email { get; set; }

		public string Password { get; set; }
		public City city { get; set; }
		public Region region { get; set; }
		public string address { get; set; }

	}
}
