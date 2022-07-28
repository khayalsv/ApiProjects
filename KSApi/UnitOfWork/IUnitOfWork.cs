using KSApi.Data.Entities;
using KSApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSApi.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Student, int> StudentRepository { get; set; }
        public ICourseRepository CourseRepository{ get; set; }
        public Task Commit();
    }
}
