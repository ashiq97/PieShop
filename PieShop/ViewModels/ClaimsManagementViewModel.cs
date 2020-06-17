using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.ViewModels
{
    public class ClaimsManagementViewModel
    {
        public string UserId { get; set; }
        public string ClaimId { get; set; }
        public List<string> AllClaimsList { get; set; }
    }
}
