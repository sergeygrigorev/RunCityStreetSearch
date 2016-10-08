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


		static void Main(string[] args)
		{
			var geoObjects = new StreetParser().Download();
			var tw = new StreamWriter(new FileStream("res.xml", FileMode.Create), new UTF8Encoding());
			new XmlSerializer(typeof (List<Street>)).Serialize(tw, geoObjects);
		}
	}
}
