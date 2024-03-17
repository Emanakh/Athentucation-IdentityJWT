using Athentucation_IdentityJWT.Models;
using Athentucation_IdentityJWT.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Athentucation_IdentityJWT.Repo
{
	public interface IUserRepo
	{
		bool IsUniqueUser(string username);
		public Task<LoginResDTO> Login(LoginReqDTO loginReqDTO);


		public Task<UserDTO> Register(RegisterReqDTO registerReqDTO);


	}
}
