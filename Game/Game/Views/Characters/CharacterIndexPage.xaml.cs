using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Characters
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterIndexPage : ContentPage
	{

		// The view model, used for data binding
		// readonly GenericViewModel<ItemModel> viewModel;

		// Empty Constructor for UTs
		public CharacterIndexPage(bool UnitTest) { }


		public CharacterIndexPage()
		{
			InitializeComponent();

			// BindingContext = viewModel;

		}
	}
}