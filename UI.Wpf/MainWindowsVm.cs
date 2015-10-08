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
	public class MainWindowsVm:INotifyPropertyChanged
	{
		private bool _isStreet;
		private string _searchText;

		public string SearchText
		{
			get { return _searchText; }
			set
			{
				if (value == _searchText) return;
				_searchText = value;
				OnPropertyChanged();
			}
		}


		public bool IsStreet
		{
			get { return _isStreet; }
			set
			{
				if (value.Equals(_isStreet)) return;
				_isStreet = value;
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
