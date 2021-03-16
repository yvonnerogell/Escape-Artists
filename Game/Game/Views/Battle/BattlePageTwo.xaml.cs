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

        // list of monsters found in the frame
        //public List<PlayerInfoModel> monstersFoundList = new List<PlayerInfoModel>();

        // selecting the monster of that turn
        //   public List<PlayerInfoModel> selectedMonsters = new List<PlayerInfoModel>();
        public PlayerInfoModel currentDefender = new PlayerInfoModel(new MonsterModel());

        // selecting the item of that turn
        public List<ItemModel> selectedItems = new List<ItemModel>();

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

            // TODO for team: remove this once we are ready to use our own battle engine.
            //BattleEngineViewModel.Instance.SetBattleEngineToKoenig();

            PopupLoadingItemListFoundFrame.IsVisible = false;
            MonsterFrame.IsVisible = false;          
            PopupMonsterListSelected.IsVisible = false;
            PopupItemListSelected.IsVisible = false;
            //PopupAbilityApplied.IsVisible = false;
            ActionSelectedPicker.IsEnabled = true;
            ApplyAbilityButton.IsVisible = false;
            //PopupCharacterListSelected.IsVisible = false;
            //PopupLoadingViewMonster.IsVisible = false;

            // Start with the CharacterList only
            DrawCharacterList();

            DrawActionList();
           
            // Create and Draw the Map
            // InitializeMapGrid();

            // Start the Battle Engine
            // BattleEngineViewModel.Instance.Engine.StartBattle(false);

            // Populate the UI Map
            // DrawMapGridInitialState();

            // Ask the Game engine to select who goes first
            //BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(null);

            //var currentAttacker = ;
            //var currentDefender = null;

            // Add Players to DisplayViewModel.Data.PlayerType = PlayerTypeEnum.Character;
            // DrawGameAttackerDefenderBoard();

            // Set the Battle Mode
            // ShowBattleMode();
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
            //BattleModeValue.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum.ToMessage();

            //            ShowBattleModeDisplay();

            //          ShowBattleModeUIElements();
        }

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


            /*

            // Clear and Populate the Characters remaining
            var FlexList = CharacterListFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                CharacterListFrame.Children.Remove(data);
            }

            // Draw the Characters
            //foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList)
            //{
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker!= null) 
            { 
                if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Level != 20)
                    {
                        CharacterListFrame.Children.Add(GetCharacterToDisplay(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker));
                    CharacterTextLabel.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Name;
                    }
            }
            // making sure that the character is not clickable
            CharacterListFrame.IsEnabled = false;
            */
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

            //List<PlayerInfoModel> eligible_character_list = new List<PlayerInfoModel>();
            //eligible_character_list.Add(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker);

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
            /*
            PopupLoadingItemListFoundFrame.IsVisible = false;
            PopupLoadingViewItem.IsVisible = false;
            ItemModel attackItem = ItemIndexViewModel.Instance.GetItem(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.AttackItem);
            AttackItemImage.Source = attackItem.ImageURI;
            AttackItemTextLabel.Text = attackItem.Name;
            */
            
            // Clear and Populate the Dropped Items
            var FlexList = ItemListSelectedFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemListSelectedFrame.Children.Remove(data);
            }

            foreach (var data in selectedItems)
            {
                ItemListSelectedFrame.Children.Add(GetItemToDisplay(data));
                // selected item is visible
                PopupLoadingItemListFoundFrame.IsVisible = false;
                // other item frames are invisible
                PopupLoadingViewItem.IsVisible = false;
                PopupItemListSelected.IsVisible = true;
                // selected item is not clickable
                PopupItemListSelected.IsEnabled = false;                
                break;
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
            /*
            var button = sender as ImageButton;

            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.AttackItem != null)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.AttackItem = null;
                button.BackgroundColor = Color.Transparent;
            }

            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.AttackItem == null)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.AttackItem = data.Id;
                button.BackgroundColor = Color.Green;
            }
            */
            
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

        /// <summary>
        /// Find the characters who can accept the item
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<string> GetCharacterWhoCanAcceptItem(List<PlayerInfoModel> characters, ItemModel item)
        {
            
            List<string> result = new List<string>();

            if (item == null) 
            {
                return result;
            }

            foreach (var character in characters)
            {
                if (character != null)
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
                        //   if (character.CharacterTypeEnum == CharacterTypeEnum.Parent)
                        //  {
                        //      continue;
                        //  }
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
            }

            return result;
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
            var itemId = "";   
                itemId = ((Button)sender).CommandParameter.ToString();
                var item = ItemIndexViewModel.Instance.GetItem(itemId);


                var itemLocation = ItemTypeEnumHelper.GetLocationFromItemType(item.ItemType);

            // Add item to the one selected character
            //var player = BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList[0];
            //    player = AddItemToCharacter(player, itemLocation, item);
         
                 // Remove item from dropped list and add to selected item list. 
               //   var itemIndex = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.FindIndex(i => i.Name == (string)item.Name);
               //   BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.RemoveAt(itemIndex);
                    BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(item);
                    selectedItems.Add(item);
                    // Add updated player back to view model
                //    BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(player);
                
                           
                DrawSelectedItem();

                // visibility after the click
               // PopupLoadingViewItem.IsVisible = false;
               // PopupItemListSelected.IsVisible = true;
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
            
            // translating a PlayerInfoModel to a MonsterModel
            MonsterModel data = new MonsterModel { Name = monster.Name,
            ImageURI = monster.ImageURI, Alive = monster.Alive, Attack = monster.Attack,
            Defense = monster.Defense, Description = monster.Description, CurrentHealth = monster.CurrentHealth,
            Difficulty = monster.Difficulty, CharacterTypeEnum = monster.CharacterTypeEnum, ExperienceTotal = monster.ExperienceTotal,
            ExperienceRemaining = monster.ExperienceRemaining, BuffAttackValue = monster.BuffAttackValue,
            BuffDefenseValue = monster.BuffDefenseValue, BuffHealthValue = monster.BuffHealthValue, BuffSpeedValue = monster.BuffSpeedValue,
            Head = monster.Head, Feet = monster.Feet, RightFinger = monster.RightFinger, LeftFinger = monster.LeftFinger,
            OffHand = monster.OffHand, PrimaryHand = monster.PrimaryHand, Id = monster.Id, Guid = monster.Guid,
            Level = monster.Level, MonsterTypeEnum = monster.MonsterTypeEnum, SpecificMonsterTypeEnum = monster.SpecificMonsterTypeEnum,
            Speed = monster.Speed, Range = monster.Range, Necklace = monster.Necklace, MaxHealth = monster.MaxHealth,
            PlayerType = monster.PlayerType, UniqueDropItem = monster.UniqueDropItem, Order = monster.Order,
            ListOrder = monster.ListOrder, TileImageURI = monster.TileImageURI, Job = monster.Job};

            // Hookup the Image Button to show the Monster picture
            var MonsterButton = new ImageButton
            {
                //Style = (Style)Application.Current.Resources["ImageBattleLargeStyle"],
                Source = monster.ImageURI,
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

            /*
            if (currentDefender != null)
            {
                // Draw the selected current Defender for display
                if (currentDefender.Level != 20)
                {
                    // Set Monster it as defender
                    MonsterListSelectedFrame.Children.Add(GetMonsterToDisplay(currentDefender));
                    PopupMonsterListSelected.IsVisible = true;
                    PopupMonsterListSelected.IsEnabled = false;
                    MonsterFrame.IsVisible = false;
                }
            }
            */
        }


        /// <summary>
        /// Show the Popup for the Monster
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        
        public bool ShowPopupMonster(PlayerInfoModel data)
                {
                    PopupLoadingViewMonster.IsVisible = true;
                    PopupMonsterImage.Source = data.ImageURI;

                    PopupMonsterName.Text = data.Name;

                    // Set command parameter so that popup knows which item it is displaying
                    PopupSaveButtonMonster.CommandParameter = data.Name;

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
                    var monsterName = "";
            //  if (sender != null)
            // {              
                    monsterName = ((Button)sender).CommandParameter.ToString();
            
                    foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList)
                    {
                        if (data.Name.Equals(monsterName))
                        {
                            // set current defender
                            currentDefender = data;
                    //BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(currentDefender);
                            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = currentDefender;
                            //ContinueButton.IsEnabled = true;
                            break;
                        }
                    }
                    //var monster = MonsterIndexViewModel.Instance.GetMonsterByName(monsterName);
                    //PlayerInfoModel player = new PlayerInfoModel(monster);

                 //   var MonsterFoundIndex = BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.FindIndex(c => c.Name == currentDefender.Name);
                //    if (MonsterFoundIndex >= 0)
                //    {
                //        BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.RemoveAt(MonsterFoundIndex);
                //    }

                
                 //   }
                    //DrawMonsterList();
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
                // this is important to avoid going back and forth
                //ActionSelectedPicker.IsEnabled = false;
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
                // this is important to avoid going back and forth
                //ActionSelectedPicker.IsEnabled = false;
            }

            /*
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = action;

            if (action == ActionEnum.Attack)
            {
                ContinueButton.IsEnabled = false;
                DrawMonsterList();
                DrawItems();    
                // this is important to avoid going back and forth
                ActionSelectedPicker.IsEnabled = false;
                ContinueButton.IsEnabled = true;
            }
            // allows user to continue only if there is an ability
            else if (action == ActionEnum.Ability)
            {
                if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PlayerType == PlayerTypeEnum.Character &
               BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.IsSpecialAbilityAvailable())
                {
                    PopupAbilityApplied.IsVisible = true;
                    // this is important to avoid going back and forth
                    ActionSelectedPicker.IsEnabled = false;
                    ContinueButton.IsEnabled = true;
                }
                else
                {
                    ContinueButton.IsEnabled = false;
                }
    
            }
            // if attack or action are not selected, then the user cannot continue
            else
            {
                ContinueButton.IsEnabled = false;
            }
            */
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
            /*
            int removeModalCount = Navigation.ModalStack.Count;
            for (int i=0; i<removeModalCount; i++)
            {
                await Navigation.PopModalAsync();
            }
            */
            //Navigation.PopModalAsync();

            Navigation.PopAsync();
        }
    }
}