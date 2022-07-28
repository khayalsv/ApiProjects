using KSApi.Data;
using KSApi.Data.Entities;
using KSApi.Repository;
using System.Threading.Tasks;

namespace KSApi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Student, int> StudentRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }

        private readonly MyContext _mycontext;
        public UnitOfWork(MyContext mycontext)
        {
            _mycontext = mycontext;
            StudentRepository = new EfRepository<Student, int>(mycontext);
            CourseRepository = new CourseRepository(mycontext);
        }

        public async Task Commit()
        {
            await _mycontext.SaveChangesAsync();
        }
    }
}
