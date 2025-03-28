using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpocoMapper.Demo;

public static class Demos
{
	public static void RunforSqlite()
	{
		using var ttDb = new TestTableDb(Services.AppSettings.ConnectionStringSqlite);

		var all = ttDb.All();
		Console.WriteLine($"TestTable starts with ({all.Count()}) rows.");

		int nextId = all.Max(x => x.FirstKey) + 1;

		var item = new TestTable
		{
			FirstKey = 0,
			SecondNullable = $"Foo {nextId}",
			DateThing = DateTime.Now,
			InfoNullable = $"Bar {nextId}",
			MoreStuff = null,
			BoolThing = nextId % 2 == 0,
			BitThing = nextId % 2 == 1
		};


		ttDb.Save(item);

		Console.WriteLine($"Saved: FirstKey = {item.FirstKey}");
		Console.WriteLine($"All count is now: {ttDb.All().Count()}.");



	}
}
