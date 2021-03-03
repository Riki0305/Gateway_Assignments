using Passenger_Management_App.Context;
using Passenger_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Passenger_Management_App.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private PassengerContext _dbContext;

        public PassengerRepository()
        {
            _dbContext = new PassengerContext();
        }
        public string GetData()
        {
            return "Rikin";
        }

        public string GetRandom()
        {
            Random unique = new Random();
            int unique1;
            string n = "PA";
            for(int i=0;i<10;i++)
            {
                unique1 = unique.Next(10);
                n += unique1;
            }
            return n;
        }

        public List<Passenger> GetPassengers()
        {
            return _dbContext.passengers.ToList();
        }

        public Passenger AddorEditPassenger(Passenger passenger)
        {
            try
            {
                if (passenger.Id == 0)
                {
                    passenger.PassengerNo = GetRandom();
                    _dbContext.passengers.Add(passenger);
                    _dbContext.SaveChanges();

                    return passenger;
                }
                else
                {
                    _dbContext.Entry(passenger).State = System.Data.Entity.EntityState.Modified;
                    _dbContext.SaveChanges();
                    return passenger;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Passenger DeletePassenger(int id)
        {
            try
            {
                var passenger = _dbContext.passengers.Find(id);
                if (passenger != null)
                {

                    _dbContext.passengers.Remove(passenger);
                    _dbContext.SaveChanges();

                    return passenger;
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }

        public Passenger GetPassenger(int id)
        {
            return _dbContext.passengers.Find(id);
        }
    }
}