using ModelEF.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.ViewModels
{
    public class UserViewModel
    {
        [DisplayName("Mã người dùng")]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên người dùng")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }


        public string Email { get; set; }

        public string SoDienThoai { get; set; }

        public UserStatusEnum Status { get; set; }
    }
}
