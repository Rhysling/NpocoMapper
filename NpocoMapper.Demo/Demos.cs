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
		using var dttDb = new DummyTestTable2Db(Services.AppSettings.ConnectionStringSqlite);

		var all = dttDb.All();
		int nextId = all.Max(x => x.FirstKey) + 1;

		var item = new DummyTestTable2
		{
			FirstKey = 0,
			SecondNullable = $"Foo {nextId}",
			DateThing = DateTime.Now,
			InfoNullable = $"Bar {nextId}",
			MoreStuff = null,
			BoolThing = nextId % 2 == 1,
			BitThing = nextId % 2 == 1
		};


		dttDb.Save(item);

		Console.WriteLine($"Saved: FirstKey = {item.FirstKey}");
		Console.WriteLine($"All: {all.Count()}");

	}
}
