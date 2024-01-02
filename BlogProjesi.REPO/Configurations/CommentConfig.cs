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
	public class CommentConfig : BaseEntityConfig<Comment>
	{
		public override void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Text).IsRequired();

			builder.HasOne(x => x.AppUser).WithMany(x => x.Comments).HasForeignKey(x => x.AppUserId);

			builder.HasOne(x => x.Article).WithMany(x => x.Comments).HasForeignKey(x => x.ArticleId).OnDelete(DeleteBehavior.NoAction);

			base.Configure(builder);
		}
	}
}
