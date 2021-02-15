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
    /// Monster Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterUpdatePage : ContentPage
    {
        // View Model for Monster
        public readonly GenericViewModel<MonsterModel> ViewModel;

        // Hold a copy of the original data for Cancel to use
        public MonsterModel DataCopy;

        // Empty Constructor for Tests
        public MonsterUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing monster item
        /// </summary>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            // Make a copy of the character for cancel to restore
            DataCopy = new MonsterModel(data.Data);

            // Default difficulty level to current difficulty level
            DifficultyLevelPicker.SelectedItem = ViewModel.Data.Difficulty.ToMessage();

            AddUniqueDropItemToDisplay();
        }

        /// <summary>
        /// Show the UniqueDropItem Monster has
        /// </summary>
        public void AddUniqueDropItemToDisplay()
        {
            var FlexList = ItemBox.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemBox.Children.Remove(data);
            }

            if (ViewModel.Data.UniqueDropItem != null)
            {
                ItemBox.Children.Add(LoadItem(ItemIndexViewModel.Instance.GetItem(ViewModel.Data.UniqueDropItem)));
            }
        }

        /// <summary>
        /// load an item
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout LoadItem(ItemModel dropItem)
        {
            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ItemImageClicked"],
                Source = dropItem.ImageURI,
            };
            ItemButton.Clicked += (sender, args) => UpdateNewItem(sender, dropItem);

            // Add the Display Text for the item
            var ItemLabel = new Label
            {
                Text = dropItem.ItemType.ToMessage(),
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
            };

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 3,
                Style = (Style)Application.Current.Resources["ItemImageBox"],
                Children = {
                    ItemButton,
                    ItemLabel
                },
            };

            return ItemStack;
        }

        /// <summary>
        /// Triggers the update item page 
        /// </summary>
        /// <param name="location"></param>
        public async void UpdateNewItem(object sender, ItemModel data)
        {
            // trigger new item create page with created item
            GenericViewModel<ItemModel> generalData = new GenericViewModel<ItemModel>(data);
            await Navigation.PushModalAsync(new NavigationPage(new ItemUpdatePage(generalData)));
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
                await Navigation.PushModalAsync(new NavigationPage(new MonsterUpdatePage(ViewModel)));
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
            // Put the copy back
            ViewModel.Data.Update(DataCopy);

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
        }
    }
}