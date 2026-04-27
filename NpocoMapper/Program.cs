using System;
using NpocoMapper.Models;
using NpocoMapper.Ops;

namespace NpocoMapper;

class Program
{
	static void Main(string[] args)
	{
		//var settings = SettingsFromArgs(args);
		var settings = SettingsFromPresetMsSql();
		//var settings = SettingsFromPresetSqlite();

		//settings.OverwritePocos = true;
		//settings.OverwriteRepos = true;
		//settings.IgnoreTableNames = ["TestTableIgnored"];

		if (settings == null) return;

		var runner = new Runner(settings);
		runner.Run();

		Console.WriteLine("Done.");
		Console.ReadKey();
	}

	private static Settings? SettingsFromArgs(string[] args)
	{
		// Settings -- From Args ********************************
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
			return null;
		}

		return bs.GetSettings();
	}

	private static Settings SettingsFromPresetMsSql()
	{
		// Settings -- Presets for Run ********************************
		return new Settings(
			applicationName: "NpocoMapper.Demo",
			//basePath: @"D:\aa-dev\AppDev\NpocoMapper\NpocoMapper.Demo",
			basePath: @"D:\yy-util\tp2",
			dbName: "BotanicaStoreDb",
			dbType: DbType.MsSql,
			dbConnStr: $"Data Source=localhost;Initial Catalog=BotanicaStoreDb;Integrated Security=True;TrustServerCertificate=True"
		);
	}

	private static Settings SettingsFromPresetSqlite()
	{
		// Settings -- Presets for Run ********************************
		return new Settings(
			applicationName: "NpocoMapper.Demo",
			//basePath: @"D:\aa-dev\AppDev\NpocoMapper\NpocoMapper.Demo",
			basePath: @"D:\yy-util\tp2",
			dbName: "TestingPocos",
			dbType: DbType.Sqlite,
			dbConnStr: @"Data Source=D:\aa-dev\AppDev\NpocoMapper\NpocoMapper.Demo\db\TestGen.sqlite;"
		);
	}
}
