using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTracker.BackService.Models
{
    public class Repository
    {
        private List<Trip> MyTrips = new List<Trip>
        {
            new Trip
            {
                Id =1,
                Name = "Maldivs Tour",
                StartDate = new DateTime (2018,10 ,5),
                EndDate = new DateTime(2018,10 ,8)
            },
            new Trip
            {
                Id =2,
                Name = "Dubai Tour",
                StartDate = new DateTime (2018,12 ,20),
                EndDate = new DateTime(2018,12 ,26)
            },
            new Trip
            {
                Id =3,
                Name = "Singapore Tour",
                StartDate = new DateTime (2019,1,20),
                EndDate = new DateTime(2018,1 ,24)
            }
        };

        public List<Trip> Get()
        {
            return MyTrips;
        }

        public Trip Get(int id)
        {
            return MyTrips.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Trip newTrip)
        {
            MyTrips.Add(newTrip);
        }

        public void Update(Trip tripToUpdate)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == tripToUpdate.Id));
            Add(tripToUpdate);
        }

        public void Remove(int id)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == id));
            
        }
    }
}
