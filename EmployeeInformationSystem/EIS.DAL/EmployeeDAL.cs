using System;
using System.Collections.Generic;
using EIS.Entitites;
using EIS.Exceptions;


namespace EIS.DAL
{
    public class EmployeeDAL
    {
        // creating l ist collection to store 
        private static List<Employee> empList = new List<Employee>();

        //Adding Employee
        public bool AddEmployeeDAL(Employee employee)
        {
            bool status = false;
            try
            {
                empList.Add(employee);
                status = true;
            }
            catch (EmployeeException ex)
            {

                throw ex;
            }
            return status;
        }

        public Employee GetEmployeeDAL(int id)
        {
            Employee emp = null;
            try
            {
                foreach (Employee  e in empList)
                {
                    if(e.ID==id)
                    {
                        emp = e;
                        break;
                    }
                }
            }
            catch (EmployeeException ex)
            {

                throw ex;
            }
            return emp;
        }

        // Diplay
        public List<Employee> GetEmployeesDAL()
        {
            if(empList.Count !=0)
            {
                return empList;
            }
            else
            {
                throw new EmployeeException("List is empty");
            }
        }
        

        public List<Employee> GetEmployeeByCityDAL(string city)
        {
            List<Employee> cityemplist = new List<Employee>();
            try
            {
                foreach (Employee e in empList)
                {
                    if(e.City==city)
                    {
                        cityemplist.Add(e);
                    }
                   

                }
            }
            catch (EmployeeException ex)
            {

                throw ex;
            }
            return cityemplist;
        }

    }
}
