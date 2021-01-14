using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAssignment.BAL.Interface;
using WebApiAssignment.Model;
using System.Web.Http.Cors;
using WebApiAssignment.BAL;

namespace Web_Api_Final_Assignment.Controllers
{
    [BasicAuthentication]
    [EnableCors(origins:"*",headers: "*",methods: "*")]
    public class HotelController : ApiController
    {
        private IHotelManager _hotelManager;

        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        // GET: api/Hotel
        
        public HttpResponseMessage Get()
        {
            var hotellist = _hotelManager.GetAllHotel();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, hotellist);
            return response;
        }

      
        //GET : api/Hotel/GetRooms
        //Get all rooms
        [Route("api/Hotel/GetRooms")]
        public HttpResponseMessage GetRooms(string sortBy="price")
        {
            
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _hotelManager.GetAllRooms(sortBy.ToLower()));
            return response;
            
        }

        //GET : api/Hotel/GetAvailability
        //check availibility of room
        [HttpGet]
        [Route("api/Hotel/GetAvailability")]
        public HttpResponseMessage GetAvailability(int RoomId,DateTime date)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            
            response.Content = new StringContent(_hotelManager.GetAvailability(RoomId, date).ToString());
            return response;
        }

        // POST: api/Hotel
        //can post single hotel
        public HttpResponseMessage Post([FromBody]Hotel hotel)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            response.Content = new StringContent(_hotelManager.CreateHotel(hotel));
            return response;
        }

        //POST: api/Hotel/PostHotels
        [HttpPost]
        [Route("api/Hotel/PostHotels")]
        public HttpResponseMessage PostHotels([FromBody] List<Hotel> hotels)
        {
            string message,final_message;
            foreach (var item in hotels)
            {
                message = _hotelManager.CreateHotel(item);
                if(message != "Successfully added!")
                {
                    final_message= "Hotels not added";
                }
            }
            final_message= "Successfully added!";
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            response.Content = new StringContent(final_message);
            return response;
        }

        //POST: api/Hotel/BookRoom
        [HttpPost]
        [Route("api/Hotel/BookRoom")]
        public HttpResponseMessage BookRoom(int RoomId, DateTime date,string status="optional")
        {

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            response.Content = new StringContent(_hotelManager.BookRoom(RoomId, date, status));
            return response;
        }


        // PUT: api/Hotel/UpdateBookingDate
        [HttpPut]
        [Route("api/Hotel/UpdateBookingDate")]
        public HttpResponseMessage UpdateBookingDate(int id,DateTime date)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            response.Content = new StringContent(_hotelManager.UpdateBookingDate(id, date));
            return response;
        }

        // PUT: api/Hotel/UpdateBookingStatus
        [HttpPut]
        [Route("api/Hotel/UpdateBookingStatus")]
        public HttpResponseMessage UpdateBookingStatus(int id, string status)
        {
           
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            response.Content = new StringContent(_hotelManager.UpdateBookingStatus(id, status));
            return response;
        }

        

        // DELETE: api/Hotel/5
        [HttpDelete]
        [Route("api/Hotel/DeleteBooking")]
        public HttpResponseMessage DeleteBooking(int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            response.Content = new StringContent(_hotelManager.DeleteBooking(id));
            return response;
        }
    }
}
