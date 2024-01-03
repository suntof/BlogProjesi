using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjesi.SERVICE.Models.DTOs
{
	public class CreateCommentDTO
	{
		public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public string AppUserId { get; set; }
    }
}
