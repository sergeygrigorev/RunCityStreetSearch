using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
	public class Point : IEquatable<Point>
	{
		private double? lat = null, lon = null;

		public Point(string name)
		{
			Name = name;
		}

		public Point(double la, double lo)
		{
			Latitude = la;
			Longitude = lo;
		}

		public string Name { get; set; }

		public double? Latitude
		{
			get { return lat; }
			set
			{
				if (value < -90 || value > 90)
					throw new ArgumentOutOfRangeException("Latitude should be between -90 and 90");
				lat = value;
			}
		}

		public double? Longitude
		{
			get { return lon; }
			set
			{
				if (value < -180 || value > 180)
					throw new ArgumentOutOfRangeException("Longitude should be between -180 and 180");
				lon = value;
			}
		}

		public bool HasCoordinates()
		{
			return lat != null && lon != null;
		}

		public bool Equals(Point other)
		{
			if (other == null)
				return false;
			if (!HasCoordinates() || !other.HasCoordinates())
				return false;
			return Longitude.Equals(other.Longitude) && Latitude.Equals(other.Latitude);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Point);
		}

		public override string ToString()
		{
			return String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.000000}, {1:0.000000}", Latitude, Longitude);
		}
	}
}
