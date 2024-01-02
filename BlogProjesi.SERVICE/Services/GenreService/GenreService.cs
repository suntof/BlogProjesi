using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogProjesi.CORE.Entities;
using BlogProjesi.CORE.Enums;
using BlogProjesi.REPO.Interfaces;
using BlogProjesi.SERVICE.Models.DTOs;
using BlogProjesi.SERVICE.Models.VMs;

namespace BlogProjesi.SERVICE.Services.GenreService
{
	public class GenreService : IGenreService
	{
		private readonly IGenreRepository _genreRepository;
		private readonly IMapper _mapper;

		public GenreService(IGenreRepository genreRepository, IMapper mapper)
		{
			_genreRepository = genreRepository;
			_mapper = mapper;
		}


		public async Task Create(CreateGenreDTO model)
		{
			var genre = _mapper.Map<Genre>(model);
			await _genreRepository.Create(genre);
		}

		public async Task Delete(int id)
		{
			var genre = await _genreRepository.GetById(id);
			genre.DeleteDate = DateTime.Now;
			genre.Status = Status.Passive;

			_genreRepository.Delete(genre);
		}

		public async Task<GetGenreVM> GetById(int id)
		{
			var genre = await _genreRepository.GetById(id);
			return _mapper.Map<GetGenreVM>(genre);
		}

		public async Task<List<GetGenreVM>> GetGenres()
		{
			var genres = await _genreRepository.GetFilteredList(
				select: x => new GetGenreVM
				{
					Id = x.Id,
					Name = x.Name,
				},
				where: x => x.Status != Status.Passive,
				orderBy: x => x.OrderBy(x => x.Name));
			return genres;
		}

		public void Update(UpdateGenreDTO model)
		{
			var genre = _mapper.Map<Genre>(model);
			_genreRepository.Update(genre);
		}
	}
}
