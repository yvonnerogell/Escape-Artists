using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views.Characters
{
    /// <summary>
    /// The Create page for the characters
    /// </summary>
    public partial class CharacterCreatePage : ContentPage
    {
        public CharacterCreatePage()
        {
            InitializeComponent();

          //  Character = new CharacterModel();

            BindingContext = this;
            
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Cancel and close the create character page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void CancelCharacter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Save the newly created character and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void SaveCharacter_Clicked(object sender, EventArgs e)
        {
           // MessagingCenter.Send(this, "AddItem", );
           // await Navigation.PopModalAsync();

        }
    }
}
