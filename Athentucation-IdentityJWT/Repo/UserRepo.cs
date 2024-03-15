using Athentucation_IdentityJWT.Data;
using Athentucation_IdentityJWT.Models;
using Athentucation_IdentityJWT.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Athentucation_IdentityJWT.Repo
{
	public class UserRepo : IUserRepo
	{
		private readonly AppDbContext _db;
		private readonly string secretKey;
		private readonly UserManager<AccountIdentity> _userManager;

		public UserRepo(AppDbContext db, IConfiguration configuration, UserManager<AccountIdentity> userManager)
		{
			_db = db;
			secretKey = configuration.GetValue<string>("ApiSettings:secret");
			_userManager = userManager;
		}
		public bool IsUniqueUser(string username)
		{
			var user = _db.LocalUsers.FirstOrDefault(x => x.UserName == username);
			if (user == null)
			{
				return true;
			}
			return false;
		}

		//generate token
		public async Task<LoginResDTO> Login(LoginReqDTO loginReqDTO)
		{
			var user = _db.LocalUsers.FirstOrDefault(u => u.UserName.ToLower() == loginReqDTO.UserName.ToLower() && u.Password == loginReqDTO.Password);
			if (user == null)
			{
				//return null;
				return new LoginResDTO()
				{
					Token = "",
					User = null

				};
			}
			//if found generate token... 

			//key 
			var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey);
			var key = new SymmetricSecurityKey(secretKeyInBytes);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
				new Claim(ClaimTypes.Role, user.Role),
			}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
			};

			var TokenHandler = new JwtSecurityTokenHandler();
			var token = TokenHandler.CreateToken(tokenDescriptor);
			var StringToken = TokenHandler.WriteToken(token);
			LoginResDTO loginResDTO = new LoginResDTO()
			{
				Token = StringToken,
				User = user
			};
			return loginResDTO;

		}


		//public async Task<ActionResult<customer>> Register(RegisteCustomerDTO customerDTO)
		//{
		//	var customer = new AccountIdentity
		//	{
		//		fname = customerDTO.fname,
		//		Email = customerDTO.Email
		//	};

		//	var creationResult = await _userManager.CreateAsync(customer, customerDTO.Password);

		//	if (!creationResult.Succeeded)
		//	{
		//		return null;
		//	}

		//	var userClaims = new List<Claim>
		//	{
		//		new Claim(ClaimTypes.NameIdentifier, customerDTO.fname),
		//		new Claim(ClaimTypes.Email, customerDTO.Email),
		//		new Claim(ClaimTypes.Role, "Customer"),
		//	};
		//	await _userManager.AddClaimsAsync(customer, userClaims);

		//	return new customer
		//	{
		//		fname = customerDTO.fname,
		//		Email = customerDTO.Email
		//	};

		//}

		//public async Task<localUser> Register(RegisterReqDTO registerReqDTO)
		//{
		//	localUser user = new localUser()
		//	{
		//		UserName = registerReqDTO.UserName,
		//		Password = registerReqDTO.Password,
		//		Role = registerReqDTO.Role,
		//		Name = registerReqDTO.Name

		//	};
		//	await _db.LocalUsers.AddAsync(user); //?? he didn't await !!! 
		//	await _db.SaveChangesAsync();
		//	user.Password = "";
		//	return user;


		//}


	}
}