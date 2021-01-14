using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAssignment.Model;

namespace WebApiAssignment.BAL.Interface
{
    public interface IHotelManager
    {
        List<Model.Hotel> GetAllHotel();
        List<Room> GetAllRooms(string sortBy);
        string CreateHotel(Hotel hotel);
        string BookRoom(int RoomId, DateTime date,string status);
        string UpdateBookingDate(int id, DateTime date);
        string UpdateBookingStatus(int id, string status);
        string DeleteBooking(int id);
        bool GetAvailability(int RoomId,DateTime date);
        bool Login(string username, string password);
    }
}
