using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Peter
{
	public class InstructionsPage : ContentPage
	{
		private readonly ObservableCollection<InstructionsItem> instructions;

		public InstructionsPage (int hours)
		{
			Title = "Peter's To Do";

			instructions = new ObservableCollection<InstructionsItem> ();
			ListView instructionsView = new ListView {
				ItemsSource = instructions,
			};
			instructionsView.ItemTemplate = new DataTemplate (typeof(InstructionsCell));

			// Accomodate iPhone status bar
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);

			Content = new StackLayout {
				Children = {
					instructionsView,
				}
			};

			for (int i = 0; i < hours; i++) {
				instructions.Add (new InstructionsItem (PickRandomInstruction()));
			}
		}

		class InstructionsItem {
			public InstructionsItem (string instructions) {
				this.Instructions = instructions;
			}

			public string Instructions { get; set; }
		}

		class InstructionsCell : ViewCell {
			public InstructionsCell () {
				Label text = new Label {
					HorizontalOptions = LayoutOptions.StartAndExpand
				};
				text.SetBinding (Label.TextProperty, new Binding ("Instructions"));

				View = new StackLayout {
					Children = {
						text
					},
					Padding = 10
				};
			}
		}

		private readonly string[] PossibleInstructions = new string [] {
			"Take a shot",
			"Chug a beer",
			"Do a power hour",
			"Shotgun a beer",
		};

		private readonly Random r = new Random ();

		private string PickRandomInstruction() {
			int index = r.Next (0, PossibleInstructions.Length);
			return PossibleInstructions [index];
		}
	}
}

