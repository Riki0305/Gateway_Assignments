using EMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.DAL.Interface
{
    public interface IAccountRepository
    {
        string Login(LoginModel model);
    }
}
