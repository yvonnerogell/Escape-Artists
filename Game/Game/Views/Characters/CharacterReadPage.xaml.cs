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
    /// The Read Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterReadPage : ContentPage
    {
        // View Model for Character
        public readonly GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for UTs
        public CharacterReadPage(bool UnitTest) { }

        /// <summary>
        /// Constructor called with a view model
        /// This is the primary way to open the page
        /// The viewModel is the data that should be displayed
        /// </summary>
        /// <param name="viewModel"></param>
        public CharacterReadPage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            AddItemsToDisplay();
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterUpdatePage(ViewModel)));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Calls for Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharaterDeletePage(ViewModel)));
            await Navigation.PopAsync();
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

            ItemButton.Clicked += (sender, args) => ShowItem(data);
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

        public async void ShowItem(ItemModel data)
        {
            await Navigation.PushAsync(new ItemReadPage(new GenericViewModel<ItemModel>(data)));
        }
    }
}