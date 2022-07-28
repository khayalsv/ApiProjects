using KSApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSApi.Repository
{
    public interface IStudentRepository
    {   
        Task<Student> Get(int id);

        Task<IEnumerable<Student>> GetAll();

        Task<Student> Add(Student student);

        Task<Student> Delete(int id);

        Task<Student> Update(Student newstudent);
    }
}
