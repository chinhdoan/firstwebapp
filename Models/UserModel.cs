using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evncpc.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="First Name is required")]
        public String FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        public String LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName is required")]
        public String UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public String Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password and Confirm Password should be same")]
        public String ConfirmPassword { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}