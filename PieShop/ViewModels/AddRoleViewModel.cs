using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.ViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name="Role Name")]
        public string RoleName { get; set; }
    }
}
