using System;
using System.Collections.Generic;
using EIS.BLL;
using EIS.Entitites;
using EIS.Exceptions;

namespace EIS.PL
{
    class Program
    {
        static void PrintMenu()
        {
            Console.WriteLine("========================================================================");
            Console.WriteLine("Emptloyee Information System:");
            Console.WriteLine("========================================================================");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Get All Employees");
            Console.WriteLine("3. Get Employee By City");
            Console.WriteLine("4. Get Employee By Id");
            Console.WriteLine("5. Quit");

        }

        static void AddEmployee()
        {
            try
            {
                Employee employee = new Employee();

                Console.WriteLine("Enter ID: ");
                employee.ID= Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Name: ");
                employee.Name = Console.ReadLine();

                Console.WriteLine("Enter Contact: ");
                employee.Contact = Convert.ToInt64(Console.ReadLine());

                Console.WriteLine("Enter city: ");
                employee.City = Console.ReadLine();

                Console.WriteLine("Enter Department");
                employee.Department = Console.ReadLine();

                EmployeeBLL empBLL = new EmployeeBLL();

                if(empBLL.AddEmployeeBLL(employee))
                {
                    Console.WriteLine("Employee Added Successfully");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); 
            }
        }

        static void GetEmployees()
        {
            try
            {
                EmployeeBLL employeeBLL = new EmployeeBLL();
                List<Employee> empList=employeeBLL.GetEmployeesBLL();

                if(empList.Count==0)
                {
                    Console.WriteLine("No Data to be Displayed");
                }
                else
                {
                    foreach (Employee e in empList)
                    {
                        Console.WriteLine("ID={0},Name={1},Contact={2},City={3},Department={4}",
                            e.ID,e.Name,e.Contact,e.City,e.Department);

                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }

        static  void GetEmployeeByCity()
        {
            try
            {
                Console.WriteLine("Enter City");
                string city = Console.ReadLine();

                EmployeeBLL employeeBLL = new EmployeeBLL();
                List<Employee> empList=new List<Employee>();
                   empList= employeeBLL.GetEmployeesByCityBLL(city);

                if(empList.Count==0)
                {
                    Console.WriteLine("No Data to be Displayed");
                }
                else
                {
                    foreach (Employee e in empList)
                    {
                        Console.WriteLine("ID={0},Name={1},Contact={2},City={3},Department={4}",
                            e.ID, e.Name, e.Contact, e.City, e.Department);

                    }
                }
            }
            catch (EmployeeException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        static void GetEmployeeById()
        {
            try
            {
                Console.WriteLine("Enter id ");
                int id = Convert.ToInt32(Console.ReadLine());

                EmployeeBLL empBLL = new EmployeeBLL();
                Employee emp= empBLL.GetEmployee(id);
                    
                if(emp != null)
                {
                    Console.WriteLine("Employee Found");
                    Console.WriteLine("ID={0}, Name={1},Contact={2},City={3},Department={4}",
                        emp.ID,emp.Name,emp.City,emp.Contact,emp.Department);
                }
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            while(true)
            {
                PrintMenu();

                Console.WriteLine("Enter your Choice");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        AddEmployee();
                        break;

                    case 2:
                        GetEmployees();
                        break;

                    case 3:
                        GetEmployeeByCity();
                        break;

                    case 4:
                        GetEmployeeById();
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Entry, Try again!");
                        break;
                }
            }

        }
    }
}
