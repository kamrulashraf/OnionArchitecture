using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OA.Data;
using OA.Service;
using OA.Web.Models;

namespace OA.Web.Controllers
{
    public class TouristPlacesController : Controller
    {
        private readonly ITouristService touristService;
        private readonly ILocationService locationService;
        public int Rating { get; private set; }

        public TouristPlacesController(ITouristService touristVar, ILocationService locationVar)
        {
            this.touristService = touristVar;
            this.locationService = locationVar;
        }

        public void checkAndSetSession(string sortState, string nameSearch , string flag)
        {
            if (HttpContext.Session.GetString("sort") == null) HttpContext.Session.SetString("sort", "A");
            if (!string.IsNullOrEmpty(sortState))
            {
                if (HttpContext.Session.GetString("sort") == "A") HttpContext.Session.SetString("sort", "B");
                else HttpContext.Session.SetString("sort", "A");
            }
            if (!string.IsNullOrEmpty(flag))
            {
                HttpContext.Session.SetString("search", nameSearch == null ? "" : nameSearch);
            }
        }

        public IActionResult Index(string sortState, string nameSearch, string flag)
        {
            checkAndSetSession(sortState, nameSearch, flag);

            sortState = HttpContext.Session.GetString("sort");
            nameSearch = HttpContext.Session.GetString("search");
            ViewBag.search = nameSearch;
            if (string.IsNullOrEmpty(nameSearch)) nameSearch = "";
           
            var filteredTouristPlace = touristService.getAllTourstPlaceName(sortState,nameSearch);
            List<TouristViewModel> toristViewModel = new List<TouristViewModel>();

            foreach (var i in filteredTouristPlace)
            {
                toristViewModel.Add(new TouristViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Image = i.Image,
                    Address = i.Address,
                    Rating = i.Rating,
                    Location = locationService.getLocation(i.LocationId).Country
                });
            }
            return View(toristViewModel);
        }

        public IActionResult Create()
        {
            ViewBag.search = HttpContext.Session.GetString("search");
            Populatedata();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Address,Image,Rating,LocationId")] TouristViewModel tourist, IFormFile img,string nameSearch)
        {
           
            if (ModelState.IsValid)
            {
                using (var fs1 = img.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    fs1.CopyTo(ms);
                    tourist.Image = Convert.ToBase64String(ms.ToArray());
                }

                TouristPlace tPlace = new TouristPlace
                {
                    Name = tourist.Name,
                    Rating = tourist.Rating,
                    Image = tourist.Image,
                    Address = tourist.Address,
                    LocationId = tourist.LocationId
                };

                touristService.InsertTouristPlace(tPlace);
                return RedirectToAction("Index" ,new {flag = "1" , nameSearch = nameSearch } );
            }
            return View(tourist);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var temp = touristService.get((int)id);
            TouristViewModel tPlace = new TouristViewModel{
                Id = temp.Id,
                Name = temp.Name,
                Address = temp.Address,
                Image = temp.Image,
                Rating = temp.Rating,
                Location = locationService.getLocation(temp.LocationId).Country,
                LocationId = temp.LocationId
            };
            if (tPlace == null)
            {
                return NotFound();
            }
            Populatedata(temp.LocationId);
            return View(tPlace);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Name,Address,Image,Rating,LocationId")] TouristViewModel tourist, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    using (var fs1 = img.OpenReadStream())
                    using (var ms = new MemoryStream())
                    {
                        fs1.CopyTo(ms);
                        tourist.Image = Convert.ToBase64String(ms.ToArray());
                    }
                }
                TouristPlace tPlace = new TouristPlace
                {
                    Id = tourist.Id,
                    Name = tourist.Name,
                    Rating = tourist.Rating,
                    Image = tourist.Image,
                    Address = tourist.Address,
                    LocationId = tourist.LocationId
                };

                touristService.UpdateToristPlace(tPlace);
                return RedirectToAction(nameof(Index));
            }
            return View(tourist);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var temp = touristService.get((int)id);
            TouristViewModel tPlace = new TouristViewModel
            {
                Id = temp.Id,
                Name = temp.Name,
                Image = temp.Image,
                Address = temp.Address,
                Rating = temp.Rating,
                Location = locationService.getLocation(temp.LocationId).Country,
                LocationId = temp.LocationId
            };
            if (tPlace == null)
            {
                return NotFound();
            }
            return View(tPlace);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Confirm(int id)
        {
            var touristRem = touristService.get((int)id);
            touristService.removeTouristPlace(touristRem);
            return RedirectToAction(nameof(Index));
        }


        private void Populatedata(int id=0)
        {
            var allCountry = locationService.getAllLocation();
            ViewBag.Country = new SelectList(allCountry, "Id", "Country", id);
        }
    }
}