using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Data
{
    public class Location:BaseClass
    {
        public string Country { get; set; }
        public virtual ICollection<TouristPlace> Tourists { get; set; }
    }
}
