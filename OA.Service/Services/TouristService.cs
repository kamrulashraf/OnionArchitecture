using OA.Data;
using OA.Repo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OA.Service
{
    public class TouristService : ITouristService 
    {
        IRepository<TouristPlace> touristRepo;
        
        public TouristService(IRepository <TouristPlace> touristVar)
        {
            this.touristRepo = touristVar;
        }

        public TouristPlace get(int id)
        {
            return touristRepo.get(id);
        }

        public IEnumerable<TouristPlace> getAllTourstPlaceName(string sortState , string searchVal)
        {
            var temp= touristRepo.GetAll();
            if(sortState == "A")
            {
                temp = temp.OrderBy(m => m.Rating).ThenBy(m => m.Name);
            }
            else
            {
                temp = temp.OrderByDescending(m => m.Rating).ThenBy(m => m.Name);
            }

            if (searchVal.Length>0)
            {
                temp = temp.Where(m => m.Name.Contains(searchVal));
            }
            return temp;
        }

        public IEnumerable<TouristPlace> getAllTourstPlaceName()
        {
            var temp = touristRepo.GetAll();
            return temp;
        }

        public void InsertTouristPlace(TouristPlace entity)
        {
            touristRepo.Insert(entity);
        }

        public void UpdateToristPlace(TouristPlace entity)
        {

            touristRepo.Update(entity);
        }
        public void removeTouristPlace(TouristPlace entity)
        {
            touristRepo.Delete(entity);
        }
        
    }
}
