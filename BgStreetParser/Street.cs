using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BgStreetParser
{
	public class Street
	{
		private const string Format = "{0} ({1})";

		public Street()
		{
			PreviousNames = new List<string>();
		}

		public virtual string Title { get; set; }

		[XmlIgnore]
		public string BigTitle
		{
			get
			{
				return PreviousNames.Count > 0 ? String.Format(Format, Title, string.Join(", ", PreviousNames)) : Title;
			}
		}

		public string Url { get; set; }

		public string Category { get; set; }
		public char Letter { get; set; }
		public List<string>  PreviousNames { get; set; }
	}
}