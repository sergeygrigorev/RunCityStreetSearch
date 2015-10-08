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

		private string _currCategory = "";
		private char _currLetter = ' ';

		private Random _random = new Random();

		public List<Street> Parse(HtmlDocument html)
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
			//int i = 0;
			//foreach (var street in streets)
			//{
			//	i++;
			//	GetPreviousNames(street);
			//	if (i == 3)
			//		break;
			//}

			Parallel.ForEach(streets, new ParallelOptions { MaxDegreeOfParallelism = 100 }, GetPreviousNames);

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

			/*return new Street
			{
				Title = ul.InnerText,
				Category = _currCategory,
			};*/
			if (true)
			{
				
			}
			else if (false)
			{

			}
			else
			{
				
			}
			throw new Exception();
			return streets;
			throw new Exception();
		}

		private void GetPreviousNames(Street street)
		{
			if (street.Url == null)
				return;


			HtmlDocument doc = null;

			int retryCount = 10;
			//RetrtAction
			for (int i = 0; i < retryCount; i++)
			{
				try
				{
					var http = new WebClient {Encoding = Encoding.UTF8,};
					doc = new HtmlDocument();
					doc.LoadHtml(http.DownloadString(street.Url));
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
			if (content == null)
				return;

			var separators = new[] { "\n", ", " };
			street.PreviousNames.AddRange(content.InnerText.Split(separators, StringSplitOptions.None));

		}
	}

}
