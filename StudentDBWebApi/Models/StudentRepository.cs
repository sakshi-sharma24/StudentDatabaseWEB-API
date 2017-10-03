using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentDBWebApi.Models
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();
        private int _nextRollNumber = 1;

        public StudentRepository()
        {
            Add(new Student { FirstName = "Raja",MiddleName=null,LastName="Babu",Major="Physics",EmailAddress="rajababu@gmail.com",Address="Shahjahanpur" });
            Add(new Student { FirstName = "Venkat", MiddleName = "Krishnapalli", LastName = "Iyer", Major = "Chemistry", EmailAddress = "venkatesh@gmail.com", Address = "Kerala" });
            Add(new Student { FirstName = "Leela", MiddleName = null, LastName = "Shetty", Major = "Music", EmailAddress = "leela@gmail.com", Address = "Kolkata" });
            Add(new Student { FirstName = "Kavita", MiddleName = "Krishnamurthy", LastName = "Iyer", Major = "Mathematics", EmailAddress = "kavita@gmail.com", Address = "Mumbai" });
        }
        public Student Add(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }
            student.RollNumber = _nextRollNumber++;
            students.Add(student);
            return student;
        }

        public Student Get(int rollNumber)
        {
            return students.Find(p => p.RollNumber == rollNumber);
        }

        public IEnumerable<Student> GetAll()
        {
            return students;
        }

        public void Remove(int rollNumber)
        {
            students.RemoveAll(p => p.RollNumber == rollNumber);
        }

        public bool Update(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }
            int index = students.FindIndex(p => p.RollNumber == student.RollNumber);
            if (index == -1)
            {
                return false;
            }
            students.RemoveAt(index);
            students.Add(student);
            return true;

        }
    }
}