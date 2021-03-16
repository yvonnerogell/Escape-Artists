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
        public PlayerInfoModel nextPlayer;

		// This uses the Instance so it can be shared with other Battle Pages as needed
		public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        // Empty Constructor for UTs
        public bool UnitTestSetting = false;
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

            // If this is the first round, no need to start a new round (was started on previous page by calling StartBattle)
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.RoundCount > 1)
			{
                BattleEngineViewModel.Instance.Engine.Round.NewRound();
            }

            nextPlayer = EngineViewModel.Engine.Round.GetNextPlayerTurn();

            EngineViewModel.Engine.EngineSettings.CurrentAttacker = nextPlayer;
        }



        /// <summary>
        /// Start next Round, returning to the battle screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void BeginSimpleButton_Clicked(object sender, EventArgs e)
		{
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnum.SimpleNext;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.NewRound;
            if (nextPlayer.PlayerType == PlayerTypeEnum.Character)
			{
                await Navigation.PushAsync(new BattlePageTwo());
            }
            if (nextPlayer.PlayerType == PlayerTypeEnum.Monster)
			{
                EngineViewModel.Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
                var RoundCondition = EngineViewModel.Engine.Round.RoundNextTurn();
                var result = SetBattleStateEnum(RoundCondition);
                await Navigation.PushAsync(new BattlePageOne());
            }
            if (Navigation.NavigationStack.Count > 2)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
        }

        /// <summary>
        /// Sets the battle state enum depending on the RoundCOndition
        /// </summary>
        /// <param name="RoundCondition"></param>
        /// <returns></returns>
        public bool SetBattleStateEnum(RoundEnum RoundCondition)
        {
            switch (RoundCondition)
            {
                case RoundEnum.GameOver:
                case RoundEnum.GraduationCeremony:
                    BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;
                    break;
                case RoundEnum.NewRound:
                    BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.NewRound;
                    break;
                case RoundEnum.NextTurn:
                    BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;
                    break;
                default:
                    BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Unknown;
                    break;
            }
            return true;
        }

        /// <summary>
        /// Start next Round, returning to the battle screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void BeginGridButton_Clicked(object sender, EventArgs e)
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnum.MapNext;
            if (!UnitTestSetting)
            {
                await Navigation.PushAsync(new BattleGridPage());
            }
            if (Navigation.NavigationStack.Count > 2)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
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
            //await Navigation.PopModalAsync();
            await Navigation.PopAsync();
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