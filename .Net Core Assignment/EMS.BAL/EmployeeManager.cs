using EMS.BAL.Interface;
using EMS.DAL.Interface;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.BAL
{
    public class EmployeeManager : IEmployeeManager
    {
        IEmployeeRepository _employee;

        public EmployeeManager(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        //<summary>
        //    deletes that employee.
        //</summary>
        public void DeleteEmployee(int id)
        {
            _employee.DeleteEmployee(id);
        }

        //<summary>
        //    returns data of that employee.    
        //</summary>
        public EmployeesModel GetEmployee(int id)
        {
            return _employee.GetEmployee(id);
        }

        //<summary>
        //    returns list of all employess.
        //</summary>
        public List<EmployeesModel> GetEmployees()
        {
            return _employee.GetEmployees();
        }

        //<summary>
        //    inserts employee's data.
        //</summary>
        public void PostEmployee(EmployeesModel model)
        {
            _employee.PostEmployee(model);
        }

        //<summary>
        //    updates data of that employee.
        //</summary>
        public void PutEmployee(int id, EmployeesModel model)
        {
            _employee.PutEmployee(id, model);
        }

        //<summary>
        //    returns list of managers.
        //</summary>
        public List<EmployeesModel> GetManagers()
        {
            return _employee.GetManagers();
        }
    }
}
