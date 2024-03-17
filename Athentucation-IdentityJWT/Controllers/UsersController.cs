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


		public UsersController(IUserRepo userRepo)
		{
			_userRepo = userRepo;

		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginReqDTO model)
		{
			var LoginRes = await _userRepo.Login(model);
			if (LoginRes.User == null || string.IsNullOrEmpty(LoginRes.Token))
			{

				return BadRequest(new { message = "user or pass are in correct" });

			}


			return Ok(LoginRes);
		}



		[HttpPost("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterReqDTO model)
		{
			bool isUserNameUnique = _userRepo.IsUniqueUser(model.UserName);
			if (!isUserNameUnique)
			{
				return BadRequest();
			}
			var user = await _userRepo.Register(model);
			if (user == null)
			{
				return BadRequest();
			}
			return Ok();
		}


	}
}
