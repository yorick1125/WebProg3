/*
* Course: 		Web Programming 3
* Assessment: 	Assignment 1
* Created by: 	Yorick-Ntwari Niyonkuru
* Date: 		10 September 2022
* Class Name: 	Employee.cs
* Description: 	Stores all data regarding employees.
    */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment1
{
    public class Employee
    {

        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public Employee()
        {

        }
        public Employee(string name_, uint idNumber_)
        {
            Id = idNumber_;

            // check if the name given is one word or contains a first and last name
            string[] names = name_.Split(" ");
            if(names.Length > 1)
            {
                FirstName = name_.Split(" ")[0];
                LastName = name_.Split(" ")[1];
            }
            else
            {
                FirstName = name_.Split(" ")[0];

            }

        }


        public Employee(uint idNumber_, string firstName_, string lastName_, string department_, string position_, decimal yearlySalary_)
        {
            Id = idNumber_;
            FirstName = firstName_;
            LastName = lastName_;
            Department = department_;
            Position = position_;
            Salary = yearlySalary_;
        }

        public override string ToString()
        {
            return
                "Employee ID: " + Id + " \n" +
                "First Name: " + FirstName + " \n" +
                "Last Name: " + LastName + " \n" +
                "Department: " + Department + " \n" +
                "Position: " + Position + " \n" +
                "Yearly Salary: " + Salary + " \n"; 
        }

        public override bool Equals(object obj)
        {
            Employee emp = (Employee)obj;
            return emp.Id == Id &&
                emp.FirstName == FirstName &&
                emp.LastName == LastName &&
                emp.Department == Department &&
                emp.Position == Position &&
                emp.Salary == Salary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FirstName, LastName, Department, Position, Salary);
        }
    }
}
