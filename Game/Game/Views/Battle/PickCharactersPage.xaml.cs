using System;
using System.ComponentModel;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;
using Game.GameRules;
using System.Linq;

namespace Game.Views
{
    /// <summary>
    /// Selecting Characters for the Game
    /// 
    /// TODO: Team
    /// Mike's game allows duplicate characters in a party (6 Mikes can all fight)
    /// If you do not allow duplicates, change the code below
    /// Instead of using the database list directly make a copy of it in the viewmodel
    /// Then have on select of the database remove the character from that list and add to the part list
    /// Have select from the party list remove it from the party list and add it to the database list
    ///
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0019:Use pattern matching", Justification = "<Pending>")]
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickCharactersPage : ContentPage
    {

        public static int NUM_CHARACTERS = 7;
        public static int NUM_ITEMS = 5;

        // Empty Constructor for UTs
        public PickCharactersPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Index Page
        /// 
        /// Get the CharacterIndexView Model
        /// </summary>
        public PickCharactersPage()
        {
            InitializeComponent();

            BindingContext = BattleEngineViewModel.Instance;
            //BindingContext = BattleEngineViewModel.Instance;

            // Clear the Database List and the Party List to start
            BattleEngineViewModel.Instance.PartyCharacterList.Clear();

            // Setting up the BattleEngineViewModel with default data to use for testing
            // TODO: Comment this out when ready to use the real battle engine
            // Melissa, you can change the character list as the user is selecting the characters for the game.
            SetUpStubData();


            UpdateNextButtonState();
        }

        public bool SetUpStubData()
		{
            // Add characters to state machine
            var characters = GetCharacterStubList();
            AddStubCharactersToBattleEngineViewModel(characters);

            // Add items to state machine
            var itemsDropped = GetItemStubList();
            AddStubItemsToBattleEngineViewModel(itemsDropped);

            return true;
        }

        /// <summary>
        /// Helper method to get a default character stub list.
        /// </summary>
        /// <returns></returns>
        public List<ItemModel> GetItemStubList()
        {
            List<ItemModel> items = DefaultData.LoadData(new ItemModel());
            List<ItemModel> result = new List<ItemModel>();

            for (var i = 0; i < NUM_ITEMS; ++i)
            {
                result.Add(items.ElementAt(i));
            }
            return result;
        }

        /// <summary>
        /// Add stub characters to battle engine view model.
        /// </summary>
        /// <returns></returns>
        public bool AddStubItemsToBattleEngineViewModel(List<ItemModel> items)
        {
            foreach (var item in items)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(item);
            }
            return true;
        }

        /// <summary>
        /// Add stub characters to battle engine view model.
        /// </summary>
        /// <returns></returns>
        public bool AddStubCharactersToBattleEngineViewModel(List<CharacterModel> characters)
		{
            foreach (var character in characters)
			{
                BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(character));
            }
            return true;
		}

        /// <summary>
        /// Helper method to get a default character stub list.
        /// </summary>
        /// <returns></returns>
        public List<CharacterModel> GetCharacterStubList()
        {
            List<CharacterModel> characters = DefaultData.LoadData(new CharacterModel());
            List<CharacterModel> result = new List<CharacterModel>();

            for (var i = 0; i < NUM_CHARACTERS; ++i)
            {
                if (characters.ElementAt(i).Level != 20)
                {
                    result.Add(characters.ElementAt(i));
                }
            }
            return result;
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

            // Manually deselect Character.
            CharactersListView.SelectedItem = null;

            // Don't add more than the party max
            if (BattleEngineViewModel.Instance.PartyCharacterList.Count() < BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters)
            {
                BattleEngineViewModel.Instance.PartyCharacterList.Add(data);
            }

            UpdateNextButtonState();
        }

        /// <summary>
        /// TODO: remove this method and corresponding toolbar item. This is only here temporarily so that we can
        /// navigate to BattlePageOne from PickCharactersPage.
        /// Call to open up BattlePageOne. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnBattlePageOne_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new BattlePageOne()));
        }

        /// <summary>
        /// TODO: remove this method and corresponding toolbar item. This is only here temporarily so that we can
        /// navigate to BattleGridPage from PickCharactersPage.
        /// Call to open up BattlePageOne. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnBattleGridPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new BattleGridPage()));
        }

        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnPartyCharacterItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            CharacterModel data = args.SelectedItem as CharacterModel;
            if (data == null)
            {
                return;
            }

            // Manually deselect Character.
            PartyListView.SelectedItem = null;

            // Remove the character from the list
            BattleEngineViewModel.Instance.PartyCharacterList.Remove(data);

            UpdateNextButtonState();
        }

        /// <summary>
        /// Next Button is based on the count
        /// 
        /// If no selected characters, disable
        /// 
        /// Show the Count of the party
        /// 
        /// </summary>
        public void UpdateNextButtonState()
        {
            // If no characters disable Next button
            BeginBattleButton.IsEnabled = true;

            var currentCount = BattleEngineViewModel.Instance.PartyCharacterList.Count();
            if (currentCount == 0)
            {
              BeginBattleButton.IsEnabled = false;
            }

            PartyCountLabel.Text = currentCount.ToString();
        }

        /// <summary>
        /// Jump to the Battle
        /// 
        /// Its Modal because don't want user to come back...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void BattleButton_Clicked(object sender, EventArgs e)
        {
            CreateEngineCharacterList();

            await Navigation.PushModalAsync(new NavigationPage(new BattlePageOne()));
            await Navigation.PopAsync();
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