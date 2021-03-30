using EMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.BAL.Interface
{
    public interface IAccountManager
    {
        string Login(LoginModel model);
    }
}
