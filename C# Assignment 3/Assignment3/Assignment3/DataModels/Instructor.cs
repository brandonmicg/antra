using Assignment3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.DataModels
{
    public class Instructor : Person, IInstructorService
    {
        public Department Department { get; private set; }
        public DateTime JoinDate { get; private set; }

        public Instructor(string fname, string lname, DateTime dateOfBirth, string address, decimal salary, DateTime joinDate) 
            : base(fname, lname, dateOfBirth, address, salary)
        {
            JoinDate = joinDate;
        }

        public decimal CalculateInstructorSalary()
        {
            DateTime employmentLength = DateTime.Now;
            employmentLength.Subtract(JoinDate);
            return CalculateSalary() + employmentLength.Year * 1000;
        }
    }
}
