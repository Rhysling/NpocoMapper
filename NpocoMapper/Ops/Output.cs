using NpocoMapper.Models;
using System.Collections.Generic;
using System.Linq;

namespace NpocoMapper.Ops;

public static class Output
{
	public static void Generate (List<Poco> pocos, Settings settings)
	{
		// Enums
		if (settings.GenerateEnums)
		{
			var epl = pocos.Where(a => a.ClassType == "Enum")
			.Select(a => new EnumPoco
			{
				EntityName = a.EntityName,
				EnumName = a.ClassName
			}).ToList();

			// Add forceEnumList
			epl.AddRange(settings.ForceEnumList);

			foreach (var e in epl)
				e.Values = settings.DbOps.LoadEnumValues(e);
			foreach (var e in epl)
				FileOps.SaveFile(settings.ModelPath, EntityType.Enum, e.EnumName, Writer.WriteEnum(e, settings.ModelNamespace), settings.OverwriteEnums);
		}

		// Pocos
		if (settings.GeneratePocos)
		{
			foreach (var p in pocos.Where(a => a.ClassType != "Enum"))
			{
				var et = p.ClassType == "Rw" ? EntityType.PocoRw : EntityType.PocoRo;
				FileOps.SaveFile(settings.ModelPath, et, p.ClassName, Writer.WritePoco(p, settings.ModelNamespace, settings.IncludeTsModelAttribute), settings.OverwritePocos);
			}
		}

		// Repos
		if (settings.GenerateRepos)
		{
			//Generate Repos/Core/RepositoryBase.cs
			FileOps.SaveFile(settings.RepoPath, EntityType.RepoBase, "RepositoryBase", Writer.WriteRepoBase(settings.RepoNamespace,settings.DbType), false);

			foreach (var p in pocos.Where(a => a.ClassType != "Enum"))
			{
				var et = p.ClassType == "Rw" ? EntityType.RepoRw : EntityType.RepoRo;
				FileOps.SaveFile(settings.RepoPath, et, p.ClassName, Writer.WriteRepo(p, settings.ModelNamespace, settings.RepoNamespace), settings.OverwriteRepos);
			}
		}
	}
}
