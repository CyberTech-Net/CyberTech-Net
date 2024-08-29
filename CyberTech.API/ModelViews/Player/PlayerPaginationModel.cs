﻿using CyberTech.API.ModelViews.Country;

namespace CyberTech.API.ModelViews.Player
{
    public class PlayerPaginationModel
    {
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string BirthDate { get; set; }
        public CountryModel Country { get; set; }
        public string ImageId { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }
}
