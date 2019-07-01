using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class UserRoleViewModel
    {

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public string Email { get; set; }
    }
}