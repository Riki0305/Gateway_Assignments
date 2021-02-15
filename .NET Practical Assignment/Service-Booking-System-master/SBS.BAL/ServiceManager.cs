using SBS.BAL.Interfaces;
using SBS.DAL.Interfaces;
using SBS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL
{
    public class ServiceManager:IServiceManager
    {
        private IServiceRepository _serviceRepository;

        public ServiceManager(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public Booking AddBooking(Booking booking)
        {
            return _serviceRepository.AddBooking(booking);
        }

        public Dealer AddDealer(Dealer dealer)
        {
            return _serviceRepository.AddDealer(dealer);
        }

        public ForgotPasswordToken AddForgotPasswordToken(ForgotPasswordToken tokenObject)
        {
            return _serviceRepository.AddForgotPasswordToken(tokenObject);
        }

        public Mechanic AddMechanic(Mechanic mechanic)
        {
            return _serviceRepository.AddMechanic(mechanic);
        }

        public Service AddService(Service service)
        {
            return _serviceRepository.AddService(service);
        }

        public Customer AddUser(Customer customer)
        {
            return _serviceRepository.AddUser(customer);
        }

        public Vehicle AddVehicle(Vehicle vehicle)
        {
            return _serviceRepository.AddVehicle(vehicle);
        }

        public Dealer AuthenticateDealer(string email, string password)
        {
            return _serviceRepository.AuthenticateDealer(email, password);
        }

        public Customer AuthenticateUser(string email, string password)
        {
            return _serviceRepository.AuthenticateUser(email, password);
        }

        public Booking DeleteBooking(int id)
        {
            return _serviceRepository.DeleteBooking(id);
        }

        public Customer DeleteCustomer(int id)
        {
            return _serviceRepository.DeleteCustomer(id);
        }

        public Mechanic DeleteMechanic(int id)
        {
            return _serviceRepository.DeleteMechanic(id);
        }

        public Service DeleteService(int id)
        {
            return _serviceRepository.DeleteService(id);
        }

        public ForgotPasswordToken DeleteToken(ForgotPasswordToken userTokenObject)
        {
            return _serviceRepository.DeleteToken(userTokenObject);
        }

        public Vehicle DeleteVehicle(int id)
        {
            return _serviceRepository.DeleteVehicle(id);
        }

        public Booking GetBooking(int id)
        {
            return _serviceRepository.GetBooking(id);
        }

        public List<Booking> GetBookings()
        {
            return _serviceRepository.GetBookings();
        }

        public List<Booking> GetBookingsByCustomerId(int id)
        {
            return _serviceRepository.GetBookingsByCustomerId(id);
        }

        public List<Customer> GetCustomers()
        {
            return _serviceRepository.GetCustomers();
        }

        public Dealer GetDealer(int id)
        {
            return _serviceRepository.GetDealer(id);
        }

        public ForgotPasswordToken GetForgotPasswordTokenObject(string token)
        {
            return _serviceRepository.GetForgotPasswordTokenObject(token);
        }

        public Mechanic GetMechanic(int? id)
        {
            return _serviceRepository.GetMechanic(id);
        }

        public Mechanic GetMechanicByMake(string vehicleMake)
        {
            return _serviceRepository.GetMechanicByMake(vehicleMake);
        }

        public List<Mechanic> GetMechanics()
        {
            return _serviceRepository.GetMechanics();
        }

        public string GetName()
        {
            return _serviceRepository.GetName();
        }

        public Service GetService(int id)
        {
            return _serviceRepository.GetService(id);
        }

        public List<Service> GetServices()
        {
            return _serviceRepository.GetServices();
        }

        public Customer GetUser(int id)
        {
            return _serviceRepository.GetUser(id);
        }

        public Customer GetUserByEmail(string email)
        {
            return _serviceRepository.GetUserByEmail(email);
        }

        public Vehicle GetVehicle(int id)
        {
            return _serviceRepository.GetVehicle(id);
        }

        public List<Vehicle> GetVehicles()
        {
            return _serviceRepository.GetVehicles();
        }

        public List<Vehicle> GetVehiclesByOwnerId(int id)
        {
            return _serviceRepository.GetVehiclesByOwnerId(id);
        }
    }
}
