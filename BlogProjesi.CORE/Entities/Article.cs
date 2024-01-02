using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Enums;
using BlogProjesi.CORE.Interfaces;

namespace BlogProjesi.CORE.Entities
{
	public class Article : IBaseEntity
	{

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
		public DateTime? UpdateDate { get; set; }
		public DateTime? DeleteDate { get; set; }
		public Status Status { get; set; } = Status.Active;


        public int GenreId { get; set; }
		public virtual Genre Genre { get; set; }

        public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		

		public virtual List<Like> Likes { get; set; }

		public virtual List<Comment> Comments { get; set; }
	}
}
