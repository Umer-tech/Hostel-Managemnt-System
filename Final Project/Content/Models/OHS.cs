using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project.Content.Models
{
    public class OHS
    {
        [Required]
        public string o_id { get; set; }
        [Required]
        public string h_id { get; set; }
        [Required]
        public string s_id { get; set; }
        public HttpPostedFileBase imageFile { get; set; }
        public string imagepath { get; set; }
        public string Studname { get; set; }

    }
}