using OfficeOpenXml;
using OfficeOpenXml.Style;
using SBS.BAL.Interfaces;
using SBS.Model;
using Service_Booking_System.Utility;
using Service_Booking_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service_Booking_System.Controllers
{
    public class BookingController : Controller
    {
        private IServiceManager _serviceManager;
    

        public BookingController(IServiceManager serviceManager)
        {
            
            _serviceManager = serviceManager;
           
        }
        
    // GET: Booking
    public ActionResult Index()
        {
            if(Session["user"]!=null && Session["role"].ToString() == "2")
            {
                var customer = (Customer)Session["user"];
                var bookingList = _serviceManager.GetBookingsByCustomerId(customer.Id);
                return View(bookingList);
            }
            if (Session["user"] != null && Session["role"].ToString() == "1")
            {
                
                var bookingList = _serviceManager.GetBookings();
                return View(bookingList);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddorEdit(int id=0)
        {
            if(Session["role"].ToString() == "1")
            {
                return RedirectToAction("Index", "Home");
            }
            if (Session["user"] != null )
            {
                var customer = (Customer)Session["user"];
                if (id==0)
                {
                    var services = _serviceManager.GetServices();
                    var vehicles = _serviceManager.GetVehiclesByOwnerId(customer.Id);
                    var bookingViewModel = new BookingViewModel
                    {
                        booking = new Booking() { BookingStart=DateTime.Now,BookingEnd=DateTime.Now},
                        services = services,
                        vehicles = vehicles
                    };

                    return View(bookingViewModel);
                }
                else
                {
                    var services = _serviceManager.GetServices();
                    var vehicles = _serviceManager.GetVehiclesByOwnerId(customer.Id);
                    var booking = _serviceManager.GetBooking(id);
                    var bookingViewModel = new BookingViewModel
                    {
                        booking = booking,
                        services = services,
                        vehicles = vehicles
                    };
                    return View(bookingViewModel);
                }
                
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AddorEdit(Booking booking)
        {
            if(ModelState.IsValid && Session["user"]!=null)
            {
                var customer = (Customer)Session["user"];
                booking.CustomerId = customer.Id;
                
                if(booking.Id != 0)
                {
                    booking.UpdatedBy = customer.Name;
                    booking.UpdatedOn = DateTime.Now;
                }
                else
                {
                    booking.CreatedBy = customer.Name;
                    booking.CreatedOn = DateTime.Now;
                    booking.UpdatedBy = customer.Name;
                    booking.UpdatedOn = DateTime.Now;
                }
               

                var vehicle = _serviceManager.GetVehicle(booking.VehicleId);
                var vehicleMake = vehicle.Make;
                var mechanic = _serviceManager.GetMechanicByMake(vehicleMake);
                if(mechanic != null)
                {
                    booking.MechanicId = mechanic.Id;
                }
                var result = _serviceManager.AddBooking(booking);
                TempData["SuccessMessage"] = "Booking added successfully";
                MyLogger.GetInstance().Info("Booking added successfully");
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = " Booking does not added";
            MyLogger.GetInstance().Info("Booking does not added");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DownloadExcel()
        {
            if (Session["user"] != null)
            {
                var customer = (Customer)Session["user"];
                var bookingList = _serviceManager.GetBookingsByCustomerId(customer.Id);
               
                ExcelPackage Ep = new ExcelPackage();
                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
                Sheet.Cells["A1"].Value = "Id";
                Sheet.Cells["B1"].Value = "Service";
                Sheet.Cells["C1"].Value = "Mechanic";
                Sheet.Cells["D1"].Value = "Vehicle Number";
                Sheet.Cells["E1"].Value = "Booking Start Date";
                Sheet.Cells["F1"].Value = "Booking End Date";
                Sheet.Cells["G1"].Value = "Created By";
                Sheet.Cells["H1"].Value = "Created On";
                Sheet.Cells["I1"].Value = "Updated By";
                Sheet.Cells["J1"].Value = "Updated On";
                int row = 2;
                foreach (var item in bookingList)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Id;
                    var service = _serviceManager.GetService(item.ServiceId);
                    Sheet.Cells[string.Format("B{0}", row)].Value = service.Name;
                    var mechanic = _serviceManager.GetMechanic(item.MechanicId);
                    if(mechanic != null)
                    {
                        Sheet.Cells[string.Format("C{0}", row)].Value = mechanic.Name;
                    }
                    var vehicle = _serviceManager.GetVehicle(item.VehicleId);
                    Sheet.Cells[string.Format("D{0}", row)].Value = vehicle.LicensePlate;
                    Sheet.Cells[string.Format("E{0}", row)].Value = item.BookingStart;
                    Sheet.Cells[string.Format("F{0}", row)].Value = item.BookingEnd;
                    Sheet.Cells[string.Format("G{0}", row)].Value = item.CreatedBy;
                    Sheet.Cells[string.Format("H{0}", row)].Value = item.CreatedOn;
                    Sheet.Cells[string.Format("I{0}", row)].Value = item.UpdatedBy;
                    Sheet.Cells[string.Format("J{0}", row)].Value = item.UpdatedOn;
                    row++;
                }
                using (ExcelRange col = Sheet.Cells[2, 5, 2 + bookingList.Count, 5])
                {
                    col.Style.Numberformat.Format = "dd/MM/yyyy";
                    col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                using (ExcelRange col = Sheet.Cells[2, 6, 2 + bookingList.Count, 6])
                {
                    col.Style.Numberformat.Format = "dd/MM/yyyy";
                    col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                using (ExcelRange col = Sheet.Cells[2, 8, 2 + bookingList.Count, 8])
                {
                    col.Style.Numberformat.Format = "dd/MM/yyyy";
                    col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                using (ExcelRange col = Sheet.Cells[2, 10, 2 + bookingList.Count, 10])
                {
                    col.Style.Numberformat.Format = "dd/MM/yyyy";
                    col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                Sheet.Cells["A:AZ"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader(
                    "content-disposition",
                    string.Format("attachment;  filename={0}", "Report.xlsx"));
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();

            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var result = _serviceManager.DeleteBooking(id);
            if (result != null)
            {
                TempData["SuccessMessage"] ="Booking deleted successfully";
                MyLogger.GetInstance().Info("Booking deleted successfully");
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "Deletion is unsuccessfull";
            MyLogger.GetInstance().Info("Deletion is unsuccessfull");
            return RedirectToAction("Index");
        }
    }
}