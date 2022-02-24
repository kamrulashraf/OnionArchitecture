using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Data
{
    public class TouristPlace:BaseClass
    {
        public string Name { get; set; }
        public string Address{ get; set; }
        public string Image { get; set; }
        public int  Rating { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
