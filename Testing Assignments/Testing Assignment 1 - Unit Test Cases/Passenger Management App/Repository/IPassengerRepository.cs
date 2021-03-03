using Passenger_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Passenger_Management_App.Repository
{
    public interface IPassengerRepository
    {
        string GetData();

        List<Passenger> GetPassengers();
        Passenger GetPassenger(int id);
         Passenger AddorEditPassenger(Passenger passenger);
         Passenger DeletePassenger(int id);
    }
}