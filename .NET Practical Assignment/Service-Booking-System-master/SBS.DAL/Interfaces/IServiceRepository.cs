using SBS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Interfaces
{
    public interface IServiceRepository
    {
        string GetName();
        List<Customer> GetCustomers();
        Customer AddUser(Customer customer);
        Customer AuthenticateUser(string email, string password);
        Dealer AuthenticateDealer(string email, string password);
        Customer GetUser(int id);
        Vehicle AddVehicle(Vehicle vehicle);
        Vehicle GetVehicle(int id);
        List<Vehicle> GetVehicles();
        List<Vehicle> GetVehiclesByOwnerId(int id);
        Booking AddBooking(Booking booking);
        Dealer AddDealer(Dealer dealer);
        Mechanic AddMechanic(Mechanic mechanic);
        ForgotPasswordToken AddForgotPasswordToken(ForgotPasswordToken tokenObject);
        Service AddService(Service service);
        Customer DeleteCustomer(int id);
        Vehicle DeleteVehicle(int id);
        List<Booking> GetBookingsByCustomerId(int id);
        List<Service> GetServices();
        Booking GetBooking(int id);
        Mechanic GetMechanicByMake(string vehicleMake);
        Mechanic GetMechanic(int? id);
        Service GetService(int id);
        
        Booking DeleteBooking(int id);
        Dealer GetDealer(int id);
        Service DeleteService(int id);
        Mechanic DeleteMechanic(int id);
        List<Mechanic> GetMechanics();
        Customer GetUserByEmail(string email);
        ForgotPasswordToken GetForgotPasswordTokenObject(string token);
        ForgotPasswordToken DeleteToken(ForgotPasswordToken userTokenObject);
        List<Booking> GetBookings();
    }
}
