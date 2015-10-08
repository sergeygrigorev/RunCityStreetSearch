using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using BgStreetParser;

namespace UI
{
	public partial class MainForm : Form
	{
		private List<Street> _streets;
		private string _dbPath = @"D:\Dev\C#\BgStreetParser\BgStreetParser\bin\Debug\res.xml";

		public List<Street> Streets
		{
			get
			{

				if (_streets == null)
				{
					StreamReader reader = new StreamReader(new FileStream(_dbPath, FileMode.Open), new UTF8Encoding());
					_streets = (List<Street>)new XmlSerializer(typeof(List<Street>)).Deserialize(reader);
					_streets.Sort((p,q) => { var i = p.Category.CompareTo(q.Category); return i == 0 ? p.Title.CompareTo(q.Title) : i; });
				}
				return _streets;
			}
		}

		public MainForm()
		{
			InitializeComponent();
			textBox1_TextChanged(null, EventArgs.Empty);
			comboBox1.Items.Add("Все");
			comboBox1.Items.AddRange(Streets.Select(p => p.Category).Distinct().ToArray());
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Refresh();
		}
		
		private void Refresh()
		{
			IEnumerable<Street> filtered = Streets;
			string text = textBox1.Text.ToLowerInvariant();
			bool isStreet = checkBox1.Checked;

			if (text.Length > 0 && text[0] == '/')
			{
				Regex r;
				try
				{
					r = new Regex(text.Substring(1));
				}
				catch
				{
					textBox1.BackColor = Color.LightSalmon;
					return;
				}
				filtered = filtered.Where(p => StreetSelectionPredicate(p, r.IsMatch, checkBox1.Checked));

			}
			else if (text.Length == 1)
			{
				char letter = text.ToUpperInvariant()[0];
				filtered = filtered.Where(p => p.Letter == letter);
			}
			else if (text.Any())
			{
				filtered = filtered.Where(p => StreetSelectionPredicate(p, t => t.Contains(text), checkBox1.Checked));
			}

			var comboText = comboBox1.SelectedItem as string ?? "";
			if (comboText != "" && comboText != "Все")
				filtered = filtered.Where(p => p.Category == comboText);

			textBox1.BackColor = SystemColors.Window;
			
			dataGridView1.DataSource = filtered.ToList();
		}

		private bool StreetSelectionPredicate(Street s, Func<string, bool> filter, bool oldNames)
		{
			return filter(s.Title.ToLowerInvariant()) || (oldNames && s.PreviousNames.Exists(p => filter(p.ToLowerInvariant())));
		}
		
		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			var i = e.ColumnIndex;
			if (i == 2)
			{
				var s = dataGridView1.Rows[e.RowIndex].Cells[i].Value as string;
				if (s != null)
					System.Diagnostics.Process.Start(s);
			}
			if (i == 0)
			{
				var s = dataGridView1.Rows[e.RowIndex].Cells[i].Value as string;
				var str = _streets.FirstOrDefault(p => p.BigTitle == s);
				MessageBox.Show(str.Title + Environment.NewLine + Environment.NewLine + string.Join("\n", str.PreviousNames));
			}
			if (i == 1)
			{
				var s = dataGridView1.Rows[e.RowIndex].Cells[i].Value as string;
				if (comboBox1.SelectedItem as string != s)
					comboBox1.SelectedItem = s;
				else comboBox1.SelectedItem = "Все";
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			Refresh();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Refresh();
		}
	}
}
