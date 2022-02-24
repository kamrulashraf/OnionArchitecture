using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service
{
    public interface ITouristService
    {
        IEnumerable<TouristPlace> getAllTourstPlaceName(string sortState, string nameSearch);
        IEnumerable<TouristPlace> getAllTourstPlaceName();
        void InsertTouristPlace(TouristPlace entity);
        void UpdateToristPlace(TouristPlace entity);
        TouristPlace get(int id);
        void removeTouristPlace(TouristPlace entity);
    }
}
