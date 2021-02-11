using GarageApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageApi.Services
{
    public class ServiceService
    {
        public IEnumerable<Service> GetServices()
        {
            var services = new List<Service>();
            for (int i = 1; i < 5; i++)
            {
                services.Add(new Service
                {
                    Id = i,
                    Name = $"ServiceName_{i}",
                    GarageId = i,
                   
                    Requirements = $"ServiceRequirements{i}"
                });
            }
            return services;
        }
    }
}
