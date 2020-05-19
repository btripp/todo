using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;


namespace Todo
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public Page MainPage => Application.Current.MainPage;
		
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged(string name)
		{
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

		internal virtual Task Initialize(params object[] args)
		{
			return Task.FromResult(0);
		}

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		protected void OnPropertyChanged(object property)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(property)));
		}

		protected void SetObservableProperty<T>(
			ref T field,
			T value,
			[CallerMemberName] string propertyName = "")
		{
			if (EqualityComparer<T>.Default.Equals(field, value)) return;
			field = value;
			OnPropertyChanged(propertyName);
		}
	}
}

