using Assignment3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.DataModels
{
    public class Department : IDepartmentService
    {
        public string Name { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; private set; }
        public Instructor HeadOfDepartment { get; private set; }

        public Department(string name, DateTime startDate, DateTime endDate, decimal budget, Instructor headOfDepartment)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Budget = budget;
            HeadOfDepartment = headOfDepartment;
        }
    }
}
