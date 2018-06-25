﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace TravelAgency.Common
{
    /// <summary>
    /// 用于找到对应国家的图标
    /// </summary>
    public static class CountryPicHandler
    {
        public static Dictionary<string, Image> LoadedCountryImage = new Dictionary<string, Image>();

        public static Image LoadImageByCountryName(string countryName)
        {
            if (string.IsNullOrEmpty(countryName))
                return null;

            if (LoadedCountryImage.ContainsKey(countryName))
                return LoadedCountryImage[countryName];

            if (!File.Exists(GlobalUtils.AppPath + "\\CountryImages\\" + countryName + ".png"))
                return null;
            try
            {
                Image img = Image.FromFile(GlobalUtils.AppPath + "\\CountryImages\\" + countryName + ".png");
                LoadedCountryImage.Add(countryName, img);
                return img;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}