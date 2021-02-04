using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            ViewModel.Data.ImageURI = GetImageURI();

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
            var monsterType = ViewModel.Data.SpecificMonsterTypeEnum.Value;
            var imageURI = Constants.SpecificMonsterTypeDefaultImageURI;

            // Change image based on type selected. 
            // Had to do an if statement instead of switch because switch statements cannot have evaluated statements as case statements. 
            if (monsterType == SpecificMonsterTypeEnum.AdjunctFaculty.Value)
			{
                imageURI = Constants.SpecificMonsterTypeAdjunctFacultyImageURI;
            }
            else if (monsterType == SpecificMonsterTypeEnum.AssistantProfessor.Value)
			{
                imageURI = Constants.SpecificMonsterTypeAssistantProfessorImageURI;
            }
            else if (monsterType == SpecificMonsterTypeEnum.AssociateProfessor.Value)
            {
                imageURI = Constants.SpecificMonsterTypeAssociateProfessorImageURI;
            }
            else if (monsterType == SpecificMonsterTypeEnum.GraduationOfficeAdministrator.Value)
            {
                imageURI = Constants.SpecificMonsterTypeGraduationOfficeAdministratorImageURI;
            }
            else if (monsterType == SpecificMonsterTypeEnum.HRAdministrator.Value)
            {
                imageURI = Constants.SpecificMonsterTypeHRAdministratorImageURI;
            }
            else if (monsterType == SpecificMonsterTypeEnum.Professor.Value)
            {
                imageURI = Constants.SpecificMonsterTypeProfessorImageURI;
            }
            else if (monsterType == SpecificMonsterTypeEnum.RegistrationAdministrator.Value)
            {
                imageURI = Constants.SpecificMonsterTypeRegistrationAdministratorImageURI;
            }
            else if (monsterType == SpecificMonsterTypeEnum.TeachingAssistant.Value)
            {
                imageURI = Constants.SpecificMonsterTypeTeachingAssistantImageURI;
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

        /// <summary>
        /// Catch the change to the Stepper for Attack
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

        /// <summary>
        /// Catch the change to the stepper for Speed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Speed_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            SpeedValue.Text = String.Format("{0}", e.NewValue);
        }
    }
}