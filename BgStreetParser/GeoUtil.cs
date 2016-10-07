using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace BgStreetParser
{
	public class GeoUtil
	{
		private static Regex degreeRegex = new Regex(@"\d{2}°\d{2}′\d{2}″", RegexOptions.Compiled);
		private static Regex decimalRegex = new Regex(@"\d{2}\.\d{6}\d*", RegexOptions.Compiled);

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

		public static Coordinate ParseCoordinate(string geoExpr)
		{
			var latLongMatches = decimalRegex.Matches(geoExpr);

			if (latLongMatches.Count > 1)
			{
				var latitude = double.Parse(latLongMatches[0].Value, CultureInfo.InvariantCulture);
				var longtitude = double.Parse(latLongMatches[1].Value, CultureInfo.InvariantCulture);
				if (latitude > 0 && longtitude > 0)
				{
					return new Coordinate { Latitude = latitude, Longtitude = longtitude };
				}
			}

			latLongMatches = degreeRegex.Matches(geoExpr);
			if (latLongMatches.Count > 1)
			{
				var latitude = ParseGeoExpr(latLongMatches[0].Value);
				var longtitude = ParseGeoExpr(latLongMatches[1].Value);
				if (latitude > 0 && longtitude > 0)
				{
					return new Coordinate { Latitude = latitude, Longtitude = longtitude };
				}
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
}
