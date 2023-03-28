using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models.Users
{
    public class UserLoginViewModel
    {
        
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
