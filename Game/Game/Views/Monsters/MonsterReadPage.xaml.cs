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
    public partial class MonsterReadPage : ContentPage
    {
        // View Model for Monster
        public readonly GenericViewModel<MonsterModel> ViewModel;

        // Empty Constructor for UTs
        public MonsterReadPage(bool UnitTest) { }

        /// <summary>
        /// Constructor called with a view model
        /// This is the primary way to open the page
        /// The viewModel is the data that should be displayed
        /// </summary>
        /// <param name="viewModel"></param>
        public MonsterReadPage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            CheckUniqueDrop();

            AddUniqueDropItemToDisplay();

            int totalDamage = GetDamageFromUniqueDropItem(ViewModel.Data.UniqueDropItem);
            DamageLabel.Text = totalDamage.ToString();
        }

        /// <summary>
        /// Checks if item has been deleted.
        /// </summary>
        public void CheckUniqueDrop()
        {
            if (ViewModel.Data.UniqueDropItem != null)
            {
                if (ItemIndexViewModel.Instance.GetItem(ViewModel.Data.UniqueDropItem) == null)
                {
                    ViewModel.Data.UniqueDropItem = null;
                }
            }
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
            ShowItemLabel.IsVisible = false;
            if (ViewModel.Data.UniqueDropItem != null)
            {
                ItemBox.Children.Add(LoadItem(ItemIndexViewModel.Instance.GetItem(ViewModel.Data.UniqueDropItem)));
                ShowItemLabel.IsVisible = true;
            }
        }

        /// <summary>
        /// load an item
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout LoadItem(ItemModel dropItem)
        {
            if (dropItem == null)
            {
                CheckUniqueDrop();
                return null;
            }
            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ItemImageClicked"],
                Source = dropItem.ImageURI,
            };
            ItemButton.Clicked += (sender, args) => ShowItem(sender, dropItem);

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
        public async void ShowItem(object sender, ItemModel data)
        {
            // trigger new item create page with created item
            await Navigation.PushAsync(new ItemDetailPage(new GenericViewModel<ItemModel>(data)));
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterUpdatePage(ViewModel)));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Calls for Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterDeletePage(ViewModel)));
            await Navigation.PopAsync();
        }
      
        /// <summary>
        /// Returns the damage given a specific item ID.
        /// </summary>
        /// <param name="id">Id of item to get damage for</param>
        /// <returns>Damage for specified item</returns>
        public int GetDamageFromUniqueDropItem(string id)
        {
            // Get item from string id
            var item = ItemIndexViewModel.Instance.GetItem(id);

            if (item == null)
			{
                return 0;
			}

            // Add damage from item to total
            var damage = item.Damage;

            return damage;
        }
    }
}