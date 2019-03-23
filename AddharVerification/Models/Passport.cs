using AddharVerification.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddharVerification.Models
{
    public class Passport
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Display(Name = "Phone Number")]
        public string MobileNum { get; set; }

        [Display(Name = "Aadhar Id")]
        public string Aadhar { get; set; }

        [Display(Name = "Country")]
        public string PlaceOfBirth { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Civil Status | Relationship Status", Prompt = "Single or Married or Widow/er")]
        public string CivilStatus { get; set; }

        [Display(Name = "Address", Prompt = "45, 7th East Main Rd, Suthanthira Ponvizha Nagar, Gandhi Nagar, Vellore, Tamil Nadu 632006")]
        public string Address { get; set; }

        [Display(Name = "Occupation", Prompt = "Engineer, Doctor, Driver")]
        public string Occupation { get; set; }

        [Display(Name = "Name of your Mother")]
        public string NameOfMother { get; set; }

        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }

        [Display(Name = "Name of your Father")]
        public string NameOfFather { get; set; }

        [Display(Name = "Citizen-ship", Prompt = "Indian | Australian | American")]
        public string Citizenship { get; set; }

        [Display(Name = "Your Passport Size Photo")]
        public byte[] Photo { get; set; }

        public string ApplicationMemberId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
