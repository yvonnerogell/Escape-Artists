﻿using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Create Item
    /// </summary>
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemCreatePage : ContentPage
    {
        // The item to create
        public GenericViewModel<ItemModel> ViewModel = new GenericViewModel<ItemModel>();

        // Empty Constructor for UTs
        public ItemCreatePage(bool UnitTest){}

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public ItemCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = new ItemModel();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Create";

            // Set default values for location and attribute pickers
            LocationPicker.SelectedIndex = 0;
            AttributePicker.SelectedIndex = 0;
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            var itemType = ItemTypePicker.SelectedItem.ToString();
            ViewModel.Data.ItemType = ItemTypeEnumHelper.ConvertMessageStringToEnum(itemType);
            ViewModel.Data.UpdateImageURI(ViewModel.Data);

            MessagingCenter.Send(this, "Create", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Changes the slider value for the appropriate slider (attack, value, speed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSliderChanged(object sender, ValueChangedEventArgs e)
        {
            var newValue = (int)e.NewValue;
            var newValueStr = String.Format("{0}", newValue);
            if (sender == ValueSlider)
            {
                ValueValue.Text = newValueStr;
                ValueSlider.Value = newValue;
            }
            if (sender == RangeSlider)
            {
                RangeValue.Text = newValueStr;
                RangeSlider.Value = newValue;
            }
            if (sender == DamageSlider)
            {
                DamageValue.Text = newValueStr;
                DamageSlider.Value = newValue;
            }
        }
    }
}