
using SBS.DAL.Context;
using SBS.DAL.Interfaces;
using SBS.DAL.Utility;
using SBS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL
{
    public class ServiceRepository : IServiceRepository
    {
        private ServiceBookingContext _dbContext;
        public ServiceRepository()
        {
            _dbContext = new ServiceBookingContext();
        }

        public Booking AddBooking(Booking booking)
        {
            try
            {
                if(booking.Id == 0)
                {
                   
                    _dbContext.bookings.Add(booking);
                    _dbContext.SaveChanges();
                   
                    return booking;
                }
                else
                {
                    _dbContext.Entry(booking).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return booking;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Dealer AddDealer(Dealer dealer)
        {
            try
            {
                if (dealer != null)
                {
                    if (dealer.Id == 0)
                    {
                        _dbContext.dealers.Add(dealer);
                        _dbContext.SaveChanges();

                        var user = _dbContext.dealers.Where(x => x.Email == dealer.Email).FirstOrDefault();
                        user.DealerNo = "D" + user.Id;
                        _dbContext.Entry(user).State = EntityState.Modified;

                        _dbContext.SaveChanges();
                        MyLogger.GetInstance().Info(dealer.Name + " added successfully");
                        return user;
                    }
                    else
                    {
                        _dbContext.Entry(dealer).State = EntityState.Modified;

                        _dbContext.SaveChanges();
                        MyLogger.GetInstance().Info(dealer.Name + " updated successfully");
                        return dealer;
                    }

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MyLogger.GetInstance().Info(ex.Message);
                return null;
            }

        }

        public ForgotPasswordToken AddForgotPasswordToken(ForgotPasswordToken tokenObject)
        {
            try
            {
                if (tokenObject != null)
                {
                    _dbContext.forgotPasswordTokens.Add(tokenObject);
                    _dbContext.SaveChanges();

                    return tokenObject;
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
            
            
        }

        public Mechanic AddMechanic(Mechanic mechanic)
        {
            try
            {
                if (mechanic != null)
                {
                    if (mechanic.Id == 0)
                    {
                        _dbContext.mechanics.Add(mechanic);
                        _dbContext.SaveChanges();

                        var user = _dbContext.mechanics.Where(x => x.Email == mechanic.Email).FirstOrDefault();
                        user.MechanicNo = "M" + user.Id;
                        _dbContext.Entry(user).State = EntityState.Modified;

                        _dbContext.SaveChanges();
                        MyLogger.GetInstance().Info(mechanic.Name + " added successfully");
                        return user;
                    }
                    else
                    {
                        _dbContext.Entry(mechanic).State = EntityState.Modified;

                        _dbContext.SaveChanges();
                        MyLogger.GetInstance().Info(mechanic.Name + " updated successfully");
                        return mechanic;
                    }

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MyLogger.GetInstance().Info(ex.Message);
                return null;
            }
        }

        public Service AddService(Service service)
        {
            try
            {
                if (service != null)
                {
                    if (service.Id == 0)
                    {
                        _dbContext.services.Add(service);
                        _dbContext.SaveChanges();
                        MyLogger.GetInstance().Info(service.Name + " added successfully");


                        return service;
                    }
                    else
                    {
                        _dbContext.Entry(service).State = EntityState.Modified;

                        _dbContext.SaveChanges();
                        MyLogger.GetInstance().Info(service.Name + " updated successfully");
                        return service;
                    }

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MyLogger.GetInstance().Info(ex.Message);
                return null;
            }
        }

        public Customer AddUser(Customer customer)
        {
            
            try
            {
                if(customer!=null)
                {
                    if(customer.Id == 0)
                    {
                        _dbContext.customers.Add(customer);
                        _dbContext.SaveChanges();

                        var user = _dbContext.customers.Where(x => x.Email == customer.Email).FirstOrDefault();
                        user.CustomerNo = "U" + user.Id;
                        _dbContext.Entry(user).State = EntityState.Modified;

                        _dbContext.SaveChanges();
                        MyLogger.GetInstance().Info(customer.Name + " added successfully");
                        return user;
                    }
                    else
                    {
                        _dbContext.Entry(customer).State = EntityState.Modified;

                        _dbContext.SaveChanges();
                        MyLogger.GetInstance().Info(customer.Name + " updated successfully");
                        return customer;
                    }
                   
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                MyLogger.GetInstance().Info(ex.Message);
                return null;
            }
            
        }

        public Vehicle AddVehicle(Vehicle vehicle)
        {
            try
            {
                if (vehicle != null)
                {
                    if (vehicle.Id == 0)
                    {
                        _dbContext.vehicles.Add(vehicle);
                        _dbContext.SaveChanges();

                        MyLogger.GetInstance().Info(vehicle.LicensePlate + " added successfully");

                        return vehicle;
                    }
                    else
                    {
                        _dbContext.Entry(vehicle).State = EntityState.Modified;

                        _dbContext.SaveChanges();
                        MyLogger.GetInstance().Info(vehicle.LicensePlate + " updated successfully");
                        return vehicle;
                    }

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MyLogger.GetInstance().Info(ex.Message);
                return null;
            }
        }

        public Dealer AuthenticateDealer(string email, string password)
        {
            Dealer invalidCustomer = null;
            Dealer user = _dbContext.dealers.Where(x => x.Email == email).FirstOrDefault();
            if (user != null)
            {
                if (user.Password == password)
                {
                    return user;
                }
                return invalidCustomer;
            }
            return invalidCustomer;
        }

        public Customer AuthenticateUser(string email, string password)
        {
            Customer invalidCustomer=null;
            Customer user = _dbContext.customers.Where(x => x.Email == email).FirstOrDefault();
            if (user != null)
            {
                if(user.Password == password)
                {
                    return user;
                }
                return invalidCustomer;
            }
            return invalidCustomer;
        }

        public Booking DeleteBooking(int id)
        {
            var booking = _dbContext.bookings.Find(id);
            if (booking != null)
            {
                _dbContext.bookings.Remove(booking);
                _dbContext.SaveChanges();

                return booking;
            }
            return null;
        }

        public Customer DeleteCustomer(int id)
        {
            var user = _dbContext.customers.Find(id);
            if(user != null)
            {
                _dbContext.customers.Remove(user);
                _dbContext.SaveChanges();
                MyLogger.GetInstance().Info(user.Name + " deleted successfully");
                return user;
            }
            return null;
           

        }

        public Mechanic DeleteMechanic(int id)
        {
            var mechanic = _dbContext.mechanics.Find(id);
            if (mechanic != null)
            {
                _dbContext.mechanics.Remove(mechanic);
                _dbContext.SaveChanges();
                MyLogger.GetInstance().Info(mechanic.Name + " deleted successfully");
                return mechanic;
            }
            return null;
        }

        public Service DeleteService(int id)
        {
            var service = _dbContext.services.Find(id);
            if (service != null)
            {
                _dbContext.services.Remove(service);
                _dbContext.SaveChanges();
                MyLogger.GetInstance().Info(service.Name + " deleted successfully");
                return service;
            }
            return null;
        }

        public ForgotPasswordToken DeleteToken(ForgotPasswordToken userTokenObject)
        {
            _dbContext.forgotPasswordTokens.Remove(userTokenObject);
            return userTokenObject;
        }

        public Vehicle DeleteVehicle(int id)
        {
            var vehicle = _dbContext.vehicles.Find(id);
            if (vehicle != null)
            {
                _dbContext.vehicles.Remove(vehicle);
                _dbContext.SaveChanges();
                MyLogger.GetInstance().Info(vehicle.LicensePlate + " deleted successfully");
                return vehicle;
            }
            return null;
        }

        public Booking GetBooking(int id)
        {
            var booking = _dbContext.bookings.Where(b => b.Id == id).FirstOrDefault();
            return booking;
        }

        public List<Booking> GetBookings()
        {
            var bookingList = _dbContext.bookings.ToList();
            return bookingList;
        }

        public List<Booking> GetBookingsByCustomerId(int id)
        {
            var bookingList = _dbContext.bookings.Where(b => b.CustomerId == id).ToList();
            return bookingList;
        }

        public List<Customer> GetCustomers()
        {

            var customerList = _dbContext.customers.ToList();
            List<Customer> sortedList = customerList.OrderBy(o => o.Name).ToList();
            return sortedList;
        }

        public Dealer GetDealer(int id)
        {
            if (id != 0)
            {
                var dealer = _dbContext.dealers.Find(id);
                return dealer;
            }
            return null;
        }

        public ForgotPasswordToken GetForgotPasswordTokenObject(string token)
        {
            if(token!=null)
            {
                var tokenObject = _dbContext.forgotPasswordTokens.Where(x => x.Token == token).FirstOrDefault();
                if(tokenObject != null)
                {
                    return tokenObject;
                }

            }
            return null;
        }

        public Mechanic GetMechanic(int? id)
        {
            if(id!=0)
            {
                var mechanic = _dbContext.mechanics.Find(id);
                return mechanic;
            }
            return null;
            
        }

        public Mechanic GetMechanicByMake(string vehicleMake)
        {
            var mechanic = _dbContext.mechanics.Where(m => m.Make == vehicleMake).FirstOrDefault();
            if(mechanic!=null)
            {
                return mechanic;
            }
            return null;
        }

        public List<Mechanic> GetMechanics()
        {
            var mechanicList = _dbContext.mechanics.ToList();
            return mechanicList;
        }

        public string GetName()
        {
            return "Rikin";
        }

        public Service GetService(int id)
        {
            var service = _dbContext.services.Find(id);
            return service;
        }

        public List<Service> GetServices()
        {
            var serviceList = _dbContext.services.Where(s => s.Active).ToList();
            return serviceList;
        }

        public Customer GetUser(int id)
        {
            var user = _dbContext.customers.Where(x => x.Id == id).FirstOrDefault();
            return user;
        }

        public Customer GetUserByEmail(string email)
        {
            var customer = _dbContext.customers.Where(x => x.Email == email).FirstOrDefault();

            return customer;
        }

        public Vehicle GetVehicle(int id)
        {
            var vehicle = _dbContext.vehicles.Where(x => x.Id == id).FirstOrDefault();
            return vehicle;
        }

        public List<Vehicle> GetVehicles()
        {
            var vehicleList = _dbContext.vehicles.ToList();
            List<Vehicle> sortedList = vehicleList.OrderBy(o => o.LicensePlate).ToList();
            return sortedList;
        }

        public List<Vehicle> GetVehiclesByOwnerId(int id)
        {
            var vehicels = _dbContext.vehicles.Where(v => v.OwnerId == id).ToList();
            return vehicels;
        }
    }
}
