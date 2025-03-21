using NpocoMapper.Models;
using System;
using System.Collections.Generic;

namespace NpocoMapper.Ops;
public class BuildSettings
{
	private Dictionary<string, string> argsDict;

	public BuildSettings(string[] args)
	{
		argsDict = new();
		ParseArgs(args);
	}

	public List<string> ValidateSettings()
	{
		List<string> errors = new();
		if (!argsDict.ContainsKey("applicationName"))
		{
			errors.Add("applicationName is required.");
		}
		if (!argsDict.ContainsKey("basePath"))
		{
			errors.Add("basePath is required.");
		}
		if (!argsDict.ContainsKey("dbName"))
		{
			errors.Add("dbName is required.");
		}
		if (!argsDict.ContainsKey("dbType"))
		{
			errors.Add("dbType is required.");
		}
		if (!argsDict.ContainsKey("dbConnStr"))
		{
			errors.Add("dbConnStr is required.");
		}
		return errors;
	}

	public Settings GetSettings()
	{
		string applicationName = argsDict.GetValueOrDefault("applicationName", "");
		string basePath = argsDict.GetValueOrDefault("basePath", "");
		string dbName = argsDict.GetValueOrDefault("dbName", "");
		string dbTypeStr = argsDict.GetValueOrDefault("dbType", "");
		string dbConnStr = argsDict.GetValueOrDefault("dbConnStr", "");
		
		bool generateEnums = argsDict.GetValueOrDefault("generateEnums", "true").Equals("true", StringComparison.CurrentCultureIgnoreCase);
		bool overwriteEnums = argsDict.GetValueOrDefault("overwriteEnums", "true").Equals("true", StringComparison.CurrentCultureIgnoreCase);
		bool generatePocos = argsDict.GetValueOrDefault("generatePocos", "true").Equals("true", StringComparison.CurrentCultureIgnoreCase);
		bool overwritePocos = argsDict.GetValueOrDefault("overwritePocos", "false").Equals("true", StringComparison.CurrentCultureIgnoreCase);
		bool generateRepos = argsDict.GetValueOrDefault("generateRepos", "true").Equals("true", StringComparison.CurrentCultureIgnoreCase);
		bool overwriteRepos = argsDict.GetValueOrDefault("overwriteRepos", "false").Equals("true", StringComparison.CurrentCultureIgnoreCase);
		bool includeTsModelAttribute = argsDict.GetValueOrDefault("includeTsModelAttribute", "true").Equals("true", StringComparison.CurrentCultureIgnoreCase);

		string[] ignoreTables = [];
		if (argsDict.TryGetValue("ignoreTableNames", out string? value))
		{
			ignoreTables = value.Split(',');
		}

		DbType dbType = Enum.Parse<DbType>(dbTypeStr, ignoreCase: true);

		return new Settings(applicationName, basePath, dbName, dbType, dbConnStr)
		{
			GenerateEnums = generateEnums,
			OverwriteEnums = overwriteEnums,
			GeneratePocos = generatePocos,
			OverwritePocos = overwritePocos,
			GenerateRepos = generateRepos,
			OverwriteRepos = overwriteRepos,
			IncludeTsModelAttribute = includeTsModelAttribute,
			IgnoreTableNames = ignoreTables
		};
	}


	public static string Instructions => """
		REQUIRED:
			applicationName=MyApp.Namespace
			basePath=D:\path\to\where\files\written
			dbName=TheDbName
			dbType=MsSql|Sqlite
			dbConnStr=TheConnectionString

		OPTIONAL:
			generateEnums=true|false
			overwriteEnums=true|false
			generatePocos=true|false
			overwritePocos=true|false
			generateRepos=true|false
			overwriteRepos=true|false
			includeTsModelAttribute=true|false

			ignoreTableNames=table1,table2,table3
		
		""";


	private void ParseArgs(string[] args)
	{
		foreach (string arg in args)
		{
			(string key, string value) = SplitOnFirstOccurrence(arg, '=');
			argsDict[key] = value;
		}
	}

	private static (string, string) SplitOnFirstOccurrence(string input, char delimiter)
	{
		int index = input.IndexOf(delimiter);
		if (index == -1)
		{
			return (input, string.Empty);
		}
		string firstPart = input.Substring(0, index);
		string secondPart = input.Substring(index + 1);
		return (firstPart, secondPart);
	}

}
