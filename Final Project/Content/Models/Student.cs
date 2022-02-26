using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project.Content.Models
{
    public class Student
    {
        [Required]
        public string s_id { get; set; }
        [Required]
        public string s_name { get; set; }
        [Required]
        public string s_edu { get; set; }
        [Required]
        public string s_uni { get; set; }
    }
}