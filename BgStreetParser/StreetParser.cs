using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BgStreetParser;
using HtmlAgilityPack;

namespace BgStreetParser
{
	internal class StreetParser
	{
		private const string UrlPrefix = "http://dic.academic.ru/dic.nsf/ruwiki/";
		private const string StreetsUrl = "http://dic.academic.ru/dic.nsf/ruwiki/348603";
		private const string BridgesUrl = "http://dic.academic.ru/dic.nsf/ruwiki/1568788";
		private static readonly string CacheDirectory = Path.Combine(Directory.GetCurrentDirectory(), "data");        
		private string _currCategory = "";
		private char _currLetter = ' ';

		private Random _random = new Random();

		public List<Street> Download()
		{
			if (!Directory.Exists(CacheDirectory))
			{
				Directory.CreateDirectory(CacheDirectory);
			};

			var http = new WebClient { Encoding = Encoding.UTF8 };
			var content = http.DownloadString(BridgesUrl);
			var doc = new HtmlDocument();
			doc.LoadHtml(content);
			var ret = ParseBridges(doc);

			content = http.DownloadString(StreetsUrl);
			doc = new HtmlDocument();
			doc.LoadHtml(content);
			ret.AddRange(ParseStreets(doc));
			return ret;
		}

		public List<Street> ParseBridges(HtmlDocument html)
		{
			var elements =
				html.DocumentNode.SelectNodes(
					@"//*[@id=""mw-content-text""]/ul | //*[@class=""mw-headline""]");

			var streets = new List<Street>();
			_currCategory = "Мосты";
			foreach (var el in elements)
			{
				if (el.Name == "span")
				{
					if (el.InnerText.Contains("Утраченные мосты"))
					{
						break;
					}
					else
					{
						continue;
					}
				}
				else if (el.Name == "ul")
				{
					streets.AddRange(ParseStreets(el));
				}				
				else
				{
					throw new Exception("unable to parse");
				}
			}
			Parallel.ForEach(streets, new ParallelOptions { MaxDegreeOfParallelism = 100 }, ParseDetails);
			return streets;
		}

		public List<Street> ParseStreets(HtmlDocument html)
		{
			var elements =
				html.DocumentNode.SelectNodes(
					@"//*[@id=""mw-content-text""]/div[3]/ul | //*[@id=""mw-content-text""]/div[3]/h2 | //*[@id=""mw-content-text""]/div[3]/h3");


			var streets = new List<Street>();
			foreach (var el in elements)
			{
				if (el.Name == "h2")
				{
					_currCategory = el.InnerText.Trim();
				}
				else if (el.Name == "h3")
				{
					_currLetter = el.InnerText.Trim()[0];
				}
				else if (el.Name == "ul")
				{
					streets.AddRange(ParseStreets(el));
				}
				else
				{
					throw new Exception("lalka");
				}
			}
			Parallel.ForEach(streets, new ParallelOptions { MaxDegreeOfParallelism = 100 }, ParseDetails);
			return streets;
		}

		private IEnumerable<Street> ParseStreets(HtmlNode ul)
		{
			var streets = new List<Street>();

			var list = ul.SelectNodes("li");

			return list
				.Select(p => new Street
							 {
								 Title = p.InnerText,
								 Category = _currCategory,
								 Letter = _currLetter,
								 Url = p.SelectSingleNode("a") == null ? null : UrlPrefix + p.SelectSingleNode("a").GetAttributeValue("href", "zzz")
							 }).ToList();

			return streets;
		}

		private void ParseDetails(Street street)
		{
			if (street.Url != null)
			{
				HtmlDocument doc = null;

				int retryCount = 10;
				for (int i = 0; i < retryCount; i++)
				{
					try
					{
						var cacheFile = Path.Combine(CacheDirectory, street.Url.Substring(street.Url.LastIndexOf('/') + 1) + ".html");
						string contents = null;
						if (File.Exists(cacheFile))
						{
							contents = File.ReadAllText(cacheFile, Encoding.UTF8);
						}
						else
						{
							var http = new WebClient { Encoding = Encoding.UTF8, };
							contents = http.DownloadString(street.Url);
							File.WriteAllText(cacheFile, contents, Encoding.UTF8);
						}
						doc = new HtmlDocument();
						doc.LoadHtml(contents);
						break;
					}
					catch
					{
						if (i >= retryCount - 1)
						{
							throw;
						}
						Thread.Sleep(TimeSpan.FromSeconds(_random.Next(1, 10)));
					}
				}


				var content = doc.DocumentNode.SelectSingleNode(@"//*[@id=""mw-content-text""]/table[1]/tr[./td[contains(.,'Прежние')]]/td[2]");
				if (content != null)
				{
					var separators = new[] { "\n", ", " };
					street.PreviousNames.AddRange(content.InnerText.Split(separators, StringSplitOptions.None));
				}

				content = doc.DocumentNode.SelectSingleNode(@"//*[@id=""mw-content-text""]/table[1]/tr[./td[contains(.,'Район')]]/td[2]");
				if (content != null)
				{
					street.District = content.InnerText;
				}

				content = doc.DocumentNode.SelectSingleNode(@"//*[@id=""coordinates""]");
				if (content != null)
				{
					street.Coordinate = GeoUtil.ParseCoordinate(content.InnerText);
				}
			}

			if (street.Coordinate == null)
			{
				street.Coordinate = GeoUtil.GetCoordinateByCode("Санкт-Петербург," + street.Title);
			}
		}
	}

}
