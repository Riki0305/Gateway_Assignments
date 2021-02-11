using GarageApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageApi.Services
{
    public class GarageService
    {
        public IEnumerable<Garage> GetGarages()
        {
            var garages = new List<Garage>();
            for(int i=1;i<5;i++)
            {
                garages.Add(new Garage {
                    Id= i ,
                    Name = $"GarageName{i}",
                    GarageOwnerId = i,
                    Address = $"GarageAddress_{i}"
                });
            }
            return garages;
        }


    }
}
