using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

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
    }
}