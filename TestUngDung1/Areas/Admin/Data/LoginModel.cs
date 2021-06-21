using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUngDung1.Areas.Admin.Data
{
    public class LoginModel
    {
        [DisplayName("Tên người dùng")]
        public int id { get; set; }

        [Required]
        [DisplayName("Tên người dùng")]
        public string UserName { get; set; }

        [DisplayName("Tên người dùng")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}