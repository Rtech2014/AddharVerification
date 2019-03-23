using AddharVerification.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddharVerification.Models
{
    public class Visa
    {
        public int Id { get; set; }

        [Display(Name = "From Location")]
        public string Current { get; set; }

        [Display(Name = "To Location")]
        public string Destination { get; set; }

        public string ApplicationMemberId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
