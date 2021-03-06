using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;
using Game.Engine.EngineInterfaces;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AutoBattlePage : ContentPage
	{
		// Hold the Engine, so it can be swapped out for unit testing
		public IAutoBattleInterface AutoBattle = BattleEngineViewModel.Instance.AutoBattleEngine;

		/// <summary>
		/// Constructor
		/// </summary>
		public AutoBattlePage ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Any time picker changes, items reset based on player type
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OnPickerSelectedIndexChanged(object sender, EventArgs e)
		{
			var picker = (Picker)sender;

			BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters = (int)picker.SelectedItem;
		}

		/// <summary>
		/// Defines what happens when the AutoBattleButton is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void AutobattleButton_Clicked(object sender, EventArgs e)
		{
			// Clear CharacterList and MonsterList
			BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
			BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Clear();

			// Call into Auto Battle from here to do the Battle...

			// To See Level UP happening, a character needs to be close to the next level
			var Character = new CharacterModel
			{
				ExperienceTotal = 300,    // Enough for next level
				Name = "Mike Level Example",
				Speed = 100,    // Go first
				PlayerType = PlayerTypeEnum.Character,
				CharacterTypeEnum = CharacterTypeEnum.Student
			};

			var CharacterPlayer = new PlayerInfoModel(Character);

			// Turn on the Koenig version for now...
			//BattleEngineViewModel.Instance.SetBattleEngineToKoenig();

			BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters = (int)CharacterPicker.SelectedItem;
			
			if (BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Count < BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters)
            {
				BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(CharacterPlayer);
			}


			await BattleEngineViewModel.Instance.AutoBattleEngine.RunAutoBattle();
			
			var BattleMessage = string.Format("Done {0} Rounds", AutoBattle.Battle.EngineSettings.BattleScore.RoundCount);

			BattleMessageValue.Text = BattleMessage;

			AutobattleImage.Source = "running.gif";
		}
	}
}