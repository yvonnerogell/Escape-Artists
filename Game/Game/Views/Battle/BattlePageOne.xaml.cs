using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;

namespace Game.Views
{
    /// <summary>
    /// Battle Page One displays the results of a turn
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    public partial class BattlePageOne : ContentPage
    {
        // Variable holding the next player of the game
        public PlayerInfoModel nextPlayer;

        // HTML Formatting for message output box
        public HtmlWebViewSource htmlSource = new HtmlWebViewSource();

        // Wait time before proceeding
        public int WaitTime = 1500;

        // Hold the Map Objects, for easy access to update them
        public Dictionary<string, object> MapLocationObject = new Dictionary<string, object>();

        // Variable for unit testing purposes
        public bool UnitTestSetting;

        // Empty Constructor for UTs
        public BattlePageOne(bool UnitTest) { UnitTestSetting = UnitTest; }

        /// <summary>
        /// Constructor
        /// </summary>
        public BattlePageOne()
        {
            InitializeComponent();

            // Set up the UI to Defaults
            BindingContext = BattleEngineViewModel.Instance;

            var currentAttacker = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker;
            var currentDefender = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender;
            PlayerInfoModel currentCharacter;

            if (currentAttacker != null)
            {
                if (currentAttacker.CharacterTypeEnum == CharacterTypeEnum.Parent || currentAttacker.CharacterTypeEnum == CharacterTypeEnum.Student)
                {
                    currentCharacter = currentAttacker;
                }
                else
                {
                    currentCharacter = currentDefender;
                }

                if (currentCharacter != null)
				{
                    GPAValueLabel.Text = GetCharacterGPA(currentCharacter);
                    HealthValueLabel.Text = GetCharacterHealth(currentCharacter);
                    CharacterNameLabel.Text = GetCharacterName(currentCharacter) + " Stats";
                }

                AttackTextLabel.Text = GetAttackText(currentAttacker, currentDefender);
            }

            SetBattleMessage(BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.TurnMessage);

            SetAttackerDefenderImages(currentAttacker, currentDefender);

        }

        /// <summary>
        /// Sets the images of the current attacker and defender
        /// </summary>
        /// <returns></returns>
        public bool SetAttackerDefenderImages(PlayerInfoModel currentAttacker, PlayerInfoModel currentDefender)
		{
            if (currentAttacker == null) 
			{
                return false;
			}

            AttackerImage.Source = currentAttacker.TileImageURI;

            if (currentDefender == null)
			{
                return false;
			}

            DefenderImage.Source = currentDefender.TileImageURI;

            return true;
		}

        /// <summary>
        /// 
        /// Sets the five most recent battle messages to display
        /// </summary>
        /// <returns></returns>
        public void SetBattleMessage(string message)
        {
            BattleMessageLabel.Text = message;
        }


        /// <summary>
        /// 
        /// Returns the attack text for two players. 
        /// TODO: Update to pull data from BattleEngineViewModel. 
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public string GetAttackText(PlayerInfoModel currentAttacker, PlayerInfoModel currentDefender)
        {
            string attackText = "";

            if (currentAttacker.PlayerType == PlayerTypeEnum.Monster)
            {

                if (currentDefender == null)
                {
                    return currentAttacker.SpecificCharacterTypeEnum.ToMessage() + " " + currentAttacker.Name;
                }

                attackText += currentAttacker.SpecificMonsterTypeEnum.ToMessage();
                attackText += " ";
                attackText += currentAttacker.Name;
                attackText += "\n vs \n";
                attackText += currentDefender.SpecificCharacterTypeEnum.ToMessage();
                attackText += " ";
                attackText += currentDefender.Name;
            }
            if (currentAttacker.PlayerType == PlayerTypeEnum.Character)
            {
                if (currentDefender == null)
				{
                    return currentAttacker.SpecificCharacterTypeEnum.ToMessage() + " " + currentAttacker.Name;
				}

                attackText += currentAttacker.SpecificCharacterTypeEnum.ToMessage();
                attackText += " ";
                attackText += currentAttacker.Name;
                attackText += "\n vs \n";
                attackText += currentDefender.SpecificMonsterTypeEnum.ToMessage();
                attackText += " ";
                attackText += currentDefender.Name;
            }
            return attackText;
        }

        /// <summary>
        /// 
        /// Returns the GPA of the current character. 
        /// </summary>
        /// <returns></returns>
        public string GetCharacterGPA(PlayerInfoModel currentCharacter)
        {
            return currentCharacter.GPA.ToString();
        }

        /// <summary>
        /// 
        /// Returns the health of the current character. 
        /// </summary>
        /// <returns></returns>
        public string GetCharacterHealth(PlayerInfoModel currentCharacter)
        {
            return currentCharacter.CurrentHealth.ToString();
        }

        /// <summary>
        /// 
        /// Returns the name of the current character. 
        /// </summary>
        /// <returns></returns>
        public string GetCharacterName(PlayerInfoModel currentCharacter)
        {
            return currentCharacter.Name;
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
        }


        /// <summary>
        /// Navigates to Battle Page 2
        /// 
        /// All lcoations are empty
        /// </summary>
        /// <returns></returns>
        public async void NextAttackButton_Clicked(object sender, EventArgs e)
        {
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum == BattleStateEnum.RoundOver)
			{
                Debug.WriteLine("Battle State on BattlePageOne: BattleStateEnum.RoundOver.");
                await Navigation.PushAsync(new RoundOverPage());
            }
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum == BattleStateEnum.Battling)
            {
                Debug.WriteLine("Battle State on BattlePageOne: BattleStateEnum.Battling.");
                BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;
                nextPlayer = BattleEngineViewModel.Instance.Engine.Round.GetNextPlayerTurn();
                BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = nextPlayer;
                if (nextPlayer.PlayerType == PlayerTypeEnum.Character)
                {
                    Debug.WriteLine("Next player is character: " + nextPlayer.Name);
                    await Navigation.PushAsync(new BattlePageTwo());
                }
                if (nextPlayer.PlayerType == PlayerTypeEnum.Monster)
                {
                    Debug.WriteLine("Next player is monster: " + nextPlayer.Name);
                    BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
                    var RoundCondition = BattleEngineViewModel.Instance.Engine.Round.RoundNextTurn();
                    var result = SetBattleStateEnum(RoundCondition);
                    await Navigation.PushAsync(new BattlePageOne());
                }
            }
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum == BattleStateEnum.GameOver)
            {
                Debug.WriteLine("Battle State on BattlePageOne: BattleStateEnum.GameOver.");
                // End the battle here
                BattleEngineViewModel.Instance.Engine.EndBattle();
                await Navigation.PushAsync(new GameOverPage());
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
        /// Navigates to Round Over Page. THis is a temporary button, will be removed once battle engine is implemented.
        /// 
        /// All lcoations are empty
        /// </summary>
        /// <returns></returns>
        public async void RoundOverButton_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new RoundOverPage()));
            await Navigation.PushAsync(new RoundOverPage());
            if (Navigation.NavigationStack.Count > 2)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
        }
       
        #region PageHandelers

        /// <summary>
        /// Battle Over, so Exit Button
        /// Need to show this for the user to click on.
        /// The Quit does a prompt, exit just exits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ExitButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

		#endregion PageHandelers
	}
}