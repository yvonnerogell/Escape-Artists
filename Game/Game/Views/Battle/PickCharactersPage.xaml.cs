using System;
using System.ComponentModel;
using System.Collections.Generic;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;

using Game.GameRules;
using System.Linq;
using Xamarin.Essentials;

namespace Game.Views
{
    /// <summary>
    /// Selecting Characters for the Game
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0019:Use pattern matching", Justification = "<Pending>")]
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickCharactersPage : ContentPage
    {

        // Empty Constructor for UTs
        public PickCharactersPage(bool UnitTest) { }

        //Instance needed for populating the characters
        public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        public List<CharacterModel> selectedCharacters = new List<CharacterModel>();

        // The view model, used for data binding
        public CharacterIndexViewModel ViewModel = CharacterIndexViewModel.Instance;

        /// <summary>
        /// Constructor for Index Page, Instantiates the binding content, ensures
        /// the list is clear for the character party and sets up current stub data
        /// Get the CharacterIndexView Model
        /// </summary>
        public PickCharactersPage()
        {
            InitializeComponent();

            BindingContext = ViewModel;

            // Clear the Database List and the Party List to start
            BattleEngineViewModel.Instance.PartyCharacterList.Clear();

            UpdateNextButtonState();
        }

        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnDatabaseCharacterItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            CharacterModel data = args.SelectedItem as CharacterModel;
            if (data == null)
            {
                return;
            }

            // Don't add more than the party max
            if (BattleEngineViewModel.Instance.PartyCharacterList.Count() < BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters)
            {
                BattleEngineViewModel.Instance.PartyCharacterList.Add(data);
            }
        }

        /// <summary>
        /// Method to add or remove a character to/from the party list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnCharacter_Clicked(object sender, EventArgs args)
        {
            List<Tuple<string, bool>> is_added = new List<Tuple<string, bool>>();
            //Create charactermodel from the character selected
            var button = sender as ImageButton;
            String characterId = button.CommandParameter as String;
          
            CharacterModel data = ViewModel.Dataset.FirstOrDefault(itm => itm.Id == characterId);
            if (data == null)
            {
                return;
            }
            if (selectedCharacters.Contains(data))
            {
                BattleEngineViewModel.Instance.PartyCharacterList.Remove(data);
                selectedCharacters.Remove(data);
                button.BackgroundColor = Color.Transparent;
            }
            //the selected characters list does not contain the character and max not reached
            else if (BattleEngineViewModel.Instance.PartyCharacterList.Count() < BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters)
            {
                //Add character to the instance partcharacterlist
                BattleEngineViewModel.Instance.PartyCharacterList.Add(data);
                selectedCharacters.Add(data);
                button.BackgroundColor = (Color)ColorConverters.FromHex("25a46d");
            }
            UpdateNextButtonState();
        }

        /// <summary>
        /// Next Button is based on the count
        /// If no selected characters, disable
        /// Show the Count of the party
        /// </summary>
        public void UpdateNextButtonState()
        {
            var currentCount = BattleEngineViewModel.Instance.PartyCharacterList.Count();
            if (currentCount > 0)
            {
                BeginBattleButton.IsEnabled = true;
            }
            else
            {
                //If no characters disable Next button
                BeginBattleButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Jump to the newRoundPage when Battle Button is clicked
        /// Its Modal because don't want user to come back...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void BattleButton_Clicked(object sender, EventArgs e)
        {
            CreateEngineCharacterList();

            // Set initial State to Starting
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Starting;

            // Start the battle
            BattleEngineViewModel.Instance.Engine.StartBattle(false);

            //await Navigation.PushModalAsync(new NavigationPage(new NewRoundPage()));
            await Navigation.PushAsync(new NewRoundPage());
            if (Navigation.NavigationStack.Count > 2)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
        }

        /// <summary>
        /// Clear out the old list and make the new list
        /// </summary>
        public void CreateEngineCharacterList()
        {
            // Clear the currett list
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();

            // Load the Characters into the Engine
            foreach (var data in BattleEngineViewModel.Instance.PartyCharacterList)
            {
                data.CurrentHealth = data.GetMaxHealthTotal;
                BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            }
        }
    }
}
