using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;


namespace Game.Views.Characters
{
    /// <summary>
    /// The Create page for the characters
    /// </summary>
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterCreatePage : ContentPage
    {
        //new character 
        public GenericViewModel<CharacterModel> ViewModel = new GenericViewModel<CharacterModel>();

        //constructor
        public CharacterCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = new CharacterModel();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Create";
            
        }


        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Cancel and close the create character page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Save the newly created character and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            ViewModel.Data.PlayerType = PlayerTypeEnum.Character;
            ViewModel.Data.SpecificCharacterTypeEnum = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum(CharacterTypePicker.SelectedItem.ToString());
            ViewModel.Data.CharacterTypeEnum = SpecificCharacterTypeEnumHelper.GetCharacterTypeEnumFromSpecificCharacterTypeEnum(ViewModel.Data.SpecificCharacterTypeEnum);
            ViewModel.Data.UpdateImageURI(ViewModel.Data);
            
            // Check to see if name and description were filled in by user. If not, use default data. 
            if (String.IsNullOrEmpty(ViewModel.Data.Name))
			{
                ViewModel.Data.Name = Constants.CharacterNameDefault;
			}
            if (String.IsNullOrEmpty(ViewModel.Data.Description))
            {
                ViewModel.Data.Description = Constants.CharacterDescriptionDefault;
            }

            // TODO add Items

            MessagingCenter.Send(this, "Create", ViewModel.Data);
            await Navigation.PopModalAsync();

        }

        /// <summary>
        /// Changes the slider value for the appropriate slider (attack, defense, speed)
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
        }
    }
}
