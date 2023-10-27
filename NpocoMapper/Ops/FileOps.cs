using NpocoMapper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NpocoMapper.Ops
{
	public static class FileOps
	{
		public static void SaveFile(string path, EntityType entityType, string className, string FileText, bool overwrite)
		{
			string dirPath = entityType switch
			{
				EntityType.Enum => Path.Combine(path + @"\Enums"),
				EntityType.PocoRw => Path.Combine(path + @"\PocosRw"),
				EntityType.PocoRo => Path.Combine(path + @"\PocosRo"),
				EntityType.ITypeScript => path,
				EntityType.RepoRw => Path.Combine(path + @"\Rw"),
				EntityType.RepoRo => Path.Combine(path + @"\Ro"),
				_ => throw new Exception("GetEntityFullPath - not all types covered")
			};

			Directory.CreateDirectory(dirPath);

			string fullPath = entityType switch
			{
				EntityType.ITypeScript => $@"{dirPath}\GeneratedModels.d.ts",
				EntityType.RepoRo => $@"{dirPath}\{className}Db.cs",
				EntityType.RepoRw => $@"{dirPath}\{className}Db.cs",
				_ => $@"{dirPath}\{className}.cs"
			};

			if (overwrite || !File.Exists(fullPath))
				File.WriteAllText(fullPath, FileText);

		}

	}
}
