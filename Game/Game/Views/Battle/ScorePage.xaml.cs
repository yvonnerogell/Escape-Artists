using Game.GameRules;
using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScorePage: ContentPage
	{
        // This uses the Instance so it can be shared with other Battle Pages as needed
        public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        // TODO remove these if we aren't using stubbing
        public static int NUM_CHARACTERS = 4;
        public static int NUM_ITEMS = 5;
        public static int NUM_GRADUATES = 3;
        public static int NUM_MONSTERS = 4;

        /// <summary>
        /// Constructor
        /// </summary>
        public ScorePage ()
        {
            InitializeComponent();

            // Setting up the BattleEngineViewModel with default data to use for testing
            // TODO: Comment this out when ready to use the real battle engine
            //SetUpStubData();


            DrawOutput();
        }

        /// <summary>
        /// Used to test page with fake data
        /// </summary>
        /// <returns></returns>
        public bool SetUpStubData()
        {
            // Add characters to state machine
            var characters = GetCharacterStubList();
            AddStubCharactersToBattleEngineViewModel(characters);

            // Add Graduated Characters to state machine
            var graduatedCharacters = GetGraduatsStubList();
            AddStubGraduatesToBattleEngineViewModel(graduatedCharacters);

            // Add Monsters killed to state machine
            var monsters = GetMonstersStubList();
            AddStubMonstersToBattleEngineViewModel(monsters);

            return true;
        }

        /// <summary>
        /// Helper method to get a default character stub list.
        /// </summary>
        /// <returns></returns>
        public List<CharacterModel> GetCharacterStubList()
        {
            List<CharacterModel> characters = DefaultData.LoadData(new CharacterModel());
            List<CharacterModel> result = new List<CharacterModel>();

            for (var i = 0; i < NUM_CHARACTERS; ++i)
            {
                result.Add(characters.ElementAt(i));
            }
            return result;
        }

        /// <summary>
        /// Helper method to get a graduated character stub list.
        /// </summary>
        /// <returns></returns>
        public List<CharacterModel> GetGraduatsStubList()
        {
            List<CharacterModel> characters = DefaultData.LoadData(new CharacterModel());
            List<CharacterModel> result = new List<CharacterModel>();

            for (var i = 0; i < NUM_GRADUATES; ++i)
            {
                result.Add(characters.ElementAt(i));
            }
            return result;
        }

        /// <summary>
        /// Helper method to get a monster stub list.
        /// </summary>
        /// <returns></returns>
        public List<MonsterModel> GetMonstersStubList()
        {
            List<MonsterModel> characters = DefaultData.LoadData(new MonsterModel());
            List<MonsterModel> result = new List<MonsterModel>();

            for (var i = 0; i < NUM_MONSTERS; ++i)
            {
                result.Add(characters.ElementAt(i));
            }
            return result;
        }

        /// <summary>
        /// Add stub characters to battle engine view model.
        /// </summary>
        /// <returns></returns>
        public bool AddStubCharactersToBattleEngineViewModel(List<CharacterModel> characters)
        {
            foreach (var character in characters)
            {
                EngineViewModel.Engine.EngineSettings.BattleScore.CharacterModelDeathList.Add(new PlayerInfoModel(character));
                //BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(character));
            }
            return true;
        }

        /// <summary>
        /// Add stub graduated characters to battle engine view model.
        /// </summary>
        /// <returns></returns>
        public bool AddStubGraduatesToBattleEngineViewModel(List<CharacterModel> graduates)
        {
            foreach (var graduate in graduates)
            {
                EngineViewModel.Engine.EngineSettings.BattleScore.GraduateModelList.Add(new PlayerInfoModel(graduate));
                //BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(character));
            }
            return true;
        }

        /// <summary>
        /// Add stub monsters to battle engine view model.
        /// </summary>
        /// <returns></returns>
        public bool AddStubMonstersToBattleEngineViewModel(List<MonsterModel> monsters)
        {
            foreach (var monster in monsters)
            {
                EngineViewModel.Engine.EngineSettings.BattleScore.MonsterModelDeathList.Add(new PlayerInfoModel(monster));
                //BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(character));
            }
            return true;
        }

        /// <summary>
        /// Draw data for
        /// Character
        /// Monster
        /// Item
        /// </summary>
        public void DrawOutput()
        {

            // Draw the Characters
            foreach (var data in EngineViewModel.Engine.EngineSettings.BattleScore.CharacterModelDeathList)
            {
                CharacterListFrame.Children.Add(CreateCharacterDisplayBox(data));
            }

            // Draw the Characters
            foreach (var data in EngineViewModel.Engine.EngineSettings.BattleScore.GraduateModelList)
            {
                GraduateListFrame.Children.Add(CreateCharacterDisplayBox(data));
            }

            // Draw the Monsters
            foreach (var data in EngineViewModel.Engine.EngineSettings.BattleScore.MonsterModelDeathList.Distinct())
            {
                MonsterListFrame.Children.Add(CreateMonsterDisplayBox(data));
            }

            // Draw the Items
            foreach (var data in EngineViewModel.Engine.EngineSettings.BattleScore.ItemModelDropList.Distinct())
            {
                ItemListFrame.Children.Add(CreateItemDisplayBox(data));
            }

            // Update Values in the UI
            TotalGraduated.Text = EngineViewModel.Engine.EngineSettings.BattleScore.GraduateModelList.Count().ToString();
            TotalKilled.Text = EngineViewModel.Engine.EngineSettings.BattleScore.MonsterModelDeathList.Count().ToString();
            TotalCollected.Text = EngineViewModel.Engine.EngineSettings.BattleScore.ItemModelDropList.Count().ToString();
            TotalScore.Text = EngineViewModel.Engine.EngineSettings.BattleScore.ExperienceGainedTotal.ToString();
        }

        /// <summary>
        /// Return a stack layout for the Characters
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout CreateCharacterDisplayBox(PlayerInfoModel data)
        {
            if (data == null)
            {
                data = new PlayerInfoModel();
            }

            // Hookup the image
            var PlayerImage = new Image
            {
                Style = (Style)Application.Current.Resources["ImageBattleMediumStyle"],
                Source = data.ImageURI
            };

            // Add the Level
            var PlayerLevelLabel = new Label
            {
                Text = "Level : " + data.Level,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["ScoreCharacterInfoBox"],
                HorizontalOptions = LayoutOptions.Center,
                Padding = 0,
                Spacing = 0,
                Children = {
                    PlayerImage,
                    PlayerLevelLabel,
                },
            };

            return PlayerStack;
        }

        /// <summary>
        /// Return a stack layout for the Monsters
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout CreateMonsterDisplayBox(PlayerInfoModel data)
        {
            if (data == null)
            {
                data = new PlayerInfoModel();
            }

            // Hookup the image
            var PlayerImage = new Image
            {
                Style = (Style)Application.Current.Resources["PlayerBattleSmallStyle"],
                Source = data.ImageURI
            };

            // Add the Level
            var PlayerLevelLabel = new Label
            {
                Text = "Level : " + data.Level,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["ScoreMonsterInfoBox"],
                HorizontalOptions = LayoutOptions.Center,
                Padding = 0,
                Spacing = 0,
                Children = {
                    PlayerImage,
                    PlayerLevelLabel,
                },
            };

            return PlayerStack;
        }

        /// <summary>
        /// Return a stack layout with the Player information inside
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout CreateItemDisplayBox(ItemModel data)
        {
            if (data == null)
            {
                data = new ItemModel();
            }

            // Hookup the image
            var PlayerImage = new Image
            {
                Style = (Style)Application.Current.Resources["ImageBattleSmallStyle"],
                Source = data.ImageURI
            };

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["ScoreItemInfoBox"],
                HorizontalOptions = LayoutOptions.Center,
                Padding = 0,
                Spacing = 0,
                Children = {
                    PlayerImage,
                },
            };

            return PlayerStack;
        }

        /// <summary>
        /// Close the Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}