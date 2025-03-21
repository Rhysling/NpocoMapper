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
			var bs = new BuildSettings(args);
			var errors = bs.ValidateSettings();

			if (errors.Count > 0)
			{
				foreach (var error in errors)
					Console.WriteLine(error);
				Console.WriteLine();

				Console.Write(BuildSettings.Instructions);
				Console.WriteLine();
				Console.ReadKey();
				return;
			}

			var settings = bs.GetSettings();

			// Settings ********************************
			//var settings = new Settings(
			//	applicationName: "NpocoMapper.Demo",
			//	//basePath: @"D:\UserData\Documents\AppDev\NpocoMapper\NpocoMapper.Demo",
			//	basePath: @"D:\yy\tp3",
			//	dbName: "TestingPocos",
			//	dbType: DbType.MsSql,
			//	dbConnStr: $"Data Source=localhost;Initial Catalog=TestingPocos;Integrated Security=True"
			//);


			//var settings = new Settings(
			//	applicationName: "NpocoMapper.Demo",
			//	//basePath: @"D:\UserData\Documents\AppDev\NpocoMapper\NpocoMapper.Demo",
			//	basePath: @"D:\yy\tp3",
			//	dbName: "TestingPocos",
			//	dbType: DbType.Sqlite,
			//	dbConnStr: @"Data Source=D:\UserData\Documents\AppDev\NpocoMapper\NpocoMapper.Demo\db\TestGen.sqlite;"
			//);
			//settings.OverwritePocos = true;
			//settings.OverwriteRepos = true;


			var runner = new Runner(settings);
			runner.Run();
			//runner.Test();

			Console.WriteLine("Done.");
			Console.ReadKey();
		}
	}
}
