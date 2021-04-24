using System;
using System.Collections.Generic;

namespace NUnitAssignment8
{
    public class Program
    {
        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
        }

        public List<User> GetUserInfo()
        {
            return new List<User>
            {
                new User { Name="Sam", Address = "Austrailia", Age=30},
                new User { Name="Bucky", Address = "London", Age=119},
                new User { Name="John", Address = "Yuganda", Age=34},
                new User { Name="Broker", Address = "America", Age=28}
            };
        }
    }
}
