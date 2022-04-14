using MyApp.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Directory.CreateDirectory(@"C:\Users\User\Desktop\Files");
            if (!File.Exists(@"C:\Users\User\Desktop\Files\database.json"))
            {
                File.Create(@"C:\Users\User\Desktop\Files\database.json");
            }

            Department department = new Department
            {
                Id = 1,
                Name = "Test-Department"
            };

            bool check = true;
            do
            {
                Console.WriteLine("===MENU===");
                Console.WriteLine("1. Add employee");
                Console.WriteLine("2. Get employee by id");
                Console.WriteLine("3. Remove employee id");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        //Console.WriteLine("Enter Id:");
                        //int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Salary:");
                        int salary = Convert.ToInt32(Console.ReadLine());
                        Employee employee = new Employee
                        {
                            //Id = id,
                            Name = name,
                            Salary = salary
                        };

                        department.AddEmployee(employee);

                        string DepartmentObj = JsonConvert.SerializeObject(department);

                        using(StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\Files\database.json"))
                        {
                            sw.Write(DepartmentObj);
                        }

                        break;
                    case "2":
                        Console.WriteLine("Id daxil edin:");
                        int idEmp = Convert.ToInt32(Console.ReadLine());

                        string result = String.Empty;
                        using(StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\Files\database.json"))
                        {
                            result = sr.ReadToEnd();
                        }

                        Department departmentDes = JsonConvert.DeserializeObject<Department>(result);

                        departmentDes.GetEmployeeById(idEmp).ShowInfo();

                        break;
                    case "3":
                        Console.WriteLine("Id daxil edin :");
                        int removeId = Convert.ToInt32(Console.ReadLine());
                     
                        string resultRem = String.Empty;
                        using (StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\Files\database.json"))
                        {
                            resultRem = sr.ReadToEnd();
                        }
                        Department department4 = JsonConvert.DeserializeObject<Department>(resultRem);

                        department4.RemoveEmployeeId(removeId);

                        string DepartmentObjSer = JsonConvert.SerializeObject(department4);
                        using (StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\Files\database.json"))
                        {
                            sw.Write(DepartmentObjSer);
                        }
                     

                        break;
                    case "0":
                        check = false;
                        break;
                    default:
                        Console.WriteLine("End of process");
                        break;
                }

            } while (check);

        }
    }
}
