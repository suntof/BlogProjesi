using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.CORE.Interfaces;
using Microsoft.EntityFrameworkCore.Query;

namespace BlogProjesi.REPO.Interfaces
{
	public interface IBaseRepository<T> where T : IBaseEntity
	{
		Task Create(T entity);
		void Update(T entity);
		void Delete(T entity);

		Task<T> GetById(int id);
		Task<bool> Any (Expression<Func<T, bool>> expression);
		Task<T> GetDefault(Expression<Func<T, bool>> expression);
		Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression);

		Task<TResult> GetFilteredFirstOrDefoult<TResult>(
			Expression<Func<T, TResult>> select,
			Expression<Func<T, bool>> where = null,
			Func<IQueryable<T>, IIncludableQueryable<T, Object>> join = null);

		Task<List<TResult>> GetFilteredList<TResult>(
			Expression<Func<T, TResult>> select,
			Expression<Func<T, bool>> where = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, Object>> join = null);
	}
}
