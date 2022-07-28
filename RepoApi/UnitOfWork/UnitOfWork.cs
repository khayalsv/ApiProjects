using RepoApi.Data;
using RepoApi.Data.Entities;
using RepoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoApi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Book, int> BookRepository { get; set; } //generic-den gelen

        public ILibraryRepository LibraryRepository { get; set; } //ozel metodu olan

    
        private readonly MyContext _mycontext;
        public UnitOfWork(MyContext mycontext)
        {
            _mycontext = mycontext;
            BookRepository = new EfRepository<Book, int>(mycontext);
            LibraryRepository = new LibraryRepository(mycontext);
        }


        public async Task Commit()
        {
            await _mycontext.SaveChangesAsync();
        }
    }
}
