﻿using Athentucation_IdentityJWT.Data;
using Athentucation_IdentityJWT.Models;
using Athentucation_IdentityJWT.Models.DTOs;
using Microsoft.AspNetCore.Identity;
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
		public UserRepo(AppDbContext db, IConfiguration configuration)
		{
			_db = db;
			secretKey = configuration.GetValue<string>("ApiSettings:secret");
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
			var user = _db.LocalUsers.FirstOrDefault(u => u.UserName.ToLower() == loginReqDTO.UserName.ToLower());
			if (user == null)
			{
				return null;
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

		public async Task<localUser> Register(RegisterReqDTO registerReqDTO)
		{
			localUser user = new localUser()
			{
				UserName = registerReqDTO.UserName,
				Password = registerReqDTO.Password,
				Role = registerReqDTO.Role,
				Name = registerReqDTO.Name

			};
			await _db.LocalUsers.AddAsync(user); //?? he didn't await !!! 
			await _db.SaveChangesAsync();
			user.Password = "";
			return user;

		}
	}
}
