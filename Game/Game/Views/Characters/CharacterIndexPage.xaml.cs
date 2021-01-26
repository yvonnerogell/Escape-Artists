using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views.Characters
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterIndexPage : ContentPage
	{

		// The view model, used for data binding
		readonly GenericViewModel<ItemModel> viewModel;

		// Empty Constructor for UTs
		public CharacterIndexPage(bool UnitTest) { }


		public CharacterIndexPage()
		{
			InitializeComponent();

			BindingContext = viewModel;

		}

		/// <summary>
		/// Call to Add a new character
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void AddItem_Clicked(object sender, EventArgs e)
		{
			// await Navigation.PushModalAsync(new NavigationPage(new CharacterCreatePage()));
		}

		/// <summary>
		/// Read a Character from list
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void ReadItem_Clicked(object sender, EventArgs e)
		{
			//TODO: logic to open Character page depending on character id

			//TODO: used for now to link to Read.
			await Navigation.PushModalAsync(new NavigationPage(new CharacterReadPage(viewModel)));
		}
	}
}