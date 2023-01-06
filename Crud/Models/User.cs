using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    [ModelMetadataType(typeof(User_Validation))]
    public partial class User
    {
        [Key]
        public int Id { get; set; }
       
        public string  FirstName { get; set; }
        
        public string  LastName { get; set; }
       
        public string  Email { get; set; }
      
        public string  Phone { get; set; }
       
        public string  Adderss { get; set; }

        //[NotMapped]
        public int CountryId { get; set; }
        [NotMapped]
        public string CountryName { get; set; }

        //[NotMapped]
        public int StateId { get; set; }
        [NotMapped]
        public string StateName { get; set; }
        //[NotMapped]
        public int CityId { get; set; }
        [NotMapped]
        public string CityName { get; set; }

       
        public string PhotoUrl { get; set; }

        [Display(Name = "Profile Photo")]
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; }

        [NotMapped]
        public string BreifPhotoName { get; set; }
    }
}
