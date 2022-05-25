using Assignment3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.DataModels
{
    public class Student : Person, IStudentService
    {
        public float GPA { get; private set; }
        private Dictionary<Course, char> courseGrades = new Dictionary<Course, char>();

        public Student(string fname, string lname, DateTime dateOfBirth, string address, decimal salary) : 
            base(fname, lname, dateOfBirth, address, salary)
        {
        }

        public void AddCourse(Course course, char grade)
        {
            if(!courseGrades.ContainsKey(course))
                courseGrades[course] = grade;
        }

        public void RemoveCourse(Course course)
        {
            if (courseGrades.ContainsKey(course))
                courseGrades.Remove(course);
        }

        public void UpdateGrade(Course course, char grade)
        {
            if (courseGrades.ContainsKey(course))
                courseGrades[course] = grade;
        }

        public float CalculateGPA()
        {
            float gpa = 0;
            foreach (var course in courseGrades.Keys)
                gpa += Course.gradeValues[courseGrades[course]];

            return gpa / courseGrades.Count;
        }
    }
}
