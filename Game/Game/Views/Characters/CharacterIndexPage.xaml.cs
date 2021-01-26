﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models;

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
		readonly CharacterIndexViewModel ViewModel = CharacterIndexViewModel.Instance;

		// Empty Constructor for UTs
		public CharacterIndexPage(bool UnitTest) { }


		public CharacterIndexPage()
		{
			InitializeComponent();

			BindingContext = ViewModel;

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
			// await Navigation.PushModalAsync(new NavigationPage(new CharacterReadPage(viewModel)));
		}

		/// <summary>
		/// Refresh the list on page appearing
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();

			BindingContext = null;

			// If no data, then set it for needing refresh
			if (ViewModel.Dataset.Count == 0)
			{
				ViewModel.SetNeedsRefresh(true);
			}

			// If the needs Refresh flag is set update it
			if (ViewModel.NeedsRefresh())
			{
				ViewModel.LoadDatasetCommand.Execute(null);
			}

			BindingContext = ViewModel;
		}
	}
}