using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjesi.SERVICE.Models.DTOs
{
	public class CreateGenreDTO
	{
		[RegularExpression(@"[a-zA-Z ]+$", ErrorMessage = "Yalnızca Metinsel İfadeler İçermelidir.")]
		[Required(ErrorMessage ="Genre Boş Geçilemez")]
		[MinLength(3, ErrorMessage = "Minimum 3 karakter olmalıdır.")]
        public string Name { get; set; }


    }
}
