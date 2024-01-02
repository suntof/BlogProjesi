using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProjesi.REPO.Configurations
{
	public class GenreConfig : BaseEntityConfig<Genre>
	{
		public override void Configure(EntityTypeBuilder<Genre> builder)
		{

			builder.HasKey(x => x.Id);
			 

			base.Configure(builder);
		}
	}
}
