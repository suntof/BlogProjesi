using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.SERVICE.Models.DTOs;
using BlogProjesi.SERVICE.Models.VMs;

namespace BlogProjesi.SERVICE.Services.GenreService
{
	public interface IGenreService
	{
		Task Create(CreateGenreDTO model);
		void Update(UpdateGenreDTO model);
		Task Delete(int id);

		Task<GetGenreVM> GetById(int id);

		Task<List<GetGenreVM>> GetGenres();
	}
}
