using System.ComponentModel;

namespace Peter
{
	public abstract class IViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string name) {
			if (PropertyChanged == null)
				return;

			PropertyChanged (this, new PropertyChangedEventArgs (name));
		}
	}
}