using Xamarin.Forms;

namespace Peter
{
	public class InitialPageModel : IViewModel
	{
		private INavigation navigation;

		public InitialPageModel (INavigation navigation)
		{
			this.navigation = navigation;
		}

		public int DrinkingHours {
			get { return this.drinkingHours; }
			set {
				if (this.drinkingHours != value) {
					this.drinkingHours = value;
					OnPropertyChanged ("DrinkingHours");
					OnPropertyChanged ("DrinkingHoursDisplay");
				}
			}
		}
		private int drinkingHours = 5;

		public string DrinkingHoursDisplay {
			get {
				return this.DrinkingHours + " hours";
			}
		}

		private Command pressMeCommand;
		public Command PressMeCommand {
			get { return pressMeCommand ?? (pressMeCommand = new Command (ExecutePressMeCommand)); }
		}

		private void ExecutePressMeCommand() {
			navigation.PushAsync (new InstructionsPage(this.DrinkingHours));
		}
	}
}

