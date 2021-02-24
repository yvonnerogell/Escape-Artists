using Game.Models;
using Game.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using Game.GameRules;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoundOverPage: ContentPage
	{
        // Variable indicating if stub data should be used. Set this to false when our battle engine is being used.
        public bool UseStubData = true;
        public static int NUM_ITEMS = 5;
        public static int NUM_CHARACTERS = 7;

		/// <summary>
		/// Constructor
		/// </summary>
		public RoundOverPage()
        {
            InitializeComponent();

            // SetUp();

            // Update the Round Count
            TotalRound.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.RoundCount.ToString();

            // Update the Found Number
            // TotalFound.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Count().ToString();

            // Update the Selected Number, this gets updated later when selected refresh happens
           // TotalSelected.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Count().ToString();

            DrawCharacterList();

            DrawGraduatesList();

            DrawItemLists();
        }

        /// <summary>
        /// Clear and Add the Characters that survived
        /// </summary>
        public void DrawCharacterList()
        {
            // Clear and Populate the Characters Remaining
            var FlexList = CharacterListFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                CharacterListFrame.Children.Remove(data);
            }

            if (UseStubData)
			{
                var characters = GetCharacterStubList();
                
                for (var i = 0; i < characters.Count; ++i)
				{
                    CharacterListFrame.Children.Add(CreatePlayerDisplayBox(new PlayerInfoModel(characters.ElementAt(i))));
                }
			}

            if (!UseStubData)
			{
                // Draw the Characters
                foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList)
                {
                    // TODO: add logic to exclude graduates
                    CharacterListFrame.Children.Add(CreatePlayerDisplayBox(data));
                }
            }
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
        /// Clear and Add the characters that graduates
        /// </summary>
        public void DrawGraduatesList()
        {
            // Clear and Populate the Characters Remaining
            var FlexList = CharacterListFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                GraduatesListFrame.Children.Remove(data);
            }

            if (UseStubData)
            {
                List<CharacterModel> characters = new List<CharacterModel>();
                characters = DefaultData.LoadData(new CharacterModel());

                foreach (var data in characters)
                {
                    if (data.Level == 20)
					{
                        GraduatesListFrame.Children.Add(CreatePlayerDisplayBox(new PlayerInfoModel(data)));
                    }
                }
            }

            if (!UseStubData)
            {
                // Draw the Characters
                foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList)
                {
                    // TODO: Add logic here to only display characters that have reached level 20. 
                    GraduatesListFrame.Children.Add(CreatePlayerDisplayBox(data));
                }

            }

        }

        /// <summary>
        /// Draw the List of Items
        /// 
        /// The Ones Dropped
        /// 
        /// The Ones Selected
        /// 
        /// </summary>
        public void DrawItemLists()
        {
            DrawDroppedItems();
            DrawSelectedItems();

            // Only need to update the selected, the Dropped is set in the constructor
            //TotalSelected.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Count().ToString();
        }

        /// <summary>
        /// Add the Dropped Items to the Display
        /// </summary>
        public void DrawDroppedItems()
        {

            // Clear and Populate the Dropped Items
            var FlexList = ItemListFoundFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemListFoundFrame.Children.Remove(data);
            }

            if (UseStubData)
            {
                List<ItemModel> items = GetItemStubList();

                for (var i = 0; i < items.Count; ++i)
				{
                    ItemListFoundFrame.Children.Add(GetItemToDisplay(items.ElementAt(i)));
                }
            }

            if (!UseStubData)
			{
                foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Distinct())
                {
                    ItemListFoundFrame.Children.Add(GetItemToDisplay(data));
                }
            }
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
        /// Add the Dropped Items to the Display
        /// </summary>
        public void DrawSelectedItems()
        {
            // Clear and Populate the Dropped Items
            var FlexList = ItemListSelectedFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemListSelectedFrame.Children.Remove(data);
            }

            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList)
            {
                ItemListSelectedFrame.Children.Add(GetItemToDisplay(data));
            }
        }

        /// <summary>
        /// Look up the Item to Display
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetItemToDisplay(ItemModel item)
        {
            if (item == null)
            {
                return new StackLayout();
            }

            if (string.IsNullOrEmpty(item.Id))
            {
                return new StackLayout();
            }

            // Defualt Image is the Plus
            var ClickableButton = true;

            var data = ItemIndexViewModel.Instance.GetItem(item.Id);
            if (data == null)
            {
                // Show the Default Icon for the Location
                data = new ItemModel { Name="Unknown", ImageURI = "icon_cancel.png" };

                // Turn off click action
                ClickableButton = false;
            }

            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageLargeStyle"],
                Source = data.ImageURI
            };

            if (ClickableButton)
            {
                // Add a event to the user can click the item and see more
                ItemButton.Clicked += (sender, args) => ShowPopup(data);
            }

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 3,
                Style = (Style)Application.Current.Resources["ItemImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    ItemButton,
                },
            };

            return ItemStack;
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
                Text = "Level : " + data.Level,
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
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
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
                },
            };

            return PlayerStack;
        }

        /// <summary>
        /// Show the Popup for the Item
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ShowPopup(ItemModel data)
        {
            PopupLoadingView.IsVisible = true;
            PopupItemImage.Source = data.ImageURI;

            PopupItemName.Text = data.Name;
            PopupItemDescription.Text = data.Description;
            PopupItemLocation.Text = data.Location.ToMessage();
            PopupItemAttribute.Text = data.Attribute.ToMessage();
            PopupItemValue.Text = " + " + data.Value.ToString();
            return true;
        }

        /// <summary>
        /// Close the popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClosePopup_Clicked(object sender, EventArgs e)
		{
			PopupLoadingView.IsVisible = false;
		}
		
		/// <summary>
		/// Closes the Round Over Popup
        /// 
        /// Launches the Next Round Popup
        /// 
        /// Resets the Game Round
        /// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void CloseButton_Clicked(object sender, EventArgs e)
		{
            // Reset to a new Round
            BattleEngineViewModel.Instance.Engine.Round.NewRound();

            // Show the New Round Screen
            ShowModalNewRoundPage();
		}

        /// <summary>
        /// Navigates to the GameOverPage. This is a temporary button until the battle engine has been implemented.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void GameOverButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new GameOverPage()));
        }

        /// <summary>
        /// Start next Round, returning to the battle screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AutoAssignButton_Clicked(object sender, EventArgs e)
		{
            if (UseStubData)
			{
                var characters = GetCharacterStubList();
                var items = GetItemStubList();

                for (var i = 0; i < characters.Count; ++i)
				{
                    var character = characters.ElementAt(i);
                    if (character.Feet != null)
					{
                        var item = FindItemForLocation(character.Feet, items);
                        if (item != null)
						{
                            character.Feet = item.ToString();
						}
					}
                    if (character.Head != null)
                    {
                        var item = FindItemForLocation(character.Head, items);
                        if (item != null)
                        {
                            character.Head = item.ToString();
                        }
                    }
                    if (character.LeftFinger != null)
                    {
                        var item = FindItemForLocation(character.LeftFinger, items);
                        if (item != null)
                        {
                            character.LeftFinger = item.ToString();
                        }
                    }
                    if (character.Necklace != null)
                    {
                        var item = FindItemForLocation(character.Necklace, items);
                        if (item != null)
                        {
                            character.Necklace = item.ToString();
                        }
                    }
                    if (character.OffHand != null)
                    {
                        var item = FindItemForLocation(character.OffHand, items);
                        if (item != null)
                        {
                            character.OffHand = item.ToString();
                        }
                    }

                }


            }

            // TODO: Revisit this method once our battle engine is up and running to make
            // sure PickupItemsForAllCharacters works with our business logic
            if (!UseStubData)
			{
                // Distribute the Items
                BattleEngineViewModel.Instance.Engine.Round.PickupItemsForAllCharacters();
            }
			

            // Show what was picked up
            DrawItemLists();
        }

        /// <summary>
        /// Finds an item suitable for a given location
        /// </summary>
        /// <param name="location"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public ItemModel FindItemForLocation(string location, List<ItemModel> items)
		{
            foreach (var item in items)
			{
                if (item.Location.ToString() == location)
				{
                    return item;
				}
			}
            return null;
		}

        /// <summary>
        /// Show the Page for New Round
        /// 
        /// Upcomming Monsters
        /// 
        /// </summary>
        public async void ShowModalNewRoundPage()
        {
            await Navigation.PopModalAsync();
        }

    }
}