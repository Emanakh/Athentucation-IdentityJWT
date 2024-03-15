using Microsoft.AspNetCore.Identity;
using System.Runtime.ConstrainedExecution;
using System;
using static Athentucation_IdentityJWT.Models.DTOs.staticDetails;

namespace Athentucation_IdentityJWT.Models
{
	public class AccountIdentity : IdentityUser
	{
		public string fname { get; set; }
		public string lname { get; set; }
		public Gender gender { get; set; }
		public City city { get; set; }
		public Region region { get; set; }
		public string address { get; set; }

		public string Location { get; set; }

		public string Bio { get; set; }
		public CareerLevel careerlevel { get; set; }
		public int yearsofExperience { get; set; }
		public Jobtitle job { get; set; }

		public whatucando ucando { get; set; }
		public JobLocation loc { get; set; }
		public int priceH { get; set; }
		public int priceD { get; set; }



	}
}
