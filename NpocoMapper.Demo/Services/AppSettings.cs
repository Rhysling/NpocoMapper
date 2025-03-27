using System;
using System.Linq;
using System.Configuration;
using System.Web;

namespace NpocoMapper.Demo.Services;

public static class AppSettings
{
	public static string ConnectionStringMsSql => "Data Source=localhost;Initial Catalog=TestingPocos;Integrated Security=True;TrustServerCertificate=True;";
	public static string ConnectionStringSqlite => @"Data Source=D:\UserData\Documents\AppDev\NpocoMapper\NpocoMapper.Demo\db\TestGen.sqlite;";
}
