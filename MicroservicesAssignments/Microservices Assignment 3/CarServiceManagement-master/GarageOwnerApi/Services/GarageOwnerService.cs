using GarageOwnerApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageOwnerApi.Services
{
    public class GarageOwnerService
    {
        public IEnumerable<GarageOwner> GetGarageOwners()
        {
            var owners = new List<GarageOwner>();
            for(int i=1;i<5;i++)
            {
                owners.Add(new GarageOwner {
                    Id = i,
                    Name = $"GarageOwner{i}",
                    Address = $"Address_{i}",
                    Email = $"Email{i}",
                    Mobile = $"Mobile{i}"
                });
            }
            return owners;
        }
    }
}
