using System;
using System.Linq;
using System.Configuration;
using System.Web;

namespace NpocoMapper.Demo.Services
{
	public static class AppSettings
	{
		private static string _connectionString = null;
		public static string ConnectionString
		{
			get
			{
				if (_connectionString == null)
				{
					if (IsProduction)
					{
						_connectionString = Environment.GetEnvironmentVariable("CROSSERATOR_DB_PROD");

						if (_connectionString == null)
							throw new ArgumentNullException("CROSSERATOR_DB_PROD environment variable is missing.");
					}
					else
					{
						_connectionString = Environment.GetEnvironmentVariable("CROSSERATOR_DB");

						if (_connectionString == null)
							throw new ArgumentNullException("CROSSERATOR_DB environment variable is missing.");
					}
				}
				return _connectionString;
			}
		}


		private static string _mailgunAuthValue = null;
		public static string MailgunAuthValue
		{
			get
			{
				if (_mailgunAuthValue == null)
				{
					_mailgunAuthValue = Environment.GetEnvironmentVariable("MAILGUN_AUTH_VALUE");

					if (_mailgunAuthValue == null)
						throw new ArgumentNullException("MAILGUN_AUTH_VALUE environment variable is missing.");
				}
				return _mailgunAuthValue;
			}
		}

		private static string _mailgunFromDomain = null;
		public static string MailgunFromDomain
		{
			get
			{
				if (_mailgunFromDomain == null)
					_mailgunFromDomain = ConfigurationManager.AppSettings["mailgunFromDomain"];

				return _mailgunFromDomain;
			}
		}

		private static string _mailgunFromAddress = null;
		public static string MailgunFromAddress
		{
			get
			{
				if (_mailgunFromAddress == null)
					_mailgunFromAddress = ConfigurationManager.AppSettings["mailgunFromAddress"];

				return _mailgunFromAddress;
			}
		}


		private static bool _isProductionIsSet = false;
		private static bool _isProductionValue = false;
		public static bool IsProduction
		{
			get
			{
				if (!_isProductionIsSet)
				{
					string isProductionVal = ConfigurationManager.AppSettings["isProduction"];

					if (isProductionVal == null)
						isProductionVal = Environment.GetEnvironmentVariable("IS_PRODUCTION");

					if (isProductionVal == null)
						throw new ArgumentNullException("IS_PRODUCTION environment variable is missing.");

					_isProductionValue = Convert.ToBoolean(isProductionVal);
					_isProductionIsSet = true;
				}
				return _isProductionValue;
			}

			set
			{
				_isProductionValue = value;
				_isProductionIsSet = true;
			}
		}

		private static int _buildNumber = 0;
		public static int BuildNumber
		{
			get
			{
				if (_buildNumber == 0)
				{
					_buildNumber = Int32.Parse(ConfigurationManager.AppSettings["buildNumber"]);
				}
				return _buildNumber;
			}
		}


		private static string _apPath = "";
		public static string ApPath
		{
			get
			{
				if (_apPath == "")
				{
					_apPath = ConfigurationManager.AppSettings["apPath"];
				}
				return _apPath;
			}
		}


		private static string _plantPicFilePath = "";
		public static string PlantPicFilePath
		{
			get
			{
				if (_plantPicFilePath == "")
				{
					string root = ConfigurationManager.AppSettings["apFilePath"];

					//if (String.IsNullOrEmpty(_root) && HttpContext.Current != null)
					//	_root = HttpContext.Current.Request.PhysicalApplicationPath;

					if (String.IsNullOrEmpty(root))
						throw new ArgumentNullException("File path is missing.");

					_plantPicFilePath = System.IO.Path.Combine(
						root,
						ConfigurationManager.AppSettings["plantPicFilePath"]);
				}
				return _plantPicFilePath;
			}
		}

	}
}
