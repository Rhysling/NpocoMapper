using NpocoMapper.Ops;
using System;
using System.Collections.Generic;

namespace NpocoMapper.Models;

public class Settings
{
	private string applicationName;
	private string basePath;
	private string dbName;
	private DbType dbType;
	private string dbConnStr;
	private IDbOps dbOps;

	public Settings(string applicationName, string basePath, string dbName, DbType dbType, string dbConnStr)
	{
		this.applicationName = applicationName;
		this.basePath = basePath;
		this.dbName = dbName;
		this.dbType = dbType;
		this.dbConnStr = dbConnStr;
		dbOps = dbType switch
		{
			DbType.MsSql => new MsSqlDbOps(dbConnStr),
			DbType.Sqlite => new SqliteDbOps(dbConnStr),
			_ => throw new NotImplementedException()
		};
	}

	public string ApplicationName => applicationName;
	public string BasePath => basePath;
	public string DbName => dbName;
	public DbType DbType => dbType;
	public string DbConnStr => dbConnStr;
	public IDbOps DbOps => dbOps;


	public string ModelPath => basePath + @"\Models\Generated";
	public string RepoPath => basePath + @"\Repos\Generated";
	public string ModelNamespace => applicationName + ".Models";
	public string RepoNamespace => applicationName + ".Repos";


	public bool GenerateEnums { get; set; } = true;
	public bool OverwriteEnums { get; set; } = true;
	public bool GeneratePocos { get; set; } = true;
	public bool OverwritePocos { get; set; } = false;
	public bool GenerateRepos { get; set; } = true;
	public bool OverwriteRepos { get; set; } = false;
	public bool IncludeTsModelAttribute { get; set; } = true;


	// Table name patterns to ignore:
	public string[] IgnoreTableNames { get; set; } = []; // = new string[] { "tpPlantPricesOld" };

	// Force Enums from specified tables
	public List<EnumPoco> ForceEnumList { get; set; } = [];
	//var forceEnumList = new List<EnumPoco>
	//{
		//new EnumPoco {
		//	EntityName = "ListObjects",
		//	EnumName = "ListObjectsEnum",
		//	IdColumnName = "TheIdCol",
		//	NameColumnName = "HereIsShorty",
		//	DescriptionColumnName = "The Description Here"
		//}
	//};

}
