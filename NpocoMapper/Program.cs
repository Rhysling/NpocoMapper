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
			string applicationName = "NpocoMapper.Demo";

			//string dbName = applicationName + "Db";
			string dbName = "TestingPocos";

			string connectionString = $"Data Source=localhost;Initial Catalog={dbName};Integrated Security=True";

			//string basePath = @"C:\Users\B\Documents\yy\tp1";
			string basePath = @"D:\UserData\Documents\AppDev\NpocoMapper\NpocoMapper.Demo";


			string modelPath = basePath + @"\Models\Generated";
			string repoPath = basePath + @"\Repos\Generated";

			string modelNamespace = applicationName + ".Models";
			string repoNamespace = applicationName + ".Repos";
			 
			bool generateEnums = true;
			bool overwriteEnums = true;

			bool generatePocos = true;
			bool overwritePocos = true;

			bool generateRepos = true;
			bool overwriteRepos = true;

			bool includeTsModelAttribute = true;


			// Table name patterns to ignore:
			string[] ignoreTableNames = new string[] { "tpPlantPricesOld" };

			// Force Enums from specified tables
			var forceEnumList = new List<EnumPoco>{
				//new EnumPoco {
				//	EntityName = "ListObjects",
				//	EnumName = "ListObjectsEnum",
				//	IdColumnName = "ShortName",
				//	NameColumnName = "Id",
				//	DescriptionColumnName = "Description"
				//}
			};


			// Check base output path
			if (!System.IO.Directory.Exists(basePath))
				throw new Exception($"'{basePath}' does not exist.");

			var columns = DbOps.LoadColumns(connectionString);
			var pocos = Mapper.MapColumnsToPocos(columns);

			pocos = pocos.Where(a => !a.Ignore && !ignoreTableNames.Any(b => b == a.EntityName)).ToList();
			// Force Enums here

			// Generate output ***

			// Enums
			if (generateEnums)
			{
				var enums = Mapper.MapPocosToEnums(pocos, forceEnumList, connectionString);

				foreach (var e in enums)
					FileOps.SaveFile(modelPath, EntityType.Enum, e.EnumName, Writer.WriteEnum(e, modelNamespace), overwriteEnums);
			}

			// Pocos
			if (generatePocos)
			{
				foreach (var p in pocos.Where(a => a.ClassType != "Enum"))
				{
					var et = p.ClassType == "Rw" ? EntityType.PocoRw : EntityType.PocoRo;
					FileOps.SaveFile(modelPath, et, p.ClassName, Writer.WritePoco(p, modelNamespace, includeTsModelAttribute), overwritePocos);
				}
			}

			// Repos
			if (generateRepos)
			{
				foreach (var p in pocos.Where(a => a.ClassType != "Enum"))
				{
					var et = p.ClassType == "Rw" ? EntityType.RepoRw : EntityType.RepoRo;
					FileOps.SaveFile(repoPath, et, p.ClassName, Writer.WriteRepo(p, modelNamespace, repoNamespace), overwriteRepos);
				}
			}

			Console.WriteLine("Done.");
			Console.ReadKey();
		}
	}
}
