using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UI.Wpf.Annotations;

namespace UI.Wpf
{
	public class StreetInfoVm:INotifyPropertyChanged
	{
		private string _title;
		private string _url;
		private string _category;
		private char _letter;
		private List<string> _previousNames;

		public string Title
		{
			get { return _title; }
			set
			{
				if (value == _title) return;
				_title = value;
				OnPropertyChanged();
			}
		}

		public string Url
		{
			get { return _url; }
			set
			{
				if (value == _url) return;
				_url = value;
				OnPropertyChanged();
			}
		}

		public string Category
		{
			get { return _category; }
			set
			{
				if (value == _category) return;
				_category = value;
				OnPropertyChanged();
			}
		}

		public char Letter
		{
			get { return _letter; }
			set
			{
				if (value == _letter) return;
				_letter = value;
				OnPropertyChanged();
			}
		}

		public List<string> PreviousNames
		{
			get { return _previousNames; }
			set
			{
				if (Equals(value, _previousNames)) return;
				_previousNames = value;
				OnPropertyChanged();
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
