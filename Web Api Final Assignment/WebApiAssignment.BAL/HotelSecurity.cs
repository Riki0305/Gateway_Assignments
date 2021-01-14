using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAssignment.DAL.Database;

namespace WebApiAssignment.BAL
{
    public class HotelSecurity
    {
        public bool Login(string username, string password)
        {
            using(HotelManagementDBEntities _dbContext  = new HotelManagementDBEntities())
            {
                return _dbContext.Users.Any(u => u.username == username && u.password == password);
            }
        }
    }
}
