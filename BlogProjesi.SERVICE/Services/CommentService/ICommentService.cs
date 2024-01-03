using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.SERVICE.Models.DTOs;
using BlogProjesi.SERVICE.Models.DTOs.CommentDTOs;
using BlogProjesi.SERVICE.Models.VMs;

namespace BlogProjesi.SERVICE.Services.CommentService
{
	public interface ICommentService
	{
		Task Create(CreateCommentDTO model);
		void Update(UpdateCommentDTO model);
		Task Delete(int id);

		Task<List<GetCommentVM>> GetComments();
		Task<GetCommentVM> GetById(int id);
	}
}
