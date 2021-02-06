﻿using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.Helpers;

namespace Game.Views.Monsters
{
    /// <summary>
    /// Create Item
    /// </summary>
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterCreatePage : ContentPage
    {
        // The item to create
        public GenericViewModel<MonsterModel> ViewModel = new GenericViewModel<MonsterModel>();

        // Empty Constructor for UTs
        public MonsterCreatePage(bool UnitTest){}

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public MonsterCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = new MonsterModel();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Create";

        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            ViewModel.Data.PlayerType = PlayerTypeEnum.Monster;
            ViewModel.Data.ImageURI = GetImageURI();
            ViewModel.Data.SpecificMonsterTypeEnum = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum(MonsterTypePicker.SelectedItem.ToString());
            ViewModel.Data.MonsterTypeEnum = GetMonsterTypeFromSpecificMonsterTypeEnum();

            // TODO Unique Drop item - do we want to randomly assign one here?

            MessagingCenter.Send(this, "Create", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        public MonsterTypeEnum GetMonsterTypeFromSpecificMonsterTypeEnum()
		{
            return MonsterTypeEnum.Unknown;
		}


        /// <summary>
        /// Changes the slider value for the appropriate slider (attack, defense, speed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSliderChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == AttackSlider)
			{
                AttackValue.Text = String.Format("{0}", (int)e.NewValue);
			}
            if (sender == DefenseSlider)
            {
                DefenseValue.Text = String.Format("{0}", (int)e.NewValue);
            }
            if (sender == SpeedSlider)
            {
                SpeedValue.Text = String.Format("{0}", (int)e.NewValue);
            }
        }

        public string GetImageURI()
		{
            var monsterType = ViewModel.Data.SpecificMonsterTypeEnum;
            var imageURI = Constants.SpecificMonsterTypeDefaultImageURI;

            // Change image based on type selected. 
            // Had to do an if statement instead of switch because switch statements cannot have evaluated statements as case statements. 

            switch (monsterType)
			{
                case SpecificMonsterTypeEnum.AdjunctFaculty:
                    imageURI = Constants.SpecificMonsterTypeAdjunctFacultyImageURI;
                    break;
                case SpecificMonsterTypeEnum.AssistantProfessor:
                    imageURI = Constants.SpecificMonsterTypeAssistantProfessorImageURI;
                    break;
                case SpecificMonsterTypeEnum.AssociateProfessor:
                    imageURI = Constants.SpecificMonsterTypeAssociateProfessorImageURI;
                    break;
                case SpecificMonsterTypeEnum.GraduationOfficeAdministrator:
                    imageURI = Constants.SpecificMonsterTypeGraduationOfficeAdministratorImageURI;
                    break;
                case SpecificMonsterTypeEnum.HRAdministrator:
                    imageURI = Constants.SpecificMonsterTypeHRAdministratorImageURI;
                    break;
                case SpecificMonsterTypeEnum.Professor:
                    imageURI = Constants.SpecificMonsterTypeProfessorImageURI;
                    break;
                case SpecificMonsterTypeEnum.RegistrationAdministrator:
                    imageURI = Constants.SpecificMonsterTypeRegistrationAdministratorImageURI;
                    break;
                case SpecificMonsterTypeEnum.TeachingAssistant:
                    imageURI = Constants.SpecificMonsterTypeTeachingAssistantImageURI;
                    break;
            }

            return imageURI;
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
    }
}