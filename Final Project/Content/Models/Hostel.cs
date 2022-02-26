using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project.Content.Models
{
    public class Hostel
    {
        [Required]
        public string h_id{ get; set; }

        [Required]
        public string h_name { get; set; }

        [Required]
        public string h_address { get; set; }
        [Required]
        public string roomseats { get; set; }

        [Required]
        public bool geazer { get; set; }
        [Required]
        public bool heater { get; set; }
        [Required]
        public bool AC { get; set; }



    }
}