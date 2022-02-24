using OA.Data;
using OA.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service
{
    public class LocationService: ILocationService
    {
        readonly IRepository<Location> LocationRepo; 
        public LocationService (IRepository <Location> locationRepo)
        {
            LocationRepo = locationRepo;
        }
        
        public IEnumerable<Location> getAllLocation()
        {
            return LocationRepo.GetAll();
        }

        public Location getLocation(int id)
        {
            return LocationRepo.get(id);
        }
    }
}
