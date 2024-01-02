using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProjesi.REPO.Configurations
{
	public class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
	{
		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			builder.Property(x => x.CreateDate).IsRequired(true);
			builder.Property(x => x.UpdateDate).IsRequired(false);
			builder.Property(x => x.DeleteDate).IsRequired(false);
			builder.Property(x => x.Status).IsRequired(true);
		}
	}
}
