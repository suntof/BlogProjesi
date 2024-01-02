using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogProjesi.CORE.Entities;
using BlogProjesi.REPO.Interfaces;
using BlogProjesi.SERVICE.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace BlogProjesi.SERVICE.Services.AppUserService
{
	public class AppUserService : IAppUserService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IMapper _mapper;
		private readonly IAppUserRepository _appUserRepository;

		public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IAppUserRepository appUserRepository)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_mapper = mapper;
			_appUserRepository = appUserRepository;
		}

		public async Task<UpdateProfileDTO> GetById(string id)
		{
			var user = await _appUserRepository.GetDefault(x=>x.Id == id);
			var model = _mapper.Map<UpdateProfileDTO>(user);
			return model;
		}

		public async Task<SignInResult> Login(LoginDTO model)
		{
			var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
			return result;
		}

		public async Task LogOut()
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<IdentityResult> Register(RegisterDTO model)
		{
			var user = _mapper.Map<AppUser>(model);

			var result = await _userManager.CreateAsync(user);

			if (result.Succeeded)
			{
				await _signInManager.SignInAsync(user, false);
			}
			
			return result;
			

		}

		public async Task UpdateUser(UpdateProfileDTO model)
		{
			var user = _mapper.Map<AppUser>(model);

			if (model != null)
			{
				_appUserRepository.Update(user);
			}
			if (model.Password != null)
			{
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
			}
			if (model.UserName != null)
			{
				await _userManager.SetEmailAsync(user, model.UserName);
				await _userManager.SetUserNameAsync(user, model.UserName);
				await _signInManager.SignInAsync(user, false);
			}
		}
	}
}
