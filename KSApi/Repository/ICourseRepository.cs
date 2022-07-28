using KSApi.Data;
using KSApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KSApi.Repository
{
    public interface ICourseRepository : IRepository<Course, int>
    {
        Task<Course> FindByName(string name);  //metodlar
    }

    public class CourseRepository : EfRepository<Course, int>, ICourseRepository
    {
        private readonly MyContext _myContext;
        public CourseRepository(MyContext myContext):base(myContext)
        {
            _myContext = myContext;
        }

        public async Task<Course> FindByName(string name)
        {
            var course = await _myContext.Set<Course>().
                              Where(x => x.Name.Contains(name)).
                              FirstOrDefaultAsync();

            return course;
        }
    }
}
