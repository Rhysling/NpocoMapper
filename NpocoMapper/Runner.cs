using NpocoMapper.Models;
using NpocoMapper.Ops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpocoMapper;

public class Runner(Settings settings)
{
	public void Run()
	{
		// Check base output path
		if (!System.IO.Directory.Exists(settings.BasePath))
			throw new Exception($"'{settings.BasePath}' does not exist.");

		var columns = settings.DbOps.LoadColumns();
		var pocos = Mapper.MapColumnsToPocos(columns);

		pocos = pocos.Where(a => !a.Ignore && !settings.IgnoreTableNames.Any(b => b == a.EntityName)).ToList();

		Output.Generate(pocos, settings);
	}

	public void Test()
	{
		// Check base output path
		if (!System.IO.Directory.Exists(settings.BasePath))
			throw new Exception($"'{settings.BasePath}' does not exist.");

		var columns = settings.DbOps.LoadColumns();
		var pocos = Mapper.MapColumnsToPocos(columns);

		pocos = pocos.Where(a => !a.Ignore && !settings.IgnoreTableNames.Any(b => b == a.EntityName)).ToList();
		
		Output.Generate(pocos, settings);
	}

}