using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.SERVICE.Models.DTOs;
using BlogProjesi.SERVICE.Models.VMs;

namespace BlogProjesi.SERVICE.Services.ArticleServise
{
	public interface IArticleService
	{
		Task<List<GetArticleVM>> GetArticles();
		Task<GetArticleDetailVM> GetArticleDetail(int id);

		Task Create(CreateArticleDTO model);
		void Update(CreateArticleDTO model);
		Task Delete(int id);
	}
}
