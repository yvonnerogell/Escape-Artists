﻿using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

using Game.Models;
using Game.Views;
using Game.GameRules;

namespace Game.ViewModels
{
    /// <summary>
    /// Index View Model
    /// Manages the list of data records
    /// </summary>
    public class ItemIndexViewModel : BaseViewModel<BodyPartModel>
    {
        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile ItemIndexViewModel instance;
        private static readonly object syncRoot = new Object();

        public static ItemIndexViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ItemIndexViewModel();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        #region Constructor

        /// <summary>
        /// Constructor
        /// 
        /// The constructor subscribes message listeners for crudi operations
        /// </summary>
        public ItemIndexViewModel()
        {
            Title = "Items";

            #region Messages

            // Register the Create Message
            MessagingCenter.Subscribe<ItemCreatePage, BodyPartModel>(this, "Create", async (obj, data) =>
            {
                await CreateAsync(data as BodyPartModel);
            });

            // Register the Update Message
            MessagingCenter.Subscribe<ItemUpdatePage, BodyPartModel>(this, "Update", async (obj, data) =>
            {
                // Have the item update itself
                data.Update(data);

                await UpdateAsync(data as BodyPartModel);
            });

            // Register the Delete Message
            MessagingCenter.Subscribe<ItemDeletePage, BodyPartModel>(this, "Delete", async (obj, data) =>
            {
                await DeleteAsync(data as BodyPartModel);
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

        #endregion Constructor
        
        #region DataOperations_CRUDi

        /// <summary>
        /// Returns the item passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override BodyPartModel CheckIfExists(BodyPartModel data)
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
                                        a.Damage == data.Damage &&
                                        a.Attribute == data.Attribute &&
                                        a.Location == data.Location &&
                                        a.Range == data.Range &&
                                        a.Value == data.Value
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
        public override List<BodyPartModel> GetDefaultData() 
        {
            return DefaultData.LoadData(new BodyPartModel());
        }

        #endregion DataOperations_CRUDi

        #region SortDataSet

        /// <summary>
        /// The Sort Order for the ItemModel
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public override List<BodyPartModel> SortDataset(List<BodyPartModel> dataset)
        {
            return dataset
                    .OrderBy(a => a.Name)
                    .ThenBy(a => a.Description)
                    .ToList();
        }

        #endregion SortDataSet

        /// <summary>
        /// Takes an item string ID and looks it up and returns the item
        /// This is because the Items on a character are stores as strings of the GUID.  That way it can be saved to the DB.
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public BodyPartModel GetItem(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            // Item myData = DataStore.GetAsync_Item(ItemID).GetAwaiter().GetResult();
            BodyPartModel myData = Dataset.Where(a => a.Id.Equals(id)).FirstOrDefault();
            if (myData == null)
            {
                return null;
            }

            return myData;
        }

        /// <summary>
        /// Get the ID of the Default Item for the Location
        /// The Default item is the first Item in the List
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string GetDefaultItemId(BodyPartEnum location)
        {
            var data = GetDefaultItem(location);
            if (data == null)
            {
                return null;
            }

            return data.Id;
        }

        /// <summary>
        /// Get the First item of the location from the list
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public BodyPartModel GetDefaultItem(BodyPartEnum location)
        {
            var dataList = GetLocationItems(location);
            if (dataList.Count() == 0)
            {
                return null;
            }

            var data = dataList.FirstOrDefault();

            return data;
        }
        
        /// <summary>
        /// Get all the items for a set location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public List<BodyPartModel> GetLocationItems(BodyPartEnum location)
        {
            List<BodyPartModel> data = null;

            // Convert Right and Left Finger to Finger
            if (location == BodyPartEnum.RightFinger)
            {
                location = BodyPartEnum.Finger;
            }

            if (location == BodyPartEnum.LeftFinger)
            {
                location = BodyPartEnum.Finger;
            }

            // Find the Items that meet the criteria
            data = Dataset.Where(m => m.Location == location).ToList();

            return data;
        }
    }
}