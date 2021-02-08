using Game.Models;
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
            ViewModel.Data.SpecificMonsterTypeEnum = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum(MonsterTypePicker.SelectedItem.ToString());
            ViewModel.Data.MonsterTypeEnum = SpecificMonsterTypeEnumHelper.GetMonsterTypeEnumFromSpecificMonsterTypeEnum(ViewModel.Data.SpecificMonsterTypeEnum);
            ViewModel.Data.UpdateImageURI(ViewModel.Data);

            // Check to see if name and description were filled in by user. If not, use default data. 
            if (String.IsNullOrEmpty(ViewModel.Data.Name))
            {
                ViewModel.Data.Name = Constants.MonsterNameDefault;
            }

            // TODO Unique Drop item - do we want to randomly assign one here?

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