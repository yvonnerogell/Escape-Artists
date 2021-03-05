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

        //stores the newItems
        public List<ItemModel> newItems = new List<ItemModel>();

        // Empty Constructor for UTs
        public CharacterCreatePage(bool UnitTest) { }

        // Constructor
        public CharacterCreatePage()
        {
            BindingContext = this.ViewModel.Data = new CharacterModel();

            InitializeComponent();

            this.ViewModel.Title = "Create";
        }

        /// <summary>
        /// Any time picker changes, items reset based on player type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;

            // clear the previous items on location
            ClearPreviousItems();

            // get specificCharacterTypeEnum
            SpecificCharacterTypeEnum SpecificCharacterTypeEnum = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum((string)picker.SelectedItem);

            //get the items based on character
            newItems = ViewModel.Data.ItemsBasedOnCharacterType(SpecificCharacterTypeEnum);

            //remove items from page
            var FlexList = ItemBox.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemBox.Children.Remove(data);
            }

            //add items to page
            AddItemsToDisplay();
        }

        /// <summary>
        /// Clear previously selected character type items
        /// </summary>
        public void ClearPreviousItems()
        {
            ViewModel.Data.Head = null;
            ViewModel.Data.Necklace = null;
            ViewModel.Data.PrimaryHand = null; 
            ViewModel.Data.OffHand = null;
            ViewModel.Data.RightFinger = null;
            ViewModel.Data.LeftFinger = null;
            ViewModel.Data.Feet = null;
        }

        /// <summary>
        /// Show the Items the Character has
        /// </summary>
        public void AddItemsToDisplay()
        {
            var FlexList = ItemBox.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemBox.Children.Remove(data);
            }

            if (ViewModel.Data.Head != null)
            {
                ItemBox.Children.Add(LoadItem(ItemLocationEnum.Head));
            }
            if (ViewModel.Data.Necklace != null)
            {
                ItemBox.Children.Add(LoadItem(ItemLocationEnum.Necklace));
            }
            if (ViewModel.Data.PrimaryHand != null)
            {
                ItemBox.Children.Add(LoadItem(ItemLocationEnum.PrimaryHand));
            }
            if (ViewModel.Data.OffHand != null)
            {
                ItemBox.Children.Add(LoadItem(ItemLocationEnum.OffHand));
            }
            if (ViewModel.Data.RightFinger != null)
            {
                ItemBox.Children.Add(LoadItem(ItemLocationEnum.RightFinger));
            }
            if (ViewModel.Data.LeftFinger != null)
            {
                ItemBox.Children.Add(LoadItem(ItemLocationEnum.LeftFinger));
            }
            if (ViewModel.Data.Feet != null)
            {
                ItemBox.Children.Add(LoadItem(ItemLocationEnum.Feet));
            }
        }

        /// <summary>
        /// load an item
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout LoadItem(ItemLocationEnum location)
        {
            ItemModel data = null;
            // check 
            foreach (ItemModel item in newItems)
            {
                if (item.Location == location)
                {
                    data = item;
                }
            }

            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ItemImageClicked"],
                Source = data.ImageURI
            };

            // Add clicked method to load item info.
            ItemButton.Clicked += (sender, args) => ShowItem(data);

            // Add the Display Text for the item
            var ItemLabel = new Label
            {
                Text = location.ToMessage(),
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 3,
                Style = (Style)Application.Current.Resources["ItemImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    ItemButton,
                    ItemLabel
                },
            };

            return ItemStack;
        }

        /// <summary>
        /// Triggers the update item page 
        /// </summary>
        /// <param name="location"></param>
        public async void ShowItem(ItemModel data)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage(new GenericViewModel<ItemModel>(data))));
            await Navigation.PushAsync(new ItemDetailPage(new GenericViewModel<ItemModel>(data)));
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
                ViewModel.Data.ImageURI = SpecificCharacterTypeEnumHelper.ToImageURI(ViewModel.Data.SpecificCharacterTypeEnum);
                ViewModel.Data.SpecialAbility = SpecificCharacterTypeEnumHelper.ToAbility(ViewModel.Data.SpecificCharacterTypeEnum);
                ViewModel.Data.Range = SpecificCharacterTypeEnumHelper.ToRange(ViewModel.Data.SpecificCharacterTypeEnum);
                MessagingCenter.Send(this, "Create", ViewModel.Data);

                foreach (var item in newItems)
                {
                    MessagingCenter.Send(this, "CreateItem", item);
                }

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
