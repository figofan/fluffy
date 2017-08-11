using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CLR.caller
{
	public class CallerInfoAttributeDemo : INotifyPropertyChanged
	{
		public string WhoCalledMe([CallerMemberName] string callingMember = null)
		{
			return "I was called from memeber " + callingMember;
		}

		public string WhatFileCalledMe([CallerFilePath] string callingFile = null)
		{
			return "I was called from file " + callingFile;
		}

		public string WhatLineCalledMe([CallerLineNumber] int callingLineNumber = 0)
		{
			return "I was called from line " + callingLineNumber;
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
