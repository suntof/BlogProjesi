using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Enums;
using BlogProjesi.CORE.Interfaces;

namespace BlogProjesi.CORE.Entities
{
	public class Genre : IBaseEntity
	{
        public int Id { get; set; }
		public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
		public DateTime? UpdateDate { get; set; }
		public DateTime? DeleteDate { get; set; }
		public Status Status { get; set; } = Status.Active;

		public virtual List<Article> Articles { get; set; }

	}
}
