using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProjesi.REPO.Configurations
{
	public class LikeConfig : BaseEntityConfig<Like>
	{
		public override void Configure(EntityTypeBuilder<Like> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.AppUser).WithMany(x => x.Likes).HasForeignKey(x => x.AppUserId);

			builder.HasOne(x=>x.Articles).WithMany(x=>x.Likes).HasForeignKey(x=>x.ArticleId).OnDelete(DeleteBehavior.NoAction);

			base.Configure(builder);
		}
	}
}
