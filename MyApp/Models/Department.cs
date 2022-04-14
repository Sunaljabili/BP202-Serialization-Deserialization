using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Models
{
   public class Department
    {
        private static int _Id;
        public int Id { get; set; }
        public Department()
        {
            _Id++;
            Id = _Id;
        }
        public string Name { get; set; }
        public List<Employee> employees = new List<Employee>();
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }
        public Employee GetEmployeeById(int id)
        {
            return employees.Find(e => e.Id == id);
        }

        public void RemoveEmployeeId(int id)
        {
             employees.Remove(employees.Find(e => e.Id == id));
        }




    }
}
