using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Xml;

namespace BgStreetParser
{
	public class GeoUtil
	{
		private static Regex degreeRegex = new Regex(@"\d{2}°\d{2}′\d{2}″", RegexOptions.Compiled);
		private static Regex decimalRegex = new Regex(@"\d{2}\.\d{3}\d*", RegexOptions.Compiled);

		public static double Distance(Coordinate point1, Coordinate point2)
		{
			// copied sowhere from stackoverflow
			double lat1 = point1.Latitude, lon1 = point1.Longtitude, lat2 = point2.Latitude, lon2 = point2.Longtitude;
			var R = 6378.137; // Radius of earth in KM
			var dLat = lat2 * Math.PI / 180 - lat1 * Math.PI / 180;
			var dLon = lon2 * Math.PI / 180 - lon1 * Math.PI / 180;
			var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
			Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
			Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
			var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
			var d = R * c;
			return d * 1000; // meters
		}

		public static Coordinate ParseCoordinate(string geoExpr, CoordinateFormat format = CoordinateFormat.LatitudeThenLongtitude)
		{
			var latLongMatches = decimalRegex.Matches(geoExpr);

			double firstValue = -1;
			double secondValue = -1;
			if (latLongMatches.Count > 1)
			{
				firstValue = double.Parse(latLongMatches[0].Value, CultureInfo.InvariantCulture);
				secondValue = double.Parse(latLongMatches[1].Value, CultureInfo.InvariantCulture);				
			}

			latLongMatches = degreeRegex.Matches(geoExpr);
			if (latLongMatches.Count > 1)
			{
				firstValue = ParseGeoExpr(latLongMatches[0].Value);
				secondValue = ParseGeoExpr(latLongMatches[1].Value);
			}

			if (firstValue > 0 && secondValue > 0)
			{
				if (format == CoordinateFormat.LatitudeThenLongtitude)
				{
					return new Coordinate { Latitude = firstValue, Longtitude = secondValue };
				}
				else
				{
					return new Coordinate { Latitude = secondValue, Longtitude = firstValue };
				}
			}
			return null;
		}

		public static Coordinate GetCoordinateByCode(string geoCode)
		{
			string yaMapsUrlTemplate = "https://geocode-maps.yandex.ru/1.x/?geocode={0}&lang=ru";
			var http = new WebClient { Encoding = Encoding.UTF8, };
			var contents = http.DownloadString(string.Format(yaMapsUrlTemplate, geoCode));

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(contents);
			
			var points = xmlDoc.GetElementsByTagName("Point");
			if (points.Count > 0)
			{
				return ParseCoordinate(points[0].OuterXml.ToString(), CoordinateFormat.LongtitudeThenLatitude);
			}

			return null;
		}

		private static double ParseGeoExpr(string geoExpr)
		{
			if (geoExpr.Length == 9)
			{
				return int.Parse(geoExpr.Substring(0, 2), CultureInfo.InvariantCulture) + int.Parse(geoExpr.Substring(3, 2), CultureInfo.InvariantCulture) / 60.0 + int.Parse(geoExpr.Substring(6, 2), CultureInfo.InvariantCulture) / 3600.0;
			}
			return 0;
		}
	}

	public enum CoordinateFormat
	{
		LatitudeThenLongtitude = 1,
		LongtitudeThenLatitude = 2,
	}
}
