using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service
{
    public interface ILocationService
    {
        IEnumerable<Location> getAllLocation();
        Location getLocation(int id);
    }
}
