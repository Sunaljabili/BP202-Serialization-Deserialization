using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Models
{
    public class Employee
    {
        private static int _Id;
        public int Id { get; set; }
        public Employee()
        {
            _Id++;
            Id = _Id;
        }
        public string Name { get; set; }
        public double Salary { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Id-{Id}, Name - {Name},salary - {Salary}");
        }

    }
}
