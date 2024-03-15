using Athentucation_IdentityJWT.Models;
using Athentucation_IdentityJWT.Models.DTOs;
using Athentucation_IdentityJWT.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Athentucation_IdentityJWT.Controllers
{
	[Route("api/UsersAuth")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserRepo _userRepo;
		private readonly UserManager<AccountIdentity> _userManager;


		public UsersController(IUserRepo userRepo, UserManager<AccountIdentity> userManager)
		{
			_userRepo = userRepo;
			_userManager = userManager;

		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginReqDTO model)
		{
			var LoginRes = await _userRepo.Login(model);
			if (LoginRes.User == null || string.IsNullOrEmpty(LoginRes.Token))
			{
				//return badrequest(model) i don't get why it made a new messsage
				return BadRequest(new { message = "user or pass are in correct" });
				//هنعمل standard apirespone okay feh status 400, fail, errmsg is the msg elly fo2 okay .. and i will sent it in the bad request 
			}

			//هنعمل standard apirespone okay feh status 200, success, resuk=lt is the login res elly fo2 okay .. and i will sent it in the ok request  
			return Ok(LoginRes);
		}

		//public async Task<IActionResult> Register([FromBody] RegisteCustomerDTO model)
		//{
		//	//bool isUserNameUnique = _userRepo.IsUniqueUser(fn);
		//	//if (!isUserNameUnique)
		//	//{
		//	//	//هنعمل standard apirespone okay feh status 400, fail, errmsg is the msg in the bad request 
		//	//	return BadRequest();
		//	//}
		//	var user = await _userRepo.Register(model);
		//	if (user == null)
		//	{
		//		return BadRequest(); //standard response 
		//	}
		//	return Ok();
		//}

		[HttpPost("Register")]

		public async Task<IActionResult> Register(RegisteCustomerDTO customerDTO)
		{
			var customer = new AccountIdentity
			{
				fname = customerDTO.fname,
				Email = customerDTO.Email

			};

			//var creationResult = await _userManager.CreateAsync(customer, customerDTO.Password);

			//if (!creationResult.Succeeded)
			//{
			//	return BadRequest();
			//}

			//var userClaims = new List<Claim>
			//{
			//	new Claim(ClaimTypes.NameIdentifier, customerDTO.fname),
			//	new Claim(ClaimTypes.Email, customerDTO.Email),
			//	new Claim(ClaimTypes.Role, "Customer"),
			//};
			var d = await _userManager.RegisterUserAsync(customerDTO);

			return Ok("ok");




		}

	}
}
