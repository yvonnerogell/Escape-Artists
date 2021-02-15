using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;
using System.Linq;

namespace Game.Views
{
    /// <summary>
    /// Character Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterUpdatePage : ContentPage
    {
        // View Model for Character
        public readonly GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for Tests
        public CharacterUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing character item
        /// </summary>
        public CharacterUpdatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            AddItemsToDisplay();
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // if the name or description are not entered, the page remains on the update screen
            if (string.IsNullOrEmpty(ViewModel.Data.Name) || string.IsNullOrEmpty(ViewModel.Data.Description))
            {
                await Navigation.PushModalAsync(new NavigationPage(new CharacterUpdatePage(ViewModel)));
                await Navigation.PopModalAsync();
            }
            // otherwise it completes the update and returns to the read page
            else
            {
                MessagingCenter.Send(this, "Update", ViewModel.Data);
                await Navigation.PopModalAsync();
            }
           
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Updates the value associated with the changed slider (attack, level, defense or speed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSliderChanged(object sender, ValueChangedEventArgs e)
        {
            var newValue = (int)e.NewValue;
            var newValueStr = String.Format("{0}", newValue);

            if (sender == LevelSlider)
            {
                LevelValue.Text = newValueStr;
                LevelSlider.Value = newValue;
            }
            if (sender == AttackSlider)
            {
                AttackValue.Text = newValueStr;
                AttackSlider.Value = newValue;
            }
            if (sender == DefenseSlider)
            {
                DefenseValue.Text = newValueStr;
                DefenseSlider.Value = newValue;
            }
            if (sender == SpeedSlider)
            {
                SpeedValue.Text = newValueStr;
                SpeedSlider.Value = newValue;
            }
            if (sender == GPASlider)
            {
                // ensuring that the slider snaps to increments of 5
                GPAValue.Text = newValueStr;
                if (newValue % 5 == 0)
                {
                    GPASlider.Value = newValue;
                }
                else
                {
                    while (newValue % 5 != 0)
                    {
                        newValue += 1;
                    }
                    GPASlider.Value = newValue;
                }
            }
        }

        /// <summary>
        /// Show the Items the Character has
        /// </summary>
        public void AddItemsToDisplay()
        {
            var FlexList = ItemBox.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemBox.Children.Remove(data);
            }

            if (CheckItemExist(ItemLocationEnum.Head))
            {
                ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.Head));
            }
            if (CheckItemExist(ItemLocationEnum.Necklace))
            {
                ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.Necklace));
            }
            if (CheckItemExist(ItemLocationEnum.PrimaryHand))
            {
                ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.PrimaryHand));
            }
            if (CheckItemExist(ItemLocationEnum.OffHand))
            {
                ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.OffHand));
            }
            if (CheckItemExist(ItemLocationEnum.RightFinger))
            {
                ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.RightFinger));
            }
            if (CheckItemExist(ItemLocationEnum.LeftFinger))
            {
                ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.LeftFinger));
            }
            if (CheckItemExist(ItemLocationEnum.Feet))
            {
                ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.Feet));
            }
        }
        
        /// <summary>
        /// Helper method to check if the location is holding an item
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool CheckItemExist(ItemLocationEnum location)
        {
            var data = ViewModel.Data.GetItemByLocation(location);
            if (data == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Look up the Item to Display
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetItemToDisplay(ItemLocationEnum location)
        {
            var data = ViewModel.Data.GetItemByLocation(location);

            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageMediumStyle"],
                Source = data.ImageURI
            };

            ItemButton.Clicked += (sender, args) => UpdateItem(data);
            // TODO: will implement link to item page 
            //if (ClickableButton)
            //{
            // Add a event to the user can click the item and see more
            //    ItemButton.Clicked += (sender, args) => ShowPopup(data);
            //}

            // Add the Display Text for the item
            var ItemLabel = new Label
            {
                Text = location.ToMessage(),
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 3,
                Style = (Style)Application.Current.Resources["ItemImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    ItemButton,
                    ItemLabel
                },
            };

            return ItemStack;
        }

        /// <summary>
        /// Opens up the read page for the specified item. 
        /// </summary>
        /// <param name="data"></param>
        public async void UpdateItem(ItemModel data)
        {
            await Navigation.PushAsync(new ItemUpdatePage(new GenericViewModel<ItemModel>(data)));
        }
    }
}