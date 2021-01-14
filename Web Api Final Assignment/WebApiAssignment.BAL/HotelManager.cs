using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAssignment.BAL.Interface;
using WebApiAssignment.DAL.Interface;
using WebApiAssignment.Model;

namespace WebApiAssignment.BAL
{
    public class HotelManager : IHotelManager
    {
        private IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public string BookRoom(int RoomId, DateTime date, string status)
        {
           return _hotelRepository.BookRoom(RoomId, date, status);
        }

        public string CreateHotel(Hotel hotel)
        {
            return _hotelRepository.CreateHotel(hotel);
        }

        public string DeleteBooking(int id)
        {
            return _hotelRepository.DeleteBooking(id);
        }

        public List<Hotel> GetAllHotel()
        {
            var hotel = _hotelRepository.GetAllHotel();
            return hotel;
        }

        public List<Room> GetAllRooms(string sortBy)
        {
            return _hotelRepository.GetAllRooms(sortBy);
        }

        public bool GetAvailability(int RoomId,DateTime date)
        {
            return _hotelRepository.GetAvailability(RoomId,date);
        }

        public bool Login(string username, string password)
        {
            return _hotelRepository.Login(username, password);
        }

        public string UpdateBookingDate(int id, DateTime date)
        {
            return _hotelRepository.UpdateBookingDate(id, date);
        }

        public string UpdateBookingStatus(int id, string status)
        {
            return _hotelRepository.UpdateBookingStatus(id, status);
        }
    }
}
