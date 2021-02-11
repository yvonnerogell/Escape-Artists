using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;
using System.Linq;

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


        /// <summary>
        /// Any time picker changes, items reset because parents type do not allow head location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            string selectedIndex = (string)picker.SelectedItem;

            if (SpecificCharacterTypeEnumHelper.GetStudentListMessage.Contains(selectedIndex))
            {
                AddStudentItemsToDisplay();
            }
            else
            {
                AddParentItemsToDisplay();
            }

        }

        /// <summary>
        /// Load the item box for students type
        /// </summary>
        public void AddStudentItemsToDisplay()
        {
            var FlexList = ItemBox.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemBox.Children.Remove(data);
            }

            ItemBox.Children.Add(LoadEmptyItem(ItemLocationEnum.Head));
            ItemBox.Children.Add(LoadEmptyItem(ItemLocationEnum.Necklace));
            ItemBox.Children.Add(LoadEmptyItem(ItemLocationEnum.PrimaryHand));
            ItemBox.Children.Add(LoadEmptyItem(ItemLocationEnum.OffHand));
            ItemBox.Children.Add(LoadEmptyItem(ItemLocationEnum.RightFinger));
            ItemBox.Children.Add(LoadEmptyItem(ItemLocationEnum.LeftFinger));
            ItemBox.Children.Add(LoadEmptyItem(ItemLocationEnum.Feet));
        }

        /// <summary>
        /// Load the item box for parents type
        /// </summary>
        public void AddParentItemsToDisplay()
        {
            var FlexList = ItemBox.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemBox.Children.Remove(data);
            }

            ItemBox.Children.Add(LoadEmptyItem(ItemLocationEnum.Necklace));
            ItemBox.Children.Add(LoadEmptyItem(ItemLocationEnum.PrimaryHand));
            ItemBox.Children.Add(LoadEmptyItem(ItemLocationEnum.OffHand));
            ItemBox.Children.Add(LoadEmptyItem(ItemLocationEnum.RightFinger));
            ItemBox.Children.Add(LoadEmptyItem(ItemLocationEnum.LeftFinger));
            ItemBox.Children.Add(LoadEmptyItem(ItemLocationEnum.Feet));
        }

        /// <summary>
        /// load an empty item
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout LoadEmptyItem(ItemLocationEnum location)
        {
            // Defualt Image is the Plus
            var ImageSource = "icon_cancel.png";
            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageMediumStyle"],
                Source = ImageSource,
            };

            // Add the Display Text for the item
            var ItemLabel = new Label
            {
                Text = location.ToMessage(),
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


            // TODO: uncomment once item create page is completed. 
            //ItemButton.Clicked += (sender, args) => CreateNewItem(data);
            return ItemStack;
        }

        public async void CreateNewItem(ItemModel data)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemCreatePage()));
            // TODO: get data that was created and add it. 
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
            // if the name or description are not entered, the page remains on the create screen
            if (string.IsNullOrEmpty(ViewModel.Data.Name) || string.IsNullOrEmpty(ViewModel.Data.Description))
            {
                await Navigation.PushModalAsync(new NavigationPage(new CharacterUpdatePage(ViewModel)));
                await Navigation.PopModalAsync();
            }
            // otherwise it creates and saves the new character
            else
            {
                ViewModel.Data.PlayerType = PlayerTypeEnum.Character;
                ViewModel.Data.SpecificCharacterTypeEnum = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum(CharacterTypePicker.SelectedItem.ToString());
                ViewModel.Data.CharacterTypeEnum = SpecificCharacterTypeEnumHelper.GetCharacterTypeEnumFromSpecificCharacterTypeEnum(ViewModel.Data.SpecificCharacterTypeEnum);
                ViewModel.Data.UpdateImageURI(ViewModel.Data);

                // TODO add Items

                MessagingCenter.Send(this, "Create", ViewModel.Data);
                await Navigation.PopModalAsync();
            }
        }

        /// <summary>
        /// Changes the slider value for the appropriate slider (attack, defense, speed, GPA)
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

            if (sender ==GPASlider)
            {
                GPAValue.Text = newValueStr;
                GPASlider.Value = newValue;
            }
        }
    }
}
