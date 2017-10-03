using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentDBWebApi.Models;


namespace StudentDBWebApi.Controllers
{
    public class StudentController : ApiController
    {
        IStudentRepository repository = new StudentRepository();
        public IEnumerable<Student> GetAllStudents()
        {
            return repository.GetAll();
        }
       
        public Student GetStudent(int rollNumber)
        {
            Student item = repository.Get(rollNumber);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        
        public Student PostStudent(Student item)
        {
            item = repository.Add(item);
            return item;

        }
        public void PutStudent(int RollNumber, Student student)
        {
            student.RollNumber = RollNumber;
            if (!repository.Update(student))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteStudent(int RollNumber)
        {
            Student item = repository.Get(RollNumber);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(RollNumber);
        }

    }
}
