using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProjesi.REPO.Configurations
{
	public class ArticleConfig : BaseEntityConfig<Article>
	{
		public override void Configure(EntityTypeBuilder<Article> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Title).IsRequired();
			builder.Property(x => x.Content).IsRequired();

			builder.HasOne(x => x.AppUser).WithMany(x => x.Articles).HasForeignKey(x => x.AppUserId);
			builder.HasOne(x => x.Genre).WithMany(x => x.Articles).HasForeignKey(x => x.GenreId);

			base.Configure(builder);
		}
	}
}
