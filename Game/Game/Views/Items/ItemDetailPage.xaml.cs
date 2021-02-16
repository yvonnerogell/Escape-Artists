using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// The Read Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        // View Model for Item
        public readonly GenericViewModel<ItemModel> ViewModel;

        // Empty Constructor for UTs
        public ItemDetailPage(bool UnitTest) { }

        /// <summary>
        /// Constructor called with a view model
        /// This is the primary way to open the page
        /// The viewModel is the data that should be displayed
        /// </summary>
        /// <param name="viewModel"></param>
        public ItemDetailPage(GenericViewModel<ItemModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;
        }

        /// <summary>
        /// close the read page. similar to back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Close_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}