using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Enums;
using BlogProjesi.CORE.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BlogProjesi.CORE.Entities
{
	public class AppUser : IdentityUser, IBaseEntity
	{
		public string FullName { get; set; }
		public string? ImagePath { get; set; }
        public DateTime CreateDate { get ; set; } = DateTime.Now;
		public DateTime? UpdateDate { get; set; }
		public DateTime? DeleteDate { get; set; }
		public Status Status { get; set; } = Status.Active;

		public virtual List<Article> Articles { get; set; }
		public virtual List<Comment> Comments { get; set; }
		public virtual List<Like> Likes { get; set; }

	}
}
