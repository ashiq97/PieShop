﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get;}
        IEnumerable<Pie> PiesOfTheWeek { get;}
        Pie GetPieById(int pieId);

        void CreatePie(Pie pie);

        void UpdatePie(Pie pie);

        void DeletePie(int pieId);
    }
}
