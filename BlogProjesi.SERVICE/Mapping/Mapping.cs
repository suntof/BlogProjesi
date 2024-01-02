using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogProjesi.CORE.Entities;
using BlogProjesi.SERVICE.Models.DTOs;
using BlogProjesi.SERVICE.Models.VMs;

namespace BlogProjesi.SERVICE.Mapping
{
	public class Mapping : Profile
	{
		public Mapping() 
		{
			CreateMap<Genre, CreateGenreDTO>().ReverseMap();
			CreateMap<Genre, UpdateGenreDTO>().ReverseMap();
			CreateMap<Genre, GetGenreVM>().ReverseMap();

			CreateMap<AppUser, RegisterDTO>().ReverseMap();
			CreateMap<AppUser, LoginDTO>().ReverseMap();
			CreateMap<AppUser, UpdateProfileDTO>().ReverseMap();

			CreateMap<Article, CreateArticleDTO>().ReverseMap();
		}

	}
}
