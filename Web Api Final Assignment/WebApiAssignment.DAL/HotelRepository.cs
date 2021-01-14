using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAssignment.DAL.Database;
using WebApiAssignment.DAL.Interface;
using WebApiAssignment.Model;

namespace WebApiAssignment.DAL
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelManagementDBEntities _dbContext;

        public HotelRepository()
        {
            _dbContext = new HotelManagementDBEntities();
        }

        //Post bookroom
        public string BookRoom(int RoomId, DateTime date, string status)
        {
            var checkAvailability = GetAvailability(RoomId, date);
            if(checkAvailability==true)
            {
                Database.Booking booking = new Database.Booking();
                booking.RoomId = RoomId;
                booking.BookingDate = date;
                switch (status)
                {
                    case "definitive":
                        booking.BookingStatusId = 2;
                        break;
                    case "cancelled":
                        booking.BookingStatusId = 3;
                        break;
                    case "deleted":
                        booking.BookingStatusId = 4;
                        break;
                    default:
                        booking.BookingStatusId = 1;
                        break;
                }
                _dbContext.Bookings.Add(booking);
                _dbContext.SaveChanges();

                return "Booked Room Successfully!";
            }
            else
            {
                return "The Room is already booked!";
            }
           
        }

        //Add a hotel
        public string CreateHotel(Model.Hotel hotel)
        {
            try
            {
                if (hotel != null)
                {


                    Database.Hotel hoteldb = new Database.Hotel();

                    //hoteldb.Id = hotel.Id;
                    hoteldb.Name = hotel.Name;
                    hoteldb.Address = hotel.Address;
                    hoteldb.City = hotel.City;
                    hoteldb.Pincode = hotel.Pincode;
                    hoteldb.ContactNumber = hotel.ContactNumber;
                    hoteldb.ContactPerson = hotel.ContactPerson;
                    hoteldb.IsActive = hotel.IsActive;
                    hoteldb.CreatedDate = hotel.CreatedDate;
                    hoteldb.CreatedBy = hotel.CreatedBy;
                    List<Database.Room> hotelrooms = new List<Database.Room>();
                    foreach (var room in hotel.Rooms)
                    {
                        Database.Room hotelroom = new Database.Room();

                        //hotelroom.Id = room.Id;
                        hotelroom.HotelId = room.HotelId;
                        hotelroom.Name = room.Name;
                        hotelroom.Price = room.Price;
                        hotelroom.IsActive = room.IsActive;
                        hotelroom.CreatedBy = room.CreatedBy;
                        hotelroom.CreatedDate = room.CreatedDate;
                        hotelroom.CategoryId = room.CategoryId;
                        //hotelroom.Bookings = new List<Model.Booking>();
                        List<Database.Booking> hotelroombookings = new List<Database.Booking>();
                        foreach (var booking in room.Bookings)
                        {
                            Database.Booking hotelroombooking = new Database.Booking();

                            //hotelroombooking.Id = booking.Id;
                            hotelroombooking.RoomId = booking.RoomId;
                            hotelroombooking.Id = booking.Id;
                            hotelroombooking.BookingDate = booking.BookingDate;
                            hotelroombooking.BookingStatusId = booking.BookingStatusId;

                            hotelroombookings.Add(hotelroombooking);

                        }
                        hotelroom.Bookings = hotelroombookings;
                        hotelrooms.Add(hotelroom);
                    }
                    hoteldb.Rooms = hotelrooms;

                    _dbContext.Hotels.Add(hoteldb);
                    _dbContext.SaveChanges();

                    return "Successfully added!";
                }
                return "Model is not added!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            throw new NotImplementedException();
        }

        //Delete booking by booking id
        public string DeleteBooking(int id)
        {
            var entity = _dbContext.Bookings.Find(id);
            if(entity != null)
            {
                entity.BookingStatusId = 4;
                _dbContext.SaveChanges();
                return "Booking deleted successfully!";
            }
            return "Booking is not deleted!";
        }




        //Get Hotel list
        public List<Model.Hotel> GetAllHotel()
        {
            var entities = _dbContext.Hotels.ToList();
            List<Model.Hotel> list = new List<Model.Hotel>();

            if(entities != null)
            {
                foreach (var item in entities)
                {
                    Model.Hotel hotel = new Model.Hotel();

                    hotel.Id = item.Id;
                    hotel.Name = item.Name;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.Pincode = item.Pincode;
                    hotel.ContactNumber = item.ContactNumber;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.IsActive = item.IsActive;
                    hotel.CreatedDate = item.CreatedDate;
                    hotel.CreatedBy = item.CreatedBy;
                    
                    hotel.Rooms = new List<Model.Room>();
                    foreach(var room in item.Rooms)
                    {
                        Model.Room hotelroom = new Model.Room();
                        hotelroom.Id = room.Id;
                        hotelroom.HotelId = room.HotelId;
                        hotelroom.Name = room.Name;
                        hotelroom.Price = room.Price;
                        hotelroom.IsActive = room.IsActive;
                        hotelroom.CreatedBy = room.CreatedBy;
                        hotelroom.CreatedDate = room.CreatedDate;
                        hotelroom.CategoryId = room.CategoryId;
                        hotelroom.Bookings = new List<Model.Booking>();
                        foreach (var booking in room.Bookings)
                        {
                            Model.Booking hotelroombooking = new Model.Booking();
                            hotelroombooking.Id = booking.Id;
                            hotelroombooking.RoomId = booking.RoomId;
                            hotelroombooking.Id = booking.Id;
                            hotelroombooking.BookingDate = booking.BookingDate;
                            hotelroombooking.BookingStatusId = booking.BookingStatusId;
                            hotelroom.Bookings.Add(hotelroombooking);

                        }
                        hotel.Rooms.Add(hotelroom);
                    }
                    list.Add(hotel);
                }
            }
            List<Model.Hotel> SortedList = list.OrderBy(o => o.Name).ToList();
            return SortedList;
        }

        public List<Model.Room> GetAllRooms(string sortBy)
        {

            var entities = _dbContext.Rooms.ToList();

            List<Model.Room> list = new List<Model.Room>();

            if (entities != null)
            {
                foreach (var room in entities)
                {

                    Model.Room hotelroom = new Model.Room();
                    hotelroom.Id = room.Id;
                    hotelroom.HotelId = room.HotelId;
                    hotelroom.Name = room.Name;
                    hotelroom.Price = room.Price;
                    hotelroom.IsActive = room.IsActive;
                    hotelroom.CreatedBy = room.CreatedBy;
                    hotelroom.CreatedDate = room.CreatedDate;
                    hotelroom.CategoryId = room.CategoryId;
                    hotelroom.Bookings = new List<Model.Booking>();
                    foreach (var booking in room.Bookings)
                    {
                        Model.Booking hotelroombooking = new Model.Booking();
                        hotelroombooking.Id = booking.Id;
                        hotelroombooking.RoomId = booking.RoomId;
                        hotelroombooking.Id = booking.Id;
                        hotelroombooking.BookingDate = booking.BookingDate;
                        hotelroombooking.BookingStatusId = booking.BookingStatusId;
                        hotelroom.Bookings.Add(hotelroombooking);

                    }

                    list.Add(hotelroom);
                }
            }

            //sorting by city/pincode/category/price
            var hotelList = GetAllHotel();
            List<Model.Room> sortedRoomList = new List<Model.Room>();
            switch (sortBy)
            {
                case "city":
                    
                    hotelList = hotelList.OrderBy(o => o.City).ToList();
                    List<Model.Room> sortedBycityList = new List<Model.Room>();
                    foreach (var item in hotelList)
                    {
                        var roomList = list.Where(x => x.HotelId == item.Id).ToList();
                        foreach (var roomitem in roomList)
                        {
                            sortedBycityList.Add(roomitem);
                        }
                    }

                    sortedRoomList= sortedBycityList;
                    break;
                case "pincode":
                   

                    hotelList = hotelList.OrderBy(o => o.Pincode).ToList();
                    List<Model.Room> sortedByPincodeList = new List<Model.Room>();
                    foreach (var item in hotelList)
                    {
                        var roomList = list.Where(x => x.HotelId == item.Id).ToList();
                        foreach (var roomitem in roomList)
                        {
                            sortedByPincodeList.Add(roomitem);
                        }
                    }

                    sortedRoomList= sortedByPincodeList;
                    break;
                case "category":
                    sortedRoomList = list.OrderBy(o => o.CategoryId).ToList();
                    break;
                default:
                    sortedRoomList = list.OrderBy(o => o.Price).ToList();
                    break;

            }
            return sortedRoomList;
            
            
        }

        public bool GetAvailability(int RoomId,DateTime date)
        {
            var entity = _dbContext.Rooms.Find(RoomId);
            int bookedOnDate = 0;
            if (entity != null)
            {
                
                foreach (var item in entity.Bookings)
                {
                    if(item.BookingDate == date && item.BookingStatusId==2)
                    {
                        bookedOnDate = 1;
                    }
                }
                if(bookedOnDate == 1)
                {
                    return false;
                }
            }
            return true;
            
        }

        public bool Login(string username, string password)
        {
            return _dbContext.Users.Any(u => u.username == username && u.password == password);
           
        }

        public string UpdateBookingDate(int id, DateTime date)
        {
            var entity = _dbContext.Bookings.Find(id);
          
            if(entity != null)
            {
                var isdateAvailable = GetAvailability(entity.RoomId, date);
                if(isdateAvailable)
                {
                    entity.BookingDate = date;
                    _dbContext.SaveChanges();
                    return "Booking date updated successfully!";
                }
                return "Room is not available for this date";
            }

            return "Booking date is not updated";
        }

        public string UpdateBookingStatus(int id, string status)
        {
            var entity = _dbContext.Bookings.Find(id);
            if(entity != null)
            {
                switch (status)
                {
                    case "definitive":
                        entity.BookingStatusId = 2;
                        break;
                    case "cancelled":
                        entity.BookingStatusId = 3;
                        break;
                    case "deleted":
                        entity.BookingStatusId = 4;
                        break;
                    default:
                        entity.BookingStatusId = 1;
                        break;
                }
                _dbContext.SaveChanges();
                return "Booking status updated to " + status;
            }
            return "Booking status is not updated";
        }
    }
}
