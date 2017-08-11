using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Repository
{
	public interface IRepository
	{
	}

	public interface IRepository<T> : IRepository
	{
		IQueryable<T> FindAll(Expression<Func<T, bool>> expression);

		T FindById(int id);
	}

	public class Repository<T> : IRepository<T>
	{
		private DbSet<T> _dbSet;
		public Repository(DbContext ctx)
		{
			_dbSet = ctx.CreateDbSet<T>();
		}
		public IQueryable<T> FindAll(Expression<Func<T, bool>> expression)
		{
			throw new NotImplementedException();
		}

		public T FindById(int id)
		{
			throw new NotImplementedException();
		}
	}

	public class UnitOfWork : IDisposable
	{
		private SampleDbContext _sampleDbContext = new SampleDbContext();

		private Dictionary<Type, IRepository> dict = new Dictionary<Type, IRepository>();
		public IRepository<T> Respository<T>() where T : class
		{
			if (dict.ContainsKey(typeof(T)))
			{
				return dict[typeof(T)] as IRepository<T>;
			}
			
			var repo = new Repository<T>(_sampleDbContext);
			dict[typeof(T)] = repo;
			return repo;
		}

		public void SaveChanges()
		{
			_sampleDbContext.SaveChanges();
		}

		private bool _disposed;
		private void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_sampleDbContext.Dispose();
				}
			}

			

			_disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~UnitOfWork()
		{
			Dispose(false);
		}
	}

	public class SampleDbContext : DbContext {
		
	}

	public class DbContext
	{
		public void SaveChanges()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public DbSet<T> CreateDbSet<T>()
		{
			return new DbSet<T>();
		}
	}

	public class DbSet<T> { }

	public class Employee { }

	public class Program
	{
		public static void Main1(string[] args)
		{
			var uow = new UnitOfWork();
			uow.Respository<Employee>().FindById(1);

		}
	}

}
