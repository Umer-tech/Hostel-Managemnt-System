using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project.Content.Models
{
    public class Alumni
    {
        [Required]
        public string s_name { get; set; }

        [Required]
        public string s_email { get; set; }
        [Required]
        public string s_password { get; set; }
        [Required]
        public string s_address { get; set; }

        [Required]
        public string s_phone { get; set; }
    }
}