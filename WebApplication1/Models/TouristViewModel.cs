using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Web.Models
{
    public class TouristViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        [Required]
        public string  Address { get; set; }
        public int  Rating { get; set; }
        public string Location { get; set; }
        public int LocationId { get; set; }
        public TouristViewModel()
        {

        }

        public TouristViewModel(int id ,string name , string image , string address , int rating , string location ="",int LocationId = 0)
        {
            Id = id;
            Name = name;
            Image = image;
            Address = address;
            Rating = rating;
            Location = location;
            this.LocationId = LocationId;
        }
    }
}
