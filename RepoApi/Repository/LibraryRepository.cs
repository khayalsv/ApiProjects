using Microsoft.EntityFrameworkCore;
using RepoApi.Data;
using RepoApi.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace RepoApi.Repository
{
    //public class LibraryRepository : EfRepository<Library, int>, ILibraryRepository
    //{
    //    private readonly MyContext _myContext;

    //    public LibraryRepository(MyContext myContext):base(myContext)
    //    {
    //        _myContext = myContext;
    //    }
    //    public async Task<Library> FindByName(string name)
    //    {
    //        var library = await _myContext.Set<Library>().
    //                          Where(x => x.Name.Contains(name)).
    //                          FirstOrDefaultAsync();

    //        return library;
    //    }
    //}
}
