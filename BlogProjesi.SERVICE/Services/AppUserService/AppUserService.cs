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
		private readonly SignInManager<AppUser> signInManager;
		private readonly IMapper _mapper;
		private readonly IAppUserRepository _userRepository;

		public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IAppUserRepository userRepository) 
		{
			_userManager = userManager;
			this.signInManager = signInManager;
			_mapper = mapper;
			_userRepository = userRepository;
		}

		public async Task<UpdateProfileDTO> GetById(string id)
		{
			var user = await _userRepository.GetDefault(x=>x.Id == id);
			var model = _mapper.Map<UpdateProfileDTO>(user);
			return model;
		}

		public Task<SignInResult> Login(LoginDTO model)
		{
			throw new NotImplementedException();
		}

		public Task LogOut()
		{
			throw new NotImplementedException();
		}

		public Task<IdentityResult> Register(RegisterDTO model)
		{
			throw new NotImplementedException();
		}

		public Task UpdateUser(UpdateProfileDTO model)
		{
			throw new NotImplementedException();
		}
	}
}
