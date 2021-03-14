using Game.Models;
using Game.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GameOverPage: ContentPage
	{
        // This uses the Instance so it can be shared with other Battle Pages as needed
        public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameOverPage()
        {
            InitializeComponent();
            DrawOutput();
        }

        /// <summary>
        /// Draw data for
        /// Character
        /// Monster
        /// Item
        /// </summary>
        
        public void DrawOutput()
        {
            TotalScore.Text = EngineViewModel.Engine.EngineSettings.BattleScore.ExperienceGainedTotal.ToString();
        }
        

        /// <summary>
        /// Close the Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void CloseButton_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Open up the Your Score Page. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void YourScoreButton_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new ScorePage()));
            await Navigation.PushAsync(new ScorePage());
        }
    }
}