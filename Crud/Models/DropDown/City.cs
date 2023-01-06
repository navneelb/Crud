using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        
        [ForeignKey("State")]
        public int StateId { get; set; }
        [Display(Name = "State Name")]
        public  State State { get; set; }

    }
}
