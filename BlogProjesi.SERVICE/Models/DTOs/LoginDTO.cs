using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjesi.SERVICE.Models.DTOs
{
	public class LoginDTO
	{
		[Required(ErrorMessage = "Boş Geçilemez")]
		[DataType(DataType.EmailAddress)]
		[DisplayName("Email Adresi")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Boş Geçilemez")]
		[DataType(DataType.Password)]
		[DisplayName("Şifre")]
		public string Password { get; set; }
	}
}
