using Assignment3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.DataModels
{
    public class Course : ICourseService
    {
        public static Dictionary<char, float> gradeValues = new Dictionary<char, float>()
        {
            {'A', 4f}, {'B', 3f}, {'C', 2f}, {'D', 1f}, {'F', 0}
        };

        public string Name { get; private set; }
        private List<Student> Students = new List<Student>();

        public Course(string name)
        {
            Name = name;
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
    }
}
