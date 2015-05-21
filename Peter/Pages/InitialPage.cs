using Xamarin.Forms;

namespace Peter
{
	public class InitialPage : ContentPage
	{
		public InitialPage ()
		{
			BindingContext = new InitialPageModel (this.Navigation);

			Title = "Welcome to Peter";

			Label timeLabel = new Label {
				HorizontalOptions = LayoutOptions.Center,
			};
			timeLabel.SetBinding<InitialPageModel> (Label.TextProperty, vm => vm.DrinkingHoursDisplay);

			Slider timeSlider = new Slider (1, 24, 5) {
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			timeSlider.SetBinding<InitialPageModel> (Slider.ValueProperty, vm => vm.DrinkingHours, BindingMode.TwoWay);

			Button pressMe = new Button {
				Text = "Help Peter",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				FontSize = 60,
				HeightRequest = 200,
				BackgroundColor = Color.Yellow,
			};
			pressMe.SetBinding<InitialPageModel> (Button.CommandProperty, vm => vm.PressMeCommand);

			Content = new StackLayout {
				Children = {
					timeLabel,
					timeSlider,
					pressMe,
				}
			};
		}
	}
}

