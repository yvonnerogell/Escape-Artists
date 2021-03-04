using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using Game.Models;
using Game.ViewModels;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewRoundPage: ContentPage
	{
		// This uses the Instance so it can be shared with other Battle Pages as needed
		public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        // Empty Constructor for UTs
        bool UnitTestSetting;
        public NewRoundPage(bool UnitTest) { UnitTestSetting = UnitTest; }
        /// <summary>
        /// Constructor
        /// </summary>
        public NewRoundPage ()
		{
			InitializeComponent ();

			// Draw the Characters
			foreach (var data in EngineViewModel.Engine.EngineSettings.CharacterList)
			{
                PartyListFrame.Children.Add(CreatePlayerDisplayBox(data));
			}

			// Draw the Monsters
			foreach (var data in EngineViewModel.Engine.EngineSettings.MonsterList)
			{
				MonsterListFrame.Children.Add(CreatePlayerDisplayBox(data));
			}

            

        }

        /// <summary>
        /// Settings Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Settings_Clicked(object sender, EventArgs e)
        {
            await ShowBattleSettingsPage();
        }

        /// <summary>
        /// Show Settings
        /// </summary>
        public async Task ShowBattleSettingsPage()
        {
            ShowBattleMode();
            await Navigation.PushModalAsync(new BattleSettingsPage());
        }

        /// <summary>
        /// Show the proper Battle Mode
        /// </summary>
        public void ShowBattleMode()
        {
            // If running in UT mode, 
            if (UnitTestSetting)
            {
                return;
            }

            //HideUIElements();

           //ClearMessages();

            //DrawPlayerBoxes();

            // Update the Mode
            BattleModeValue.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum.ToMessage();

//            ShowBattleModeDisplay();

  //          ShowBattleModeUIElements();
        }



        /// <summary>
        /// Start next Round, returning to the battle screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void BeginButton_Clicked(object sender, EventArgs e)
		{
            switch (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum)
            {
                case BattleModeEnum.MapAbility:
                case BattleModeEnum.MapFull:
                case BattleModeEnum.MapNext:
                    await Navigation.PushModalAsync(new NavigationPage(new BattleGridPage()));
                    break;

                case BattleModeEnum.SimpleAbility:
                case BattleModeEnum.SimpleNext:
                case BattleModeEnum.Unknown:
                default:
                    await Navigation.PushModalAsync(new NavigationPage(new BattlePageOne()));
                    break;
            }
        }

        /// <summary>
        /// Battle Over, so Exit Button
        /// Need to show this for the user to click on.
        /// The Quit does a prompt, exit just exits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ExitButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Return a stack layout with the Player information inside
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout CreatePlayerDisplayBox(PlayerInfoModel data)
		{
            if (data == null)
            {
                data = new PlayerInfoModel();
            }

            // Hookup the image
            var PlayerImage = new Image
            {
                Style = (Style)Application.Current.Resources["ImageBattleLargeStyle"],
                Source = data.ImageURI
            };

            // Add the Level
            var PlayerLevelLabel = new Label
            {
                Text = "Level : "+data.Level,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Add the HP
            var PlayerHPLabel = new Label
            {
                Text = "HP : "+ data.GetCurrentHealthTotal,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            var PlayerNameLabel = new Label()
            {
                Text = data.Name,
                Style = (Style)Application.Current.Resources["ValueStyle"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing=1,
                LineHeight=1,
                MaxLines =1,
            };

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["PlayerInfoBox"],
                HorizontalOptions = LayoutOptions.Center,
                Padding = 0,
                Spacing = 0,
                Children = {
                    PlayerImage,
                    PlayerNameLabel,
                    PlayerLevelLabel,
                    PlayerHPLabel,
                },
            };

            return PlayerStack;
		}
	}
}