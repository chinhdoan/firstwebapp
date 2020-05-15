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
        [Required(ErrorMessage = "This information is required")]
     
        public  string username{ get; set; }
        [DataType(DataType.Password)]
      
        [Required(ErrorMessage = "This information is required")]
        public string pass{ get; set; }
    }
}