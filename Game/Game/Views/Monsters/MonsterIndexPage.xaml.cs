﻿using System;
using System.Linq;
using Game.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.ViewModels;
using Game.Views.Monsters;

namespace Game.Views.Characters
{
	/// <summary>
	/// The Index Page for Monsters
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonsterIndexPage : ContentPage
	{

		// The view model, used for data binding
		readonly MonsterIndexViewModel ViewModel = MonsterIndexViewModel.Instance;

		// Empty Constructor for UTs
		public MonsterIndexPage(bool UnitTest) { }

		// Constructor for Index. Initialized with ViewModel bindingcontext. 
		public MonsterIndexPage()
		{
			InitializeComponent();

			BindingContext = ViewModel;

		}

		/// <summary>
		/// Call to Add a new Monster
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void AddMonster_Clicked(object sender, EventArgs e)
		{
			 await Navigation.PushModalAsync(new NavigationPage(new MonsterCreatePage()));
		}

		/// <summary>
		/// Redirect to the read page for the clicked Monster.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void ReadMonster_Clicked(object sender, EventArgs args)
		{
			var button = sender as ImageButton;

			String monsterId = button.CommandParameter as String;
			MonsterModel data = ViewModel.Dataset.FirstOrDefault(itm => itm.Id == monsterId);
			if (data == null)
			{
				return;
			}

			// Open the Read Page
			await Navigation.PushAsync(new MonsterReadPage(new GenericViewModel<MonsterModel>(data)));
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