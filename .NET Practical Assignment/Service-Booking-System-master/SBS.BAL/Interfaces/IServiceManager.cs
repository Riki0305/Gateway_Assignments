using SBS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Interfaces
{
    public interface IServiceManager
    {
        string GetName();
        Customer AuthenticateUser(string email, string password);
        Dealer AuthenticateDealer(string email, string password);
        List<Customer> GetCustomers();
        List<Vehicle> GetVehicles();
        List<Service> GetServices();
        Customer AddUser(Model.Customer customer);
        Vehicle AddVehicle(Vehicle vehicle);
        List<Mechanic> GetMechanics();
        Booking AddBooking(Booking booking);
        Dealer GetDealer(int id);
        Customer GetUser(int id);
        Vehicle GetVehicle(int id);
        Booking GetBooking(int id);
        Service GetService(int id);
        Mechanic GetMechanic(int? id);
        Mechanic GetMechanicByMake(string vehicleMake);
        List<Vehicle> GetVehiclesByOwnerId(int id);
        List<Booking> GetBookingsByCustomerId(int id);
        Vehicle DeleteVehicle(int id);
        Dealer AddDealer(Dealer dealer);
        List<Booking> GetBookings();
        Customer DeleteCustomer(int id);
        Booking DeleteBooking(int id);
        Mechanic AddMechanic(Mechanic mechanic);
        Service AddService(Service service);
        Service DeleteService(int id);
        Mechanic DeleteMechanic(int id);
        Customer GetUserByEmail(string email);
        ForgotPasswordToken AddForgotPasswordToken(ForgotPasswordToken tokenObject);
        ForgotPasswordToken GetForgotPasswordTokenObject(string token);
        ForgotPasswordToken DeleteToken(ForgotPasswordToken userTokenObject);
    }
}
