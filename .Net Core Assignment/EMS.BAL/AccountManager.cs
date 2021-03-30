using EMS.BAL.Interface;
using EMS.DAL.Interface;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.BAL
{
    public class AccountManager : IAccountManager
    {
        IAccountRepository _account;

        public AccountManager(IAccountRepository account)
        {
            _account = account;
        }

        //<summary>
        //    check wether the credentails are valid or not.
        //    If credentails are valid then returns a JWT Token otherwise not.
        //</summary>
        public string Login(LoginModel model)
        {
            return _account.Login(model);
        }
    }
}
