namespace ProyectoFutbol
{
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class Config
	{
		public string DefaultBrowser = ConfigurationManager.AppSettings["DefaultBrowser"];

		public string TransferMrktURL = ConfigurationManager.AppSettings["TransferMrktURL"];

		public string PromiedosURL = ConfigurationManager.AppSettings["Promiedos"];

		public string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
	}
}