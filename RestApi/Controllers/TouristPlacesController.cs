using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Data;
using OA.Service;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristPlacesController : ControllerBase
    {
        private readonly ITouristService touristService;
        private readonly ILocationService locationService;

        public TouristPlacesController(ITouristService touristVar, ILocationService locationVar)
        {
            touristService = touristVar;
            locationService = locationVar;
        }
        public IEnumerable<Object> Get()
        {
            //IEnumerable<Object> allTouristPlace = touristService.getAllTourstPlaceName().Select(m=> new { m.Id , m.Name , m.Address , m.Rating , m.LocationId});
            var touristTable = touristService.getAllTourstPlaceName();
            var locationTable = locationService.getAllLocation();
            var result = touristTable.Join(
                locationTable,
                x => x.LocationId,
                y => y.Id,
                (x, y) => new{
                    x.Id,
                    x.Name,
                    x.Rating,
                    x.Address,
                    y.Country
                });
            return result;
        }

        [HttpGet("{id}")]
        public TouristPlace Get(int id)
        {
            return touristService.get(id);
        }

        [HttpPost]
        public void Post([FromBody] TouristPlace touristPlace)
        {
            touristService.InsertTouristPlace(touristPlace);
            return;
        }

        [HttpPut("{id}")]
        public void Put([FromBody] TouristPlace touristPlace)
        {
            touristService.UpdateToristPlace(touristPlace);
            return;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TouristPlace touristPlace = touristService.get(id);
            touristService.removeTouristPlace(touristPlace);
            return;
        }
    }
}