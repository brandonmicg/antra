using Assignment3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.DataModels
{
    public class Person : IPersonService
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime DOB { get; protected set; }
        public string Address { get { return Addresses[0]; } protected set { Addresses.Add(value); } }
        protected List<string> Addresses;
        protected decimal salary;

        public Person(string fname, string lname, DateTime dateOfBirth, string address, decimal salary)
        {
            FirstName = fname;
            LastName = lname;
            DOB = dateOfBirth;
            Address = address;
            this.salary = salary;
        }

        public int CalculateAge()
        {
            DateTime age = DateTime.Now;
            age.Subtract(DOB);
            return age.Year;
        }

        public decimal CalculateSalary()
        {
            return salary;
        }

        public List<string> GetAddress()
        {
            return Addresses;
        }
    }
}
