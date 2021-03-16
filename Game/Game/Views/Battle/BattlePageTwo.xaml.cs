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
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    public partial class BattlePageTwo : ContentPage
    {
        // HTML Formatting for message output box
        public HtmlWebViewSource htmlSource = new HtmlWebViewSource();

        // Wait time before proceeding
        public int WaitTime = 1500;

        // Hold the Map Objects, for easy access to update them
        public Dictionary<string, object> MapLocationObject = new Dictionary<string, object>();

        // Add viewModel
        public GenericViewModel<BattleEngineViewModel> ViewModel = new GenericViewModel<BattleEngineViewModel>();

        // Empty Constructor for UTs
        public bool UnitTestSetting;
        public BattlePageTwo(bool UnitTest) { UnitTestSetting = UnitTest; }

        /// <summary>
        /// Constructor
        /// </summary>
        public BattlePageTwo()
        {
            InitializeComponent();

            // Set initial State to Starting
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Starting;

            // Set up the UI to Defaults
            BindingContext = BattleEngineViewModel.Instance;

            PopupLoadingItemListFoundFrame.IsVisible = false;
            MonsterFrame.IsVisible = false;          
            PopupMonsterListSelected.IsVisible = false;
            PopupItemListSelected.IsVisible = false;
            ActionSelectedPicker.IsEnabled = true;
            ApplyAbilityButton.IsVisible = false;

            // Start with the CharacterList only
            DrawCharacterList();

            DrawActionList();
           
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
        /// Helper method to load the actions available for character
        /// </summary>
        public void DrawActionList()
        {
            var ActionList = new List<string>();
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.IsSpecialAbilityAvailable())
            {
                ActionList.Add("Special Ability");
            }

            ActionList.Add("Attack");
            ActionSelectedPicker.HeightRequest = 75;
            ActionSelectedPicker.WidthRequest = 250;
            ActionSelectedPicker.ItemsSource = ActionList;
            ActionSelectedPicker.SelectedIndex = 0;
        }
        
        /// <summary>
        /// Clear and Add the Characters that survived
        /// </summary>
        public void DrawCharacterList()
        {
            AttackerImage.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.TileImageURI;
            CharacterTextLabel.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.SpecificCharacterTypeEnum + " " +
                                      BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Name;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.AttackItem = null;
        }

        /// <summary>
        /// Add the Dropped Items to the Display
        /// </summary>
        public void DrawItems()
        {
            // Clear and Populate the Dropped Items
            var FlexList = ItemListFoundFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemListFoundFrame.Children.Remove(data);
            }

            // Adding all potential items from the current attacker
            List<ItemModel> allPotentialItems = new List<ItemModel>();
           if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker != null)
                {
                if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PrimaryHand != null &&
                    BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PrimaryHand != "None")
                {
                    allPotentialItems.Add(ItemIndexViewModel.Instance.GetItem(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PrimaryHand));
                }
                if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Feet != null &&
                    BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Feet != "None")
                {
                    allPotentialItems.Add(ItemIndexViewModel.Instance.GetItem(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Feet));
                }
                if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Head != null &&
                    BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Head != "None")
                {
                    allPotentialItems.Add(ItemIndexViewModel.Instance.GetItem(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Head));
                }
                if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.OffHand != null &&
                    BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.OffHand != "None")
                {
                    allPotentialItems.Add(ItemIndexViewModel.Instance.GetItem(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.OffHand));
                }
                if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Necklace != null &&
                    BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Necklace != "None")
                {
                    allPotentialItems.Add(ItemIndexViewModel.Instance.GetItem(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Necklace));
                }
                if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.RightFinger != null &&
                    BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.RightFinger != "None")
                {
                    allPotentialItems.Add(ItemIndexViewModel.Instance.GetItem(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.RightFinger));
                }

                if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.LeftFinger != null &&
                    BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.LeftFinger != "None")
                {
                    allPotentialItems.Add(ItemIndexViewModel.Instance.GetItem(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.LeftFinger));
                }
            }

            // Choosing among all the items a character has
            foreach (var data in allPotentialItems)
            {
                    ItemListFoundFrame.Children.Add(GetItemToDisplay(data));        
            }

            // Item Frame is displayed only if there is something to display
            if (ItemListFoundFrame.Children.Count() > 0)
            {
                // makes the List of Items for the character visible
                PopupLoadingItemListFoundFrame.IsVisible = true;
                ItemListFoundFrame.IsVisible = true;
            }
            
        }

        /// <summary>
        /// Add the Dropped Items to the Display
        /// </summary>
        public void DrawSelectedItem()
        {
            PopupLoadingItemListFoundFrame.IsVisible = false;
            PopupLoadingViewItem.IsVisible = false;
            ItemModel attackItem = ItemIndexViewModel.Instance.GetItem(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.AttackItem);
            AttackItemImage.Source = attackItem.ImageURI;
            AttackItemTextLabel.Text = attackItem.Name;
            PopupItemListSelected.IsVisible = true;
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
           
            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                //Style = (Style)Application.Current.Resources["ImageLargeStyle"],
                Source = item.ImageURI,
                CommandParameter = item.Id,
            };

            if (ClickableButton)
            {
                // Add a event to the user can click the item and see more
                ItemButton.Clicked += (sender, args) => ShowPopupItem(sender, args, item);
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
        /// Show the Popup for the Item
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ShowPopupItem(object sender, EventArgs args, ItemModel data)
        {   
            PopupLoadingViewItem.IsVisible = true;
            PopupItemImage.Source = data.ImageURI;

            PopupItemName.Text = data.Name;
            PopupItemDescription.Text = data.Description;
            PopupItemLocation.Text = data.Location.ToMessage();
            PopupItemAttribute.Text = data.Attribute.ToMessage();
            PopupItemValue.Text = " + " + data.Value.ToString();

            // Set command parameter so that popup knows which item it is displaying
            PopupSaveButtonItem.CommandParameter = data.Id;
            
            return true;
        }

        /// Close the popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClosePopupItem_Clicked(object sender, EventArgs e)
        {
            PopupLoadingViewItem.IsVisible = false;
        }

        /// <summary>
        /// Save the assigned item and close the popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PopupSaveButtonItem_Clicked(object sender, EventArgs e)
        {
            string itemId = ((Button)sender).CommandParameter.ToString();
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.AttackItem = itemId;
            DrawSelectedItem();
        }

        /// <summary>
        /// Look up the Item to Display
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetMonsterToDisplay(PlayerInfoModel monster)
        {
            if (monster == null)
            {
                return new StackLayout();
            }

           // if (string.IsNullOrEmpty(monster.Id))
           // {
           //     return new StackLayout();
           // }

            // Defualt Image is the Plus
            var ClickableButton = true;

            // Hookup the Image Button to show the Monster picture
            var MonsterButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["VillageMenuImageButton"],
                Source = monster.TileImageURI,
                CommandParameter = monster.Name
            };

            if (ClickableButton)
            {
                // Add a event to the user can click the item and see more
                MonsterButton.Clicked += (sender, args) => ShowPopupMonster(monster);
            }

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 1,
                Style = (Style)Application.Current.Resources["ItemImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    MonsterButton,
                },
            };

            return ItemStack;
        }

        /// <summary>
        /// Clear and Add the Monsters that survived
        /// </summary>
        public void DrawMonsterList()
        {
            // Clear the Monsters
            var FlexList = MonsterListFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                MonsterListFrame.Children.Remove(data);
            }

            // Draw the Monsters
            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList)
            {
                if (data.Level != 20)
                {
                    MonsterListFrame.Children.Add(GetMonsterToDisplay(data));
                }

            }

            // Make Monsters visible
            MonsterFrame.IsVisible = true;
            MonsterListFrame.IsVisible = true;
        }

        /// <summary>
        /// Add Monsters to the Display
        /// </summary>
        public void DrawSelectedMonsters()
        {
            PopupMonsterListSelected.IsEnabled = false;
            MonsterFrame.IsVisible = false;
            DefenderImage.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.TileImageURI;
            DefenderTextLabel.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.SpecificMonsterTypeEnum + " " +
                                      BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.Name;
        }


        /// <summary>
        /// Show the Popup for the Monster
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        
        public bool ShowPopupMonster(PlayerInfoModel data)
        {
            PopupLoadingViewMonster.IsVisible = true;
            PopupMonsterImage.Source = data.TileImageURI;

            PopupMonsterName.Text = data.Name;

            // Set command parameter so that popup knows which item it is displaying
            PopupSaveButtonMonster.CommandParameter = data.Id;

            return true;
        }
        
          /// <summary>
        /// Close the popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClosePopupMonster_Clicked(object sender, EventArgs e)
        {
            PopupLoadingViewMonster.IsVisible = false;
        }

        /// <summary>
        /// Save the assigned item and close the popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PopupSaveButtonMonster_Clicked(object sender, EventArgs e)
        {
            var monsterId = "";      
            monsterId = ((Button)sender).CommandParameter.ToString();
            PlayerInfoModel currentDefender = BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Find(m => m.Id.Equals(monsterId));
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = currentDefender;
            DrawSelectedMonsters();

            // visibility after the click
            PopupLoadingViewMonster.IsVisible = false;
            PopupMonsterListSelected.IsVisible = true;
        }

        public async void Apply_Attack_Clicked(object sender, EventArgs e)
        {
            // TODO: make sure the AutoBattlePage is the right option here
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.Attack;

            BattleEngineViewModel.Instance.Engine.Round.RoundNextTurn();
            // Moving on to next turn, and navigating to BattlePageOne
            await Navigation.PushAsync(new BattlePageOne());
            //await Navigation.PushModalAsync(new NavigationPage(new BattlePageOne()));
            if (Navigation.NavigationStack.Count > 2)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
        }

        public async void Apply_Ability_Clicked(object sender, EventArgs e)
        {
            // TODO: make sure the AutoBattlePage is the right option here
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.SpecialAbility;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;
            BattleEngineViewModel.Instance.Engine.Round.RoundNextTurn();

            // Moving on to next turn, and navigating to BattlePageOne
            await Navigation.PushAsync(new BattlePageOne());
            //await Navigation.PushModalAsync(new NavigationPage(new BattlePageOne()));
            if (Navigation.NavigationStack.Count > 2)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }

        }

        /// <summary>
        /// Any time picker changes, game status changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnPickerSelectedActionChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var action = picker.SelectedItem.ToString();


            //var action = (ActionEnum)picker.SelectedIndex;
            if (action.Equals("Special Ability"))
            {
                ApplyAttackButton.IsVisible = false;
                ApplyAbilityButton.IsVisible = true;
                MonsterFrame.IsVisible = false;
                MonsterListFrame.IsVisible = false;
                ItemListFoundFrame.IsVisible = false;
            }

            if (action.Equals("Attack"))
            {
                ApplyAbilityButton.IsVisible = false;
                DrawItems();
                DrawMonsterList();
                
                ApplyAttackButton.IsVisible = true;
            }
        }

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
    }
}