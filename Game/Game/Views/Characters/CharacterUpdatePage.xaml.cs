﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// Item Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterUpdatePage : ContentPage
    {
        // View Model for Item
        public readonly GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for Tests
        public CharacterUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public CharacterUpdatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

            MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopModalAsync();
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
        /// Catch the change to the stepper for Level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Level_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            LevelValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Catch the change to the stepper for Attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Attack_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            AttackValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Catch the change to the stepper for Defense
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Defense_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            DefenseValue.Text = String.Format("{0}", e.NewValue);
        }
    }
}