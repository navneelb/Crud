using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        [ForeignKey("CountryName")]
        public int CountryId { get; set; }
        public  Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }

 

    }
}
