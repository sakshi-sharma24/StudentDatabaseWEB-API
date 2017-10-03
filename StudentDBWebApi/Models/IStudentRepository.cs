using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDBWebApi.Models
{
    interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student Get(int rollNumber);
        Student Add(Student student);
        void Remove(int rollNumber);
        bool Update(Student student);
    }
}
