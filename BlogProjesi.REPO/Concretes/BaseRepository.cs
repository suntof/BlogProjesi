using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Interfaces;
using BlogProjesi.REPO.Contexts;
using BlogProjesi.REPO.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BlogProjesi.REPO.Concretes
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
	{

		private readonly AppDbContext _appDbContext;
		protected DbSet<T> _table;

		public BaseRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
			_table = _appDbContext.Set<T>();
		}

		public async Task<bool> Any(Expression<Func<T, bool>> expression)
		{
			return await _table.AnyAsync(expression);
		}

		public async Task Create(T entity)
		{
			_table.Add(entity);
			await _appDbContext.SaveChangesAsync();
		}

		public void Delete(T entity)
		{
			_appDbContext.SaveChanges();
		}

		public async Task<T> GetById(int id)
		{
			return await _table.FindAsync(id);
		}

		public async Task<T> GetDefault(Expression<Func<T, bool>> expression)
		{
			return await _table.FirstOrDefaultAsync(expression);
		}

		public async Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression)
		{
			return await _table.Where(expression).ToListAsync();
		}

		public async Task<TResult> GetFilteredFirstOrDefoult<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
		{
			IQueryable<T> query = _table;
			if (join != null)
			{
				query = join(query);
			}
			if (where != null)
			{
				query = query.Where(where);
			}
			return await query.Select(select).FirstOrDefaultAsync();
		}

		public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
		{
			IQueryable<T> query = _table;
			if (join != null)
			{
				query = join(query);
			}
			if (where != null)
			{
				query = query.Where(where);
			}
			if (orderBy != null)
			{
				return await orderBy(query).Select(select).ToListAsync();
			}
			else
			{
				return await query.Select(select).ToListAsync();
			}
		}

		public void Update(T entity)
		{
			_appDbContext.Entry<T>(entity).State = EntityState.Modified;
			_appDbContext.SaveChanges();
		}
	}
}
