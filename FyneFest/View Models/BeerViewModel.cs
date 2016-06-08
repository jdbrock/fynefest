using System;
using PropertyChanged;
using System.ComponentModel;

namespace FyneFest
{
	[ImplementPropertyChanged]
	public class BeerViewModel : INotifyPropertyChanged
	{
		private bool _isExpanded;

		public bool IsExpanded
		{
			get
			{
				return _isExpanded;
			}
			set
			{
				_isExpanded = value;
				RaisePropertyChanged("IsExpanded");
			}
		}

//		public String StatusImageUri
//		{
//			get
//			{
//				if (Beer.MetaData.IsTicked)
//					return "checkmark-white.png";
//				else if (Beer.MetaData.IsFavorited)
//					return "heart-filled-white.png";
//				else
//					return "";
//			}
//		}

		public Boolean IsTickedNotExpanded { get { return Beer.MetaData.IsTicked && !IsExpanded; } }

		public Beer Beer { get; }

		public BeerViewModel (Beer beer)
		{
			Beer = beer;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged(String propertyName)
		{
			var handler = PropertyChanged;

			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

