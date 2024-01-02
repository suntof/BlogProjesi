using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProjesi.REPO.Configurations
{
	public class AppUserConfig : BaseEntityConfig<AppUser>
	{
		public override void Configure(EntityTypeBuilder<AppUser> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x =>x.UserName).IsRequired(true);
			builder.Property(x => x.FullName).IsRequired(false);
			builder.Property(x => x.ImagePath).IsRequired(false); 



			base.Configure(builder);
		}
	}
}
