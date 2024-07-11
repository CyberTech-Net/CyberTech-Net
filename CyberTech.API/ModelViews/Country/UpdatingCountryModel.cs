﻿namespace CyberTech.API.ModelViews.Country
{
    /// <summary>
    /// Модель редактируемой страны.
    /// </summary>
    public class UpdatingCountryModel
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string TitleCountry { get; set; }
        /// <summary>
        /// Картинка.
        /// </summary>
        public string ImageId { get; set; }
    }
}
