using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Enums;
using BlogProjesi.CORE.Interfaces;

namespace BlogProjesi.CORE.Entities
{
	public class Comment : IBaseEntity
	{
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
		public DateTime? UpdateDate { get; set; }
		public DateTime? DeleteDate { get; set; }
		public Status Status { get; set; } = Status.Active;

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
