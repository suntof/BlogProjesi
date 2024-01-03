using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Entities;

namespace BlogProjesi.SERVICE.Models.DTOs
{
	public class CreateArticleDTO
	{
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Genre> Genres { get; set; }
        public int GenreId { get; set; }
        public string AppUserId { get; set; }
    }
}
