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
        List<ItemModel> newItems = new List<ItemModel>();

        //constructor
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
            //get the items based on character
            newItems = ViewModel.Data.UpdateItemsBasedOnCharacterType(ViewModel.Data.SpecificCharacterTypeEnum);

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
                Style = (Style)Application.Current.Resources["ItemImage"],
                Source = data.ImageURI,
            };
            ItemButton.Clicked += (sender, args) => UpdateNewItem(sender, data);

            // Add the Display Text for the item
            var ItemLabel = new Label
            {
                Text = data.ItemType.ToMessage(),
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

            return ItemStack;
        }

        /// <summary>
        /// Triggers the update item page 
        /// </summary>
        /// <param name="location"></param>
        public async void UpdateNewItem(object sender, ItemModel data)
        {
            // Add the item to the location
            ViewModel.Data.AddItem(data.Location, data.Id);
            MessagingCenter.Send(this, "CreateItem", data);
            // trigger new item create page with created item
            GenericViewModel<ItemModel> generalData = new GenericViewModel<ItemModel>(data);
            await Navigation.PushModalAsync(new NavigationPage(new ItemUpdatePage(generalData)));

            ImageButton btn = sender as ImageButton;
            btn.Style = (Style)Application.Current.Resources["ItemImageClicked"];
            btn.IsEnabled = false;
            // TODO: need to work on reloading the current page after item is created
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
                
                // Add Items
                //foreach (ItemModel item in newItems)
                //{
                //    MessagingCenter.Send(this, "CreateItem", item);
                //}

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

            if (sender == GPASlider)
            {
                GPAValue.Text = newValueStr;
                GPASlider.Value = newValue;
            }
        }
    }
}
