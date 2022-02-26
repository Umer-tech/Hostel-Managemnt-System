using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project.Content.Models
{
    public class Rating
    {
        [Required]
        public string alumni_id { get; set; }
        [Required]
        public string hostel_id { get; set; }
        [Required]
        public string rating { get; set; }
        [Required]
        public string h_name { get; set; }
        [Required]
        public string h_address { get; set; }
        [Required]
        public string h_roomseats { get; set; }



    }
}