﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public GamePage ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Jump to the Game
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public async void ExamRoomButton_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new PickCharactersPage());
		}

		/// <summary>
		/// Jump to the School which lists out character/monster/items/score
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void SchoolButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SchoolPage());
		}

		/// <summary>
		/// Jump to the Auto  Game
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void AutobattleButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AutoBattlePage());
		}

		/// <summary>
		/// Jump to the Game Settings
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void GameSettingButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new BattleSettingsPage()));
		}
	}
}