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
        public bool UseStubData = false;
        public static int NUM_ITEMS = 5;
        public static int NUM_CHARACTERS = 7;

        // Empty Constructor for UTs
        bool UnitTestSetting;
        public RoundOverPage(bool UnitTest) { UnitTestSetting = UnitTest; }

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

            // Draw the Characters
            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList)
            {
                if (data.Level != 20)
				{
                    CharacterListFrame.Children.Add(CreatePlayerDisplayBox(data));
                }
                
            }
        }

        /// <summary>
        /// Clear and Add the characters that graduates
        /// </summary>
        public void DrawGraduatesList()
        {
            // Clear and Populate the Characters Remaining
            var FlexList = GraduatesListFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                GraduatesListFrame.Children.Remove(data);
            }

            // Draw the Characters
            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList)
            {
                if (data.Level == 20)
				{
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

            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Distinct())
            {
                ItemListFoundFrame.Children.Add(GetItemToDisplay(data));
            }
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
                Source = data.ImageURI,
                CommandParameter = item.Id
            };

            if (ClickableButton)
            {
                // Add a event to the user can click the item and see more
                ItemButton.Clicked += (sender, args) => ShowPopup(data);
            }

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 1,
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

            // Set command parameter so that popup knows which item it is displaying
            PopupSaveButton.CommandParameter = data.Id;

            // Figure out which characters can be assigned this item and display that list in the picker. 
            List<PlayerInfoModel> allCharacters = BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList;
            List<string> charactersForItem = GetCharacterWhoCanAcceptItem(allCharacters, data);
            AssignItemPicker.ItemsSource = charactersForItem;
            AssignItemPicker.SelectedIndex = 0;

            return true;
        }

        /// <summary>
        /// Find the characters who can accept the item
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<string> GetCharacterWhoCanAcceptItem(List<PlayerInfoModel> characters, ItemModel item)
		{
            List<string> result = new List<string>();

            foreach (var character in characters)
			{
                // exclude any graduates
                if (character.Level == 20)
				{
                    continue;
				}
                if (character.Feet == null || character.Feet == "None")
				{
                    // Parents don't have feet
                    if (character.CharacterTypeEnum == CharacterTypeEnum.Parent)
					{
                        continue;
					}
                    if (item.Location.ToString() == ItemLocationEnum.Feet.ToString())
					{
                        result.Add(character.Name);
                        continue;
                    }
				}
                if (character.Head == null || character.Head == "None")
                {
                    // Parents don't have heads in this game..
                    if (character.CharacterTypeEnum == CharacterTypeEnum.Parent)
                    {
                        continue;
                    }
                    if (item.Location.ToString() == ItemLocationEnum.Head.ToString())
                    {
                        result.Add(character.Name);
                        continue;
                    }
                }
                if (character.LeftFinger == null || character.LeftFinger == "None")
                {
                    if (item.Location.ToString() == ItemLocationEnum.LeftFinger.ToString())
                    {
                        result.Add(character.Name);
                        continue;
                    }
                }
                if (character.Necklace == null || character.Necklace == "None")
                {
                    if (item.Location.ToString() == ItemLocationEnum.Necklace.ToString())
                    {
                        result.Add(character.Name);
                        continue;
                    }
                }
                if (character.OffHand == null || character.OffHand == "None")
                {
                    if (item.Location.ToString() == ItemLocationEnum.OffHand.ToString())
                    {
                        result.Add(character.Name);
                        continue;
                    }
                }
                if (character.PrimaryHand == null || character.PrimaryHand == "None")
                {
                    if (item.Location.ToString() == ItemLocationEnum.PrimaryHand.ToString())
                    {
                        result.Add(character.Name);
                        continue;
                    }
                }
                if (character.RightFinger == null || character.RightFinger == "None")
                {
                    if (item.Location.ToString() == ItemLocationEnum.RightFinger.ToString())
                    {
                        result.Add(character.Name);
                        continue;
                    }
                }
            }

            return result;
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
        /// Save the assigned item and close the popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PopupSaveButton_Clicked(object sender, EventArgs e)
        {
            var itemId = ((Button)sender).CommandParameter;
            var characterName = AssignItemPicker.SelectedItem.ToString();
            var character = CharacterIndexViewModel.Instance.GetCharacterByName(characterName);
            PlayerInfoModel player = new PlayerInfoModel(character);

            var characterFoundIndex = BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.FindIndex(c => c.Name == player.Name);
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.RemoveAt(characterFoundIndex);

            // Add item to character
            var item = ItemIndexViewModel.Instance.GetItem((string)itemId);
            var itemLocation = ItemTypeEnumHelper.GetLocationFromItemType(item.ItemType);
            player = AddItemToCharacter(player, itemLocation, item);

            // Remove item from dropped list and add to selected item list. 
            var itemIndex = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.FindIndex(i => i.Id == (string)itemId);
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.RemoveAt(itemIndex);
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(item);

            // Add updated player back to view model
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(player);

            DrawItemLists();

            PopupLoadingView.IsVisible = false;
        }

        public PlayerInfoModel AddItemToCharacter(PlayerInfoModel player, ItemLocationEnum location, ItemModel item)
		{
            if (ItemLocationEnum.Feet == location)
			{
                player.Feet = item.Id;
			}
            if (ItemLocationEnum.Head == location)
            {
                player.Head = item.Id;
            }
            if (ItemLocationEnum.LeftFinger == location)
            {
                player.LeftFinger = item.Id;
            }
            if (ItemLocationEnum.Necklace == location)
            {
                player.Necklace = item.Id;
            }
            if (ItemLocationEnum.OffHand == location)
            {
                player.OffHand = item.Id;
            }
            if (ItemLocationEnum.PrimaryHand == location)
            {
                player.PrimaryHand = item.Id;
            }
            if (ItemLocationEnum.RightFinger == location)
            {
                player.RightFinger = item.Id;
            }

            return player;
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
        /// Finds an item suitable for a given location
        /// </summary>
        /// <param name="location"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public ItemModel FindItemForLocation(ItemLocationEnum location, List<ItemModel> items)
		{
            foreach (var item in items)
			{
                if (item.Location.ToString() == location.ToString())
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