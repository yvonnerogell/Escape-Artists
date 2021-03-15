﻿using System;
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

        /*
        /// <summary>
        /// Used to test page with fake data
        /// </summary>
        /// <returns></returns>
        public bool SetUpStubData()
        {
            // Add characters to state machine
            var characters = GetCharacterStubList();
            AddStubCharactersToBattleEngineViewModel(characters);

            // Add items to state machine
            var itemsDropped = GetItemStubList();
            AddStubItemsToBattleEngineViewModel(itemsDropped);

            var monsters = GetMonsterStubList();
            AddStubMonstersToBattleEngineViewModel(monsters);

            return true;
        }
        */

        /*
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
        /// Helper method to get a default monster stub list.
        /// </summary>
        /// <returns></returns>
        public List<MonsterModel> GetMonsterStubList()
        {
            List<MonsterModel> monsters = DefaultData.LoadData(new MonsterModel());
            List<MonsterModel> result = new List<MonsterModel>();

            for (var i = 0; i < NUM_MONSTERS; ++i)
            {
                result.Add(monsters.ElementAt(i));
            }
            return result;
        }

        /// <summary>
        /// Add stub monsters to battle engine view model.
        /// </summary>
        /// <returns></returns>
        public bool AddStubMonstersToBattleEngineViewModel(List<MonsterModel> monsters)
        {
            foreach (var monster in monsters)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(monster));
            }
            return true;
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
                result.Add(characters.ElementAt(i));
            }
            return result;
        }
        */

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
            //CharactersListView.SelectedItem = null;

            // Don't add more than the party max
            if (BattleEngineViewModel.Instance.PartyCharacterList.Count() < BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters)
            {
                BattleEngineViewModel.Instance.PartyCharacterList.Add(data);
            }

            //UpdateNextButtonState();
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
                button.BackgroundColor = Color.Green;
            }
            UpdateNextButtonState();
        }

        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /*public void OnPartySelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var button = sender as ImageButton;
            String characterId = button.CommandParameter as String;
            CharacterModel data = ViewModel.Dataset.FirstOrDefault(itm => itm.Id == characterId);
            if (is_added == false)
            {
                BattleEngineViewModel.Instance.PartyCharacterList.Add(data);
                is_added = true;
            } else if (is_added == true)
            {
                BattleEngineViewModel.Instance.PartyCharacterList.Remove(data);
                is_added = false;
            } else
            {
                return;
            }

            UpdateNextButtonState();
        }*/

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

            // PartyCountLabel.Text = currentCount.ToString();
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
            //await Navigation.PushAsync(new NewRoundPage());
            //Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            await Navigation.PushAsync(new NavigationPage(new BattlePageOne()));
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
