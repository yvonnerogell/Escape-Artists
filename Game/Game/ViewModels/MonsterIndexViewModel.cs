using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Models;
using Game.Views;
using Game.GameRules;
using Xamarin.Forms;
using Game.Views.Monsters;

namespace Game.ViewModels
{
	public class MonsterIndexViewModel : BaseViewModel<MonsterModel>
	{

        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile MonsterIndexViewModel instance;
        private static readonly object syncRoot = new Object();

        /// <summary>
        /// Creates an instance of MonsterIndexViewModel
        /// </summary>
        public static MonsterIndexViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MonsterIndexViewModel();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton


        #region SortDataSet

        /// <summary>
        /// The Sort Order for the MonsterModel
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public override List<MonsterModel> SortDataset(List<MonsterModel> dataset)
        {
            return dataset
                    .OrderBy(a => a.Name)
                    .ThenBy(a => a.Description)
                    .ToList();
        }

        #endregion SortDataSet

        /// <summary>
        /// Constructor
        /// 
        /// The constructor subscribes message listeners for crudi operations
        /// </summary>
        public MonsterIndexViewModel()
        {
            Title = "Monsters";

            #region Messages

            // Register the Create Message
            MessagingCenter.Subscribe<MonsterCreatePage, MonsterModel>(this, "Create", async (obj, data) =>
            {
                await CreateAsync(data as MonsterModel);
            });

            // Register the Update Message
            // TODO: Change to MonsterUpdatePage once page has been created. 
            MessagingCenter.Subscribe<CharacterUpdatePage, MonsterModel>(this, "Update", async (obj, data) =>
            {
                // Have the item update itself
                data.Update(data);
                
                await UpdateAsync(data as MonsterModel);
            });

            // Register the Delete Message
            MessagingCenter.Subscribe<MonsterDeletePage, MonsterModel>(this, "Delete", async (obj, data) =>
            {
                await DeleteAsync(data as MonsterModel);
            });

            // Register the Set Data Source Message
            MessagingCenter.Subscribe<AboutPage, int>(this, "SetDataSource", async (obj, data) =>
            {
                await SetDataSource(data);
            });

            // Register the Wipe Data List Message
            MessagingCenter.Subscribe<AboutPage, bool>(this, "WipeDataList", async (obj, data) =>
            {
                await WipeDataListAsync();
            });

            #endregion Messages
        }

        /// <summary>
        /// Returns the item passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override MonsterModel CheckIfExists(MonsterModel data)
        {
            if (data == null)
            {
                return null;
            }

            // This will walk the items and find if there is one that is the same.
            // If so, it returns the item...

            var myList = Dataset.Where(a =>
                                        a.Name == data.Name &&
                                        a.Description == data.Description &&
                                        a.Level == data.Level
                                        )
                                        .FirstOrDefault();

            if (myList == null)
            {
                // it's not a match, return false;
                return null;
            }

            return myList;
        }

        /// <summary>
        /// Load the Default Data
        /// </summary>
        /// <returns></returns>
        public override List<MonsterModel> GetDefaultData()
        {
            return DefaultData.LoadData(new MonsterModel());
        }

        /// <summary>
        /// Get the ID of the Default Monster for the Specific Monster Type
        /// The Default monster is the first Monster in the List
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string GetDefaultMonsterId(SpecificMonsterTypeEnum MonsterType)
        {
            var data = GetDefaultMonster(MonsterType);
            if (data == null)
            {
                return null;
            }

            return data.Id;
        }

        /// <summary>
        /// Get the First monster of the specific monster type from the list
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public MonsterModel GetDefaultMonster(SpecificMonsterTypeEnum MonsterType)
        {
            var dataList = GetTypeMonsters(MonsterType);
            if (dataList.Count() == 0)
            {
                return null;
            }

            var data = dataList.FirstOrDefault();

            return data;
        }

        /// <summary>
        /// Get all the monsters for a set specific monster type
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public List<MonsterModel> GetTypeMonsters(SpecificMonsterTypeEnum MonsterType)
        {
            List<MonsterModel> data = null;

            // Find the Items that meet the criteria
            data = Dataset.Where(m => m.SpecificMonsterTypeEnum == MonsterType).ToList();

            return data;
        }

    }
}
