using System;
using NPoco;
using NpocoMapper.Demo.Services;

namespace NpocoMapper.Demo.Repos.Core
{
	public abstract class RepositoryBase : IDisposable
	{
		protected NPoco.Database db = new NPoco.Database(AppSettings.ConnectionString, DatabaseType.SqlServer2012, Microsoft.Data.SqlClient.SqlClientFactory.Instance);
		bool _disposed = false;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~RepositoryBase()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (disposing)
			{
				// free other managed objects that implement, IDisposable only

				if (db != null)
					db.Dispose();
			}

			// Release any unmanaged objects. Set the object references to null
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
			db = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

			_disposed = true;
		}
	}
}