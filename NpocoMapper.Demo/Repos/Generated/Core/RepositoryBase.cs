using NPoco;
using System;
using System.Data.Common;

namespace NpocoMapper.Demo.Repos.Core;

public abstract class RepositoryBase : IDisposable
{
	protected Database db;
	bool _disposed = false;

	public RepositoryBase(string connStr)
	{
		DbProviderFactory factory = Microsoft.Data.Sqlite.SqliteFactory.Instance;
		db = new Database(connStr, DatabaseType.SQLite, factory);
		//db.Execute("PRAGMA journal_mode=WAL;");
	}

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

			db?.Dispose();
		}

		// Release any unmanaged objects. Set the object references to null
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		db = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

		_disposed = true;
	}
	
}