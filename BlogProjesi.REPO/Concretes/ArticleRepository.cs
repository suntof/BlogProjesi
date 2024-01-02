using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Entities;
using BlogProjesi.REPO.Contexts;
using BlogProjesi.REPO.Interfaces;

namespace BlogProjesi.REPO.Concretes
{
	public class ArticleRepository : BaseRepository<Article>, IArticleRepository
	{
		public ArticleRepository(AppDbContext appDbContext) : base(appDbContext)
		{

		}
	}
}
