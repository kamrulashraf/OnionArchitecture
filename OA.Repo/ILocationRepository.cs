using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo
{
    public interface ILocationRepository <Location>
    {
        IEnumerable<Location> getAll();
    }
}
