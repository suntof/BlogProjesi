using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Entities;
using BlogProjesi.REPO.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogProjesi.REPO.Contexts
{
	public class AppDbContext : IdentityDbContext<AppUser>
	{
        public DbSet<Genre> Genres { get; set; }
		public DbSet<Article> Articles { get; set; }
		public DbSet<Like> Likes { get; set; }
		public DbSet<Comment> Comments { get; set; }	
		public DbSet<AppUser> AppUsers { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{

			//Fluent Api

			builder.ApplyConfiguration(new GenreConfig());
			builder.ApplyConfiguration(new ArticleConfig());
			builder.ApplyConfiguration(new LikeConfig());
			builder.ApplyConfiguration(new CommentConfig());
			builder.ApplyConfiguration(new AppUserConfig());

			base.OnModelCreating(builder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=MUSTAF\\SQLEXPRESS;Initial Catalog=BlogProjesi;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}
	}
}
