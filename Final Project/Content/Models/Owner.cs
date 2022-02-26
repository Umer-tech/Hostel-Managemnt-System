using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project.Content.Models
{
    public class Owner
    {
     
        [Required]
        public string o_name { get; set; }

        [Required]
        public string o_email { get; set; }
        [Required]
        public string o_password { get; set; }
        [Required]
        public string o_address { get; set; }

        [Required]
        public string o_phone { get; set; }
    }
}