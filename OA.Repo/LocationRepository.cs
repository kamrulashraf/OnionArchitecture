using Microsoft.EntityFrameworkCore;
using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA.Repo
{
    public class LocationRepository<Location> :ILocationRepository<Location>
    {
        private readonly DataBaseContext _context;
        //private DbSet<Location> entities;
        public LocationRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> getAll()
        {
            return (IEnumerable<Location>) _context.Location.Select(m=>m).AsEnumerable();
        }

    }
}
