﻿using PieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.ViewModels
{
    public class PieDetailViewModel
    {
        public Pie Pie { get; set; }
        public string Review { get; set; }

        public IEnumerable<PieReview> PieReview { get; set; }
    }
}
