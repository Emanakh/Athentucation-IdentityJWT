using Athentucation_IdentityJWT.Models;
using Athentucation_IdentityJWT.Models.DTOs;

namespace Athentucation_IdentityJWT.Repo
{
	public interface IUserRepo
	{
		bool IsUniqueUser(string username);
		Task<LoginResDTO> Login(LoginReqDTO loginReqDTO);

		Task<localUser> Register(RegisterReqDTO registerReqDTO);

	}
}
