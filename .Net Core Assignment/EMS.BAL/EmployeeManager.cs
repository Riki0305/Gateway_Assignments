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
        //    deletes an employee.
        //</summary>
        public void DeleteEmployee(int id)
        {
            _employee.DeleteEmployee(id);
        }

        //<summary>
        //    returns an employee.    
        //</summary>
        public EmployeesModel GetEmployee(int id)
        {
            return _employee.GetEmployee(id);
        }

        //<summary>
        //    returns list of all employees.
        //</summary>
        public List<EmployeesModel> GetEmployees()
        {
            return _employee.GetEmployees();
        }

        //<summary>
        //    inserts an employee.
        //</summary>
        public void PostEmployee(EmployeesModel model)
        {
            _employee.PostEmployee(model);
        }

        //<summary>
        //    updates an eployee.
        //</summary>
        public void PutEmployee(int id, EmployeesModel model)
        {
            _employee.PutEmployee(id, model);
        }

        //<summary>
        //    returns managers.
        //</summary>
        public List<EmployeesModel> GetManagers()
        {
            return _employee.GetManagers();
        }
    }
}
