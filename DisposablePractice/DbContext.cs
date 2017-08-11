using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposablePractice
{
	public class DbContext : IDisposable
	{
		private SqlConnection _connection;
		private bool _disposed;

		public DbContext()
		{
			_connection = new SqlConnection("Data Source=.;Initial Catalog=WAOnline.Database.Configuration;Integrated Security=True");
			_connection.Open();
		}

		public virtual string GetDate()
		{
			if (_disposed)
				throw new ObjectDisposedException(nameof(DbContext));

			using (var command = _connection.CreateCommand())
			{
				command.CommandText = "select getdate()";
				return command.ExecuteScalar().ToString();
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed) return;
			
			if (disposing)
			{
				_connection?.Dispose();
				GC.SuppressFinalize(this);
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}
	}
}
