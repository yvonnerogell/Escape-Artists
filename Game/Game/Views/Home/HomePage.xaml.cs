using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public HomePage ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Example of a Button Click (this one is Sync, if calling Async then needs to be Async)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public async void GameButton_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new GamePage());
		}

		/// <summary>
		/// Button clicked for opening about page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void AboutButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AboutPage());
		}

		/// <summary>
		/// Button clicked for opening score page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void ScoreButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ScoreIndexPage());
		}
	}
}