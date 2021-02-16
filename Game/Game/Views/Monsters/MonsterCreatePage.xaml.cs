using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.Helpers;
using System.Linq;

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

        // page place holder for dropItem
        ItemModel dropItem = null; 

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

            // Set default values for pickers
            MonsterTypePicker.SelectedIndex = 0;
            DifficultyLevelPicker.SelectedIndex = 0;

        }

        /// <summary>
        /// Any time picker changes, items reset based on player type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            SpecificMonsterTypeEnum SpecificMonsterTypeEnum = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum((string)picker.SelectedItem);

            //get the items based on monster
            dropItem = ViewModel.Data.DropItemBasedOnCharacterType(SpecificMonsterTypeEnum);

            //remove items from page
            var FlexList = ItemBox.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemBox.Children.Remove(data);
            }
            if (dropItem != null)
            {
                ItemBox.Children.Add(LoadItem(dropItem));
            }
        }

        /// <summary>
        /// load an item
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout LoadItem(ItemModel dropItem)
        {
            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ItemImageClicked"],
                Source = dropItem.ImageURI,
            };
            ItemButton.Clicked += (sender, args) => ShowItem(sender, dropItem);

            // Add the Display Text for the item
            var ItemLabel = new Label
            {
                Text = dropItem.ItemType.ToMessage(),
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
        public async void ShowItem(object sender, ItemModel data)
        {
            // trigger new item create page with created item
            await Navigation.PushAsync(new ItemDetailPage(new GenericViewModel<ItemModel>(data)));
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // if the name or description are not entered, the page remains on the create screen
            if (string.IsNullOrEmpty(ViewModel.Data.Name) || string.IsNullOrEmpty(ViewModel.Data.Description))
            {
                await Navigation.PushModalAsync(new NavigationPage(new MonsterUpdatePage(ViewModel)));
                await Navigation.PopModalAsync();
            }
            // otherwise it creates and saves the new monster
            else
            {
                ViewModel.Data.PlayerType = PlayerTypeEnum.Monster;
                ViewModel.Data.SpecificMonsterTypeEnum = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum(MonsterTypePicker.SelectedItem.ToString());
                ViewModel.Data.MonsterTypeEnum = SpecificMonsterTypeEnumHelper.GetMonsterTypeEnumFromSpecificMonsterTypeEnum(ViewModel.Data.SpecificMonsterTypeEnum);
                ViewModel.Data.ImageURI = SpecificMonsterTypeEnumHelper.ToImageURI(ViewModel.Data.SpecificMonsterTypeEnum);

                // Unique Drop item
                MessagingCenter.Send(this, "CreateItem", dropItem);

                MessagingCenter.Send(this, "Create", ViewModel.Data);
                await Navigation.PopModalAsync();
            }
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