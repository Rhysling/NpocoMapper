using System;
using System.Collections.Generic;
using System.Linq;
using NpocoMapper.Models;
using NpocoMapper.Ops;

namespace NpocoMapper
{
	class Program
	{
		static void Main(string[] args)
		{
			//<#@ include file="NPoco.Core.ttinclude" #>

			// Settings ********************************
			//var settings = new Settings(
			//	applicationName: "NpocoMapper.Demo",
			//	//basePath: @"D:\UserData\Documents\AppDev\NpocoMapper\NpocoMapper.Demo",
			//	basePath: @"D:\yy\tp3",
			//	dbName: "TestingPocos",
			//	dbType: DbType.MsSql,
			//	dbConnStr: $"Data Source=localhost;Initial Catalog=TestingPocos;Integrated Security=True"
			//);

			var settings = new Settings(
				applicationName: "NpocoMapper.Demo",
				//basePath: @"D:\UserData\Documents\AppDev\NpocoMapper\NpocoMapper.Demo",
				basePath: @"D:\yy\tp3",
				dbName: "TestingPocos",
				dbType: DbType.Sqlite,
				dbConnStr: @"Data Source=D:\UserData\Documents\AppDev\NpocoMapper\NpocoMapper.Demo\db\TestGen.sqlite;"
			);
			settings.OverwritePocos = true;
			settings.OverwriteRepos = true;

			var runner = new Runner(settings);
			runner.Run();
			//runner.Test();

			Console.WriteLine("Done.");
			Console.ReadKey();
		}
	}
}
