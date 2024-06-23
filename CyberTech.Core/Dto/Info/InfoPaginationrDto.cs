﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberTech.Core.Dto.Info
{
    public class InfoPaginationrDto
    {
        public string TitleInfo { get; set; }
        public string TextInfo { get; set; }
        public DateTime DataInfo { get; set; }

        public int ItemsPerPage { get; set; }

        public int Page { get; set; }
    }
}