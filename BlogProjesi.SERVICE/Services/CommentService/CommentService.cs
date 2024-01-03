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
using BlogProjesi.SERVICE.Models.DTOs.CommentDTOs;
using BlogProjesi.SERVICE.Models.VMs;

namespace BlogProjesi.SERVICE.Services.CommentService
{
	public class CommentService : ICommentService
	{
		private readonly ICommentRepository _commentRepository;
		private readonly IMapper _mapper;

		public CommentService(ICommentRepository commentRepository, IMapper mapper)
		{
			_commentRepository = commentRepository;
			_mapper = mapper;
		}

		public async Task Create(CreateCommentDTO model)
		{
			var comment = _mapper.Map<Comment>(model);
			await _commentRepository.Create(comment);
		}

		public async Task Delete(int id)
		{
			var comment = await _commentRepository.GetById(id);
			comment.DeleteDate = DateTime.Now;
			comment.Status = Status.Passive;
			_commentRepository.Delete(comment);

		}

		public async Task<GetCommentVM> GetById(int id)
		{
			var comment = await _commentRepository.GetById(id);
			return _mapper.Map<GetCommentVM>(comment);
		}

		public async Task<List<GetCommentVM>> GetComments()
		{
			var commnents = await _commentRepository.GetFilteredList(
				select: x => new GetCommentVM
				{
					Id = x.Id,
					UserName = x.AppUser.FullName,
					Text = x.Text,
					CreateDate = DateTime.Now,
				},
				where: x => x.Status != Status.Passive,
				orderBy: x => x.OrderByDescending(x => x.CreateDate));
			return commnents;
		}

		public void Update(UpdateCommentDTO model)
		{
			var comment = _mapper.Map<Comment>(model);
			_commentRepository.Update(comment);
		}
	}
}
