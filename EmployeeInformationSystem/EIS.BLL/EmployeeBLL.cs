using System;
using EIS.Entitites;
using EIS.Exceptions;
using EIS.DAL;
using System.Text;
using System.Collections.Generic;

namespace EIS.BLL
{
    public class EmployeeBLL
    {
        private EmployeeDAL employeeDal = new EmployeeDAL();

        private static bool ValidateEmp(Employee emp)
        {
            bool status = true;

            StringBuilder stringBuilder = new StringBuilder();

            if(emp.ID<=0)
            {
                status = false;
                stringBuilder.Append("\nID cannot be zero or negative");
            }

            if(emp.Name==string.Empty)
            {
                status = false;
                stringBuilder.Append("\n Name cannot be blank ");

            }
            if(emp.Contact<=0)
            {
                status = false;
                stringBuilder.Append("\n Contact cannot be zero or Negative");
            }
            if(emp.Contact.ToString().Length<10 || emp.Contact.ToString().Length>10)
            {
                status = false;
                stringBuilder.Append("\n Contact must be of 10 digits");
            }
            if(emp.City==string.Empty)
            {
                status = false;
                stringBuilder.Append("\n City cannot be blank");
            }

            if(emp.Department==string.Empty)
            {
                status = false;
                stringBuilder.Append("\n Department cannot be blank");
            }

            if (status == false)
                throw new EmployeeException(stringBuilder.ToString());
            return status;
        }

        public bool AddEmployeeBLL(Employee employee)
        {
            bool status = false;
            try
            {
                if(ValidateEmp(employee))
                {
                    status = employeeDal.AddEmployeeDAL(employee);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;
        }

        public List<Employee> GetEmployeesBLL()
        {
            try
            {
                return employeeDal.GetEmployeesDAL();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Employee> GetEmployeesByCityBLL(string city)
        {
            try
            {
                return employeeDal.GetEmployeeByCityDAL(city);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public Employee GetEmployee(int id)
        {
            try
            { 
                return employeeDal.GetEmployeeDAL(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
