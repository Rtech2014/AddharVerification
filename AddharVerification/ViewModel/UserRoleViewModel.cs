using AddharVerification.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddharVerification.ViewModel
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            Users = new List<AppUser>();
        }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public List<AppUser> Users { get; set; }



    }
}
