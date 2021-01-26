using System;
using System.Collections.Generic;
using System.Text;
using Game.Models;
using Game.Views;
using Xamarin.Forms;

namespace Game.ViewModels
{
	public class CharacterIndexViewModel : BaseViewModel<CharacterModel>
	{

        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile CharacterIndexViewModel instance;
        private static readonly object syncRoot = new Object();

        public static CharacterIndexViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new CharacterIndexViewModel();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        /// <summary>
        /// Constructor
        /// 
        /// The constructor subscribes message listeners for crudi operations
        /// </summary>
        public CharacterIndexViewModel()
        {
            Title = "Characters";

            #region Messages

            // Register the Create Message
            //MessagingCenter.Subscribe<CharacterCreatePage, CharacterModel>(this, "Create", async (obj, data) =>
            //{
            //    await CreateAsync(data as CharacterModel);
            //});

            // Register the Update Message
            //MessagingCenter.Subscribe<CharacterUpdatePage, CharacterModel>(this, "Update", async (obj, data) =>
            //{
                // Have the item update itself
             //   data.Update(data);

            //    await UpdateAsync(data as CharacterModel);
            //});

            // Register the Delete Message
            MessagingCenter.Subscribe<CharaterDeletePage, CharacterModel>(this, "Delete", async (obj, data) =>
            {
                await DeleteAsync(data as CharacterModel);
            });

            // Register the Set Data Source Message
            // MessagingCenter.Subscribe<AboutPage, int>(this, "SetDataSource", async (obj, data) =>
            // {
             //   await SetDataSource(data);
           // });

            // Register the Wipe Data List Message
           // MessagingCenter.Subscribe<AboutPage, bool>(this, "WipeDataList", async (obj, data) =>
           // {
           //     await WipeDataListAsync();
           // });

            #endregion Messages
        }
    }
}
