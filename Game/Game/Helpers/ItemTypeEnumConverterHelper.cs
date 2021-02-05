﻿using System;
using System.Globalization;

using Xamarin.Forms;
using Game.Models;

namespace Game.Helpers
{
    // This converter is used by the Pickers, to change from the picker value to the string value etc.
    // This allows the convert in the picker to be data bound back and forth the model
    // The picker requires this because the picker must be a string, but the enum is a value...

    /// <summary>
    /// Converts from an Int to an Enum value
    /// </summary>
    public class ItemTypeEnumConverter : IValueConverter
    {
        /// <summary>
        /// Converts String to Int
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Enum)
            {
                //return (int)value;
                return ((ItemTypeEnum)value).ToMessage();
            }

            if (value is string)
            {
                // Convert String Enum and then Enum to Message
                var myEnum = ItemTypeEnumHelper.ConvertMessageStringToEnum((string)value);
                var myReturn = myEnum.ToMessage();

                return myReturn;
            }

            return 0;
        }

        /// <summary>
        /// Converts from Int to String
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                var myReturn = Enum.ToObject(targetType, value);
                return ((ItemTypeEnum)myReturn).ToMessage();
            }

            if (value is string)
            {
                // Convert the Message String to the Enum
                var myReturn = ItemTypeEnumHelper.ConvertStringToEnum((string)value);

                return myReturn;
            }
            return 0;
        }
    }
}