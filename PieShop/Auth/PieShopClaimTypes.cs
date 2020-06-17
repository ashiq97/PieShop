using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Auth
{
    public static class PieShopClaimTypes
    {
      public static List<string> ClaimsList { get; set; } = new List<string> { "Delete Pie", "Add Pie", "Age for ordering" };
    }
}
