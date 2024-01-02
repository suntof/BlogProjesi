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
using Microsoft.EntityFrameworkCore;

namespace BlogProjesi.SERVICE.Services.ArticleServise
{
	public class ArticleService : IArticleService
	{
		private readonly IArticleRepository _articleRepository;
		private readonly IMapper _mapper;

		public ArticleService(IArticleRepository articleRepository, IMapper mapper)
		{
			_articleRepository = articleRepository;
			_mapper = mapper;
		}

		public async Task Create(CreateArticleDTO model)
		{
			var article = _mapper.Map<Article>(model);
			await _articleRepository.Create(article);
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<GetArticleDetailVM> GetArticleDetail(int id)
		{
			var article = await _articleRepository.GetFilteredFirstOrDefoult(

				select: x => new GetArticleDetailVM
				{
					Id = x.Id,
					Title = x.Title,
					Content = x.Content,
					CreateDate = x.CreateDate,
					AuthorFullName = x.AppUser.FullName,
					LikeCount = x.Likes.Count,
					CommentCount = x.Comments.Count,
					CommentList = x.Comments.Where(x => x.Id == id)
											.OrderByDescending(x=>x.CreateDate)
											.Select(x=>new GetCommentVM
											{
												Id=x.Id,
												Text=x.Text,
												CreateDate=x.CreateDate,
												UserName=x.AppUser.UserName
											}).ToList()
				},
				where: x => x.Status != Status.Passive && x.Id == id,
				join: x => x.Include(x=>x.AppUser).ThenInclude(x =>x.Comments));
			return article;
		}

		public async Task<List<GetArticleVM>> GetArticles()
		{
			var articles = await _articleRepository.GetFilteredList(
				select: x => new GetArticleVM
				{
					Id = x.Id,
					Title = x.Title,
					Content = x.Content.Substring(0,150),
					CreateDate = x.CreateDate,
					AuthorFullName =x.AppUser.FullName,
					LikeCount = x.Likes.Count,
					CommentCount = x.Comments.Count,
				},
				where: x => x.Status != Status.Passive,
				orderBy: x => x.OrderBy( x => x.CreateDate),
				join: x => x.Include( x => x.AppUser));
			return articles;
		}

		public void Update(CreateArticleDTO model)
		{
			throw new NotImplementedException();
		}
	}
}
