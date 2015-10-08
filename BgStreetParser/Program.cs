using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using HtmlAgilityPack;

namespace BgStreetParser
{
	class Program
	{
		const string RootUrl = "http://dic.academic.ru/dic.nsf/ruwiki/348603";


		static void Main(string[] args)
		{
			var http = new WebClient {Encoding = Encoding.UTF8};
			var content = http.DownloadString(RootUrl);
			var doc = new HtmlDocument();
			doc.LoadHtml(content);
			var streets = new StreetParser().Parse(doc);
			var tw = new StreamWriter(new FileStream("res.xml", FileMode.Create), new UTF8Encoding());
			new XmlSerializer(typeof (List<Street>)).Serialize(tw, streets);
		}
	}
}
