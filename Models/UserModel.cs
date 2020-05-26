using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evncpc.Models
{
    public class UserModel
    {
        public int user_id { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="First Name is required")]
        public String first_name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        public String last_name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName is required")]
        public String user_name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false ,ErrorMessage = "Email is required")]
        public String email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public String password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Thoes passwords didn't match.Try again.")]
        public String confirm_password { get; set; }
        public DateTime created_on { get; set; }
    }
}