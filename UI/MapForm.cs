using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UI
{
	public partial class MapForm : Form
	{
		private const string Template = "file:///{0}/Html/index.html?w={1}&h={2}&s={3}";

		private Point res;
		private string s;
		private string coords = "";

		public MapForm(string search = "")
		{
			InitializeComponent();

			browser.ScriptErrorsSuppressed = true;
			browser.ScrollBarsEnabled = false;
			browser.Navigate(String.Format(Template, Directory.GetCurrentDirectory(), browser.Size.Width, browser.Size.Height, search));
		}

		public Point GetPoint()
		{
			return res;
		}

		public string GetCoords()
		{
			return coords;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			List<Point> list = new List<Point>();
			string title = browser.DocumentTitle;
			Regex r = new Regex(@"\[([0-9.-]+),([0-9.-]+)\]");
			MatchCollection matches = r.Matches(title);
			foreach (Match m in matches)
			{
				list.Add(new Point(Double.Parse(m.Groups[1].Value.Replace('.', ',')), Double.Parse(m.Groups[2].Value.Replace('.', ','))));
			}

			coords = list.Count == 0 ? "" : list.Last().ToString();
			
			base.OnClosing(e);
		}
	}
}
