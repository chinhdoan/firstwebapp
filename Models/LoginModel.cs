using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evncpc.Models
{
    public class LoginModel
    {
       
        [Required(ErrorMessage = "UserName is required")]
     
        public  string user_name{ get; set; }
        [DataType(DataType.Password)]
      
        [Required(ErrorMessage = "Password is required")]
        public string password{ get; set; }
    }
}