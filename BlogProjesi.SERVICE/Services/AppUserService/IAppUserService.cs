using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.SERVICE.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace BlogProjesi.SERVICE.Services.AppUserService
{
	public interface IAppUserService
	{
		Task<IdentityResult> Register(RegisterDTO model);
		Task<SignInResult> Login(LoginDTO model);
		Task LogOut();

		Task<UpdateProfileDTO> GetById(string id);
		Task UpdateUser(UpdateProfileDTO model);

	}
}
